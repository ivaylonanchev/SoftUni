using System.Globalization;
using Invoices.Data.Models.Enums;
using Invoices.DataProcessor.ExportDto;
using Invoices.Utilities;
using Newtonsoft.Json;

namespace Invoices.DataProcessor
{
    using Invoices.Data;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {   
            XmlHelper helper = new XmlHelper();
            const string xmlRoot = "Clients";

            ExportClientDto[] clientToExport = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientDto()
                {
                    InvoicesCount = c.Invoices.Count,
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                        .OrderBy(x => x.IssueDate)
                        .ThenByDescending(x => x.DueDate)
                        .Select(i => new ExportInvoiceDto()
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = i.Amount,
                            Currency = i.CurrencyType.ToString(),
                            DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture)

                        })
                        .ToArray()
                        
                })
                .OrderByDescending(x=>x.InvoicesCount)
                .ThenBy(x=>x.ClientName)
                .ToArray();


            return helper.Sereialize(clientToExport, xmlRoot);
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context.Products
                .Where(p => p.ProductsClients.Any())
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();


            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}