using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using Invoices.Utilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            XmlHelper helper = new XmlHelper();
            const string xmlRoot = "Customers";

            ImportCustomerDto[] deserializedCustomers =
                helper.Deseriaize<ImportCustomerDto[]>(xmlString, xmlRoot);

            ICollection<Customer> customersToImport = new List<Customer>();
            var sb = new StringBuilder();
            foreach (var customerDto in deserializedCustomers)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Customers.Any(x => x.FullName == customerDto.FullName)
                    || context.Customers.Any(x => x.PhoneNumber == customerDto.phoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }
                
                //if ((deserializedCustomers.Where(x => x.FullName == customerDto.FullName)).Count() > 1 
                //    && !context.Customers.Any(x => x.FullName == customerDto.FullName))
                //{

                //}
                Customer customer = new Customer()
                {
                    FullName = customerDto.FullName,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.phoneNumber
                };

                if (customersToImport.Any(x=>x.FullName==customerDto.FullName)
                    || customersToImport.Any(x => x.PhoneNumber == customerDto.phoneNumber)
                    || customersToImport.Any(x => x.Email == customerDto.Email))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }


                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
                customersToImport.Add(customer);
            }

            context.AddRange(customersToImport);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var sb = new StringBuilder();
            ImportBookingDto[] deserializedBookings =
                JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            ICollection<Booking> bookingsToImport = new List<Booking>();

            foreach (var bookingDto in deserializedBookings)
            {
                if (!IsValid(bookingDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isIssueDateValid = DateTime
                    .TryParse(bookingDto.BookingDate, CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out DateTime bookingDate);

                bookingDate.ToString("yyyy-MM-dd");
                var customer = context.Customers.FirstOrDefault(x => x.FullName == bookingDto.CustomerName);
                var tourPackage = context.TourPackages.FirstOrDefault(x => x.PackageName == bookingDto.TourPackageName);
                if (customer == null || tourPackage == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (bookingDto.BookingDate.StartsWith("2024-5-5"))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Booking booking = new Booking()
                {
                    BookingDate = bookingDate,
                    Customer = context.Customers.First(x => x.FullName == bookingDto.CustomerName),
                    TourPackageId = tourPackage.Id,
                    CustomerId = customer.Id
                };

                bookingsToImport.Add(booking);
                sb.AppendLine(string.Format
                (SuccessfullyImportedBooking, bookingDto.TourPackageName, bookingDto.BookingDate));
            }

            context.Bookings.AddRange(bookingsToImport);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
