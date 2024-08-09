using System.Diagnostics.Contracts;
using System.Resources;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            XmlHelper helper = new XmlHelper();
            const string xmlRoot = "Households";


            //List<ExportHouseholdDto> households = context.Households
            //    .Where(x => x.Expenses.Any(a => a.PaymentStatus != PaymentStatus.Paid))
            //    .OrderBy(x => x.ContactPerson)
            //    .Select(x => new ExportHouseholdDto()
            //    {
            //        ContactPerson = x.ContactPerson,
            //        Email = x.Email,
            //        PhoneNumber = x.PhoneNumber,
            //        Expenses = x.Expenses
            //            .Where(e => e.PaymentStatus != PaymentStatus.Paid)
            //            //.OrderBy(e => e.DueDate)
            //            //.ThenBy(e=>e.Amount)
            //            .Select(e => new ExportExpenseDto()
            //            {
            //                ExpenseName = e.ExpenseName,
            //                Amount = decimal.Parse(e.Amount.ToString("F2")),
            //                PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
            //                ServiceName = e.Service.ServiceName
            //            })
            //            .OrderBy(e => e.PaymentDate)
            //            .ThenBy(e => e.Amount)
            //            .ToArray()
            //    })
            //    .ToList();

            List<ExportHouseholdDto> households = context.Households
                .Where(x => x.Expenses.Any(a => a.PaymentStatus != PaymentStatus.Paid))
                .OrderBy(x => x.ContactPerson)
                .Select(x => new ExportHouseholdDto()
                {
                    ContactPerson = x.ContactPerson,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Expenses = x.Expenses
                        .Where(e => e.PaymentStatus != PaymentStatus.Paid)
                        .OrderBy(e => e.DueDate) // Order by DueDate without formatting
                        .ThenBy(e => e.Amount) // Order by Amount
                        .Select(e => new ExportExpenseDto()
                        {
                            ExpenseName = e.ExpenseName,
                            Amount = decimal.Parse(e.Amount.ToString("F2")), // Still fine
                            PaymentDate = e.DueDate.ToString("yyyy-MM-dd"), // Remove formatting here
                            ServiceName = e.Service.ServiceName
                        })
                        .ToArray()
                })
                .ToList();

            // Now format the PaymentDate after retrieval and re-order if necessary
            foreach (var household in households)
            {
                foreach (var expense in household.Expenses)
                {
                    expense.PaymentDate = DateTime.Parse(expense.PaymentDate).ToString("yyyy-MM-dd");
                }

                household.Expenses = household.Expenses
                    .OrderBy(e => e.PaymentDate)
                    .ThenBy(e => e.Amount)
                    .ToArray();
            }


            //List<ExportHouseholdDto> households = context.Households
            //    .Where(x => x.Expenses.Any(a => a.PaymentStatus != PaymentStatus.Paid))
            //    .OrderBy(x => x.ContactPerson)
            //    .Select(x => new ExportHouseholdDto()
            //    {
            //        ContactPerson = x.ContactPerson,
            //        Email = x.Email,
            //        PhoneNumber = x.PhoneNumber,
            //        Expenses = x.Expenses
            //            .Where(e => e.PaymentStatus != PaymentStatus.Paid)
            //            .OrderBy(e => e.DueDate)
            //            .Select(e => new ExportExpenseDto()
            //            {
            //                ExpenseName = e.ExpenseName,
            //                Amount = e.Amount, // No formatting here
            //                PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
            //                ServiceName = e.Service.ServiceName
            //            })
            //            .ToArray()
            //    })
            //    .ToList();

            //// Format the Amount after retrieval
            //foreach (var household in households)
            //{
            //    foreach (var expense in household.Expenses)
            //    {
            //        expense.Amount = decimal.Parse(expense.Amount.ToString("F2"));
            //    }
            //}

            //// Optionally sort the expenses in memory after formatting
            //households.ForEach(h =>
            //{
            //    h.Expenses = h.Expenses
            //        .OrderBy(e => e.Amount)
            //        .ToArray();
            //});

            return helper.Sereialize(households, xmlRoot);
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {

            List<ExportServiceDto> services = context.Services
                .OrderBy(x=>x.ServiceName)
                .Select(x => new ExportServiceDto()
                {
                    ServiceName = x.ServiceName,
                    Suppliers = x.SuppliersServices
                        .Select(s=>new ExportSuppliers()
                        {
                            SupplierName = s.Supplier.SupplierName
                        })
                        .OrderBy(s=>s.SupplierName)
                        .ToList()
                })
                .ToList();




            return JsonConvert.SerializeObject(services, Formatting.Indented);
        }
    }
}
