using System.Text.Json;
using Boardgames.Utilities;
using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.DataProcessor.ExportDtos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {

            
            var properties = dbContext.Properties
                .Where(p => p.DateOfAcquisition >= new DateTime(2000, 1, 1))
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens
                        .Select(pz => pz.Citizen)
                        .OrderBy(c => c.LastName)
                        .Select(c => new
                        {
                            LastName = c.LastName,
                            MaritalStatus = c.MaritalStatus.ToString()
                        })
                        .ToArray()

                })
                .ToArray();

            return JsonConvert.SerializeObject(properties, Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            const string xmlRoot = "Porperty";
            XmlHelper helper = new XmlHelper();

            ExportPropertyDto[] properties = dbContext.Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending(p=>p.Area)
                .ThenBy(p=>p.DateOfAcquisition)
                .Select(p => new ExportPropertyDto()
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd-MM-yyyy")
                })
                .ToArray();

            return helper.Sereialize<ExportPropertyDto[]>(properties,xmlRoot);
        }
    }
}
