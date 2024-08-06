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
                    Medicines = p.PatientsMedicines.Select(pm => new ExportMedicineDto()
                    {
                        Name = pm.Medicine.Name,
                        Price = pm.Medicine.Price,
                        Producer = pm.Medicine.Producer,
                        BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd")
                    })
                    .OrderByDescending(m=>m.BestBefore)
                    .ThenBy(m=>m.Price)
                    .ToArray()
                })
                .OrderByDescending(p=>p.Medicines.Length)
                .ThenBy(p=>p.Name)
                .ToArray();

            return helper.Sereialize(patientsDto, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            return null;
        }
    }
}
