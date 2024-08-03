using Castle.Core.Internal;
using Invoices.Utilities;
using Newtonsoft.Json;
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
            //XmlHelper helper = new XmlHelper();
            //const string xmlRoot = "Guides";

            //var guides = context.Guides
            //    .Where(x => x.Language == Language.Spanish)
            //    .Select(x => new ExportGuidesDto()
            //    {
            //        FullName = x.FullName,
            //        TourPackages = x.TourPackagesGuides.Select(tp => new 
            //        {
            //            Name = tp.TourPackage.PackageName,


            //        })
            //        .ToList()
            //    })

            return null;
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customers = context.Customers
                .Where(c=>c.Bookings.Any(x=>x.TourPackage.Id == 1))
                .Select(c => new
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b=>b.TourPackage.PackageName == "Horse Riding Tour")
                        .Select(b => new
                    {
                        TourPackageName = b.TourPackage.PackageName,
                        Date = b.BookingDate.ToString().Substring(0,10)

                    })
                    .OrderBy(b=>b.Date)
                    .ToArray()
                })
                .OrderByDescending(c=>c.Bookings.Count())
                .ThenBy(c=>c.FullName)
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
    }
}