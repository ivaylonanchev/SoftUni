using System.Data.Common;
using System.Globalization;
using System.Text;
using Boardgames.Utilities;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            XmlHelper helper = new XmlHelper();
            const string xmlRoot = "Districts";

            ImportDistrictDto[] deserializedDistricts = helper
                .Deseriaize<ImportDistrictDto[]>(xmlDocument, xmlRoot);

            ICollection<District> districts = new List<District>();
            var sb = new StringBuilder();
            foreach (var districtDto in deserializedDistricts)
            {
                if (!IsValid(districtDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(x => x.Name == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                District district = new District()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode
                };

                ICollection<Property> properties = new List<Property>();
                foreach (var propertyDto in districtDto.Properties)
                {
                    if (!IsValid(propertyDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime dateOfAcquisition;
                    bool isDateValid = DateTime
                        .TryParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo
                            .InvariantCulture, DateTimeStyles.None, out dateOfAcquisition);

                    if (!isDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (district.Properties.Any(x => x.PropertyIdentifier == propertyDto.PropertyIdentifier)
                        || dbContext.Districts
                            .Any(x => x.Properties
                                .Any(a => a.PropertyIdentifier == propertyDto.PropertyIdentifier)))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (district.Properties.Any(x => x.Address == propertyDto.Address)
                        || dbContext.Districts
                            .Any(x => x.Properties
                                .Any(a => a.Address == propertyDto.Address)))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Property property = new Property()
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = dateOfAcquisition
                    };

                    district.Properties.Add(property);
                }

                districts.Add(district);
                sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }
            dbContext.Districts.AddRange(districts);
            dbContext.SaveChanges();


            return sb.ToString().Trim();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            ImportCitizenDto[] deserializedCitizens = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            ICollection<Citizen> citizens = new List<Citizen>();
            var sb = new StringBuilder();
            foreach (var citizenDto in deserializedCitizens)
            {
                if (!IsValid(citizenDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime birthDate;
                bool isDateValid = DateTime
                    .TryParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out birthDate);
                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Citizen citizen = new Citizen()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = birthDate,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), citizenDto.MaritalStatus)
                };

                foreach (var propertyId in citizenDto.Properties)
                {
                    PropertyCitizen pz = new PropertyCitizen()
                    {
                        PropertyId = propertyId,
                        Citizen = citizen
                    };

                    citizen.PropertiesCitizens.Add(pz);
                }

                citizens.Add(citizen);
                sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName , citizen.LastName,
                    citizen.PropertiesCitizens.Count));
            }
            dbContext.Citizens.AddRange(citizens);
            dbContext.SaveChanges();

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
