using System.Globalization;
using System.Text;
using Boardgames.Utilities;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            ImportPatientsDto[] deserializedPatients = JsonConvert.DeserializeObject<ImportPatientsDto[]>(jsonString);


            ICollection<Patient> patients = new List<Patient>();
            var sb = new StringBuilder();
            foreach (var patientDto in deserializedPatients)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender,
                };
                foreach (int medId in patientDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(x => x.MedicineId == medId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine pm = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medId
                    };

                    patient.PatientsMedicines.Add(pm);
                }
                patients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }
            context.Patients.AddRange(patients);
            context.SaveChanges();


            return sb.ToString().Trim();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            XmlHelper helper = new XmlHelper();
            const string xmlRoot = "Pharmacies";

            ImportPharmaciesDto[] deserializesPharmaciesDto =
                helper.Deseriaize<ImportPharmaciesDto[]>(xmlString, xmlRoot);

            ICollection<Pharmacy> pharmaciesToImport = new List<Pharmacy>();
            var sb = new StringBuilder();
            foreach (var pharmacyDto in deserializesPharmaciesDto)
            {
                if (!IsValid(pharmacyDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                    IsNonStop = pharmacyDto.IsNonStop,
                    
                };
                foreach (var m in pharmacyDto.Medicines)
                {
                    if (!IsValid(m))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineProductionDate;
                    bool isProductionDateValid = DateTime
                        .TryParseExact(m.ProductionDate, "yyyy-MM-dd", CultureInfo
                            .InvariantCulture, DateTimeStyles.None, out medicineProductionDate);

                    DateTime medicineExpityDate;
                    bool isExpityDateValid = DateTime
                        .TryParseExact(m.ExpiryDate, "yyyy-MM-dd", CultureInfo
                            .InvariantCulture, DateTimeStyles.None, out medicineExpityDate);

                    if (!isExpityDateValid || !isProductionDateValid)
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    if (medicineProductionDate >= medicineExpityDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //if (medicineProductionDate == null || medicineExpityDate == null)
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    if (pharmacy.Medicines.Any(x => x.Name == m.Name)
                        && pharmacy.Medicines.Any(x=>x.Producer == m.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    Medicine medicine = new Medicine()
                    {
                        Name = m.Name,
                        Price = m.Price,
                        Category = (Category)m.Category,
                        ProductionDate = medicineProductionDate,
                        ExpiryDate = medicineExpityDate,
                        Producer = m.Producer
                    };
                    pharmacy.Medicines.Add(medicine);
                }
                pharmaciesToImport.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }
            context.Pharmacies.AddRange(pharmaciesToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
