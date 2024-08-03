using Castle.Core.Internal;
using Invoices.Utilities;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;


namespace TravelAgency.DataProcessor
{

    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            XmlHelper helper = new XmlHelper();
            const string xmlRoot = "Guides";

            ExportGuidesDto[] guides = context.Guides
                .Where(x => x.Language == Language.Spanish)
                .Select(g => new ExportGuidesDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .Select(t => new ExportTPGuideDto()
                        {
                            Name = t.TourPackage.PackageName,
                            Description = t.TourPackage.Description,
                            Price = t.TourPackage.Price
                        })
                        .OrderByDescending(a => a.Price)
                        .ThenBy(a => a.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.TourPackages.Length)
                .ThenBy(x => x.FullName)
                .ToArray();




            using var writer = new StringWriter();


            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            XmlRootAttribute xmlRootArt = new XmlRootAttribute(xmlRoot); 
            xmlNamespaces.Add(string.Empty, string.Empty);

            var xmlSerializer = new XmlSerializer(typeof(ExportGuidesDto[]), xmlRootArt);
            xmlSerializer.Serialize(writer, guides, xmlNamespaces);

            var songsXml = writer.GetStringBuilder();



            return songsXml.ToString().Trim();
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customers = context.Customers
                .Where(c => c.Bookings.Any(x => x.TourPackage.Id == 1))
                .Select(c => new
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .Select(b => new
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString().Substring(0, 10)

                        })
                    .OrderBy(b => b.Date)
                    .ToArray()
                })
                .OrderByDescending(c => c.Bookings.Count())
                .ThenBy(c => c.FullName)
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
    }
}