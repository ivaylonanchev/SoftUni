using System.Text;
using System.Xml.Serialization;
using Invoices.Data.Models;
using Invoices.DataProcessor.ImportDto;
using Microsoft.EntityFrameworkCore;

namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Invoices.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportClientDto[]), new XmlRootAttribute("Clients"));

            ImportClientDto[] import;
            using var reader = new StringReader(xmlString);
            import = (ImportClientDto[])xmlSerializer.Deserialize(reader);

            var sb = new StringBuilder();

            List<Client> clients = new List<Client>();

            foreach (var client in import)
            {
                try
                {
                    clients = clients
                        .Select(i => new Client
                        {
                            Name = i.Name,
                            NumberVat = i.NumberVat,
                            Addresses = i.Addresses.Select(a => new Address
                            {
                                StreetName = a.StreetName,
                                StreetNumber = a.StreetNumber,
                                PostCode = a.PostCode,
                                City = a.City,
                                Country = a.Country
                            })
                                .ToList()
                        })
                        .ToList();
                    sb.AppendLine($"Successfully imported client {client.Name}");
                }
                catch (Exception e)
                {

                    sb.AppendLine("Invalid data!");
                }

            }
            //Client[] clients = import
            //    .Select(i => new Client
            //    {
            //        Name = i.Name,
            //        NumberVat = i.NumberVat,
            //        Addresses = i.Addresses.Select(a => new Address
            //        {
            //            StreetName = a.StreetName,
            //            StreetNumber = a.StreetNumber,
            //            PostCode = a.PostCode,
            //            City = a.City,
            //            Country = a.Country
            //        })
            //            .ToArray()
            //    })
            //    .ToArray();

            context.Clients.AddRange(clients);
            context.SaveChanges();



            return null;
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {


            throw new NotImplementedException();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
