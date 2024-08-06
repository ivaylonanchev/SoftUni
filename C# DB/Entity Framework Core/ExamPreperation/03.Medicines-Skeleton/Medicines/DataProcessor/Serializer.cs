using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Boardgames.Utilities;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ExportDtos;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Medicines.Data;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            XmlHelper helper = new XmlHelper();

            DateTime givenDate;
            DateTime.TryParse(date, out givenDate);
            ExportPatientsDto[] patientsDto = context.Patients
                .Where(p => p.PatientsMedicines.Any(m => m.Medicine.ProductionDate >= givenDate))
                .Select(p => new ExportPatientsDto()
                {
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                        .Where(pm=>pm.Medicine.ProductionDate>=givenDate)
                        .Select(pm => new ExportMedicineDto()
                    {
                        Name = pm.Medicine.Name,
                        Price = pm.Medicine.Price,
                        Producer = pm.Medicine.Producer,
                        BestBefore = pm.Medicine.ExpiryDate.ToString(),
                    })
                    .OrderByDescending(m=>m.BestBefore)
                    .ThenBy(m=>m.Price)
                    .ToArray()
                })
                .OrderByDescending(p=>p.Medicines.Length)
                .ThenBy(p=>p.Name)
                .ToArray();

            foreach (var patient in patientsDto)
            {
                foreach (var med in patient.Medicines)
                {
                    med.BestBefore = med.BestBefore.Substring(0, 10);
                }
            }
            return helper.Sereialize(patientsDto, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m=>m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price,
                    Pharamcy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber,
                    }
                })
                
                .ToArray();

            return JsonConvert.SerializeObject(medicines, Formatting.Indented);
        }
    }
}
