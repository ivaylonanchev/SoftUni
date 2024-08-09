using NetPay.Data;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NetPay.Data.Models;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetPay.Data.Models.Enums;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            XmlHelper helper = new XmlHelper();
            const string xmlRoot = "Households";
            ImportHouseholdDto[] deseriaizedHouseholdDtos = helper
                .Deseriaize<ImportHouseholdDto[]>(xmlString, xmlRoot);

            ICollection<Household> households = new List<Household>();
            var sb = new StringBuilder();
            foreach (var householdDto in deseriaizedHouseholdDtos)
            {
                if (!IsValid(householdDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (context.Households.Any(x => x.ContactPerson == householdDto.ContactPerson)
                    || context.Households.Any(x => x.PhoneNumber == householdDto.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }
                //Moje da ima  greshka pri email = null
                if (context.Households.Any(x => x.Email == householdDto.Email))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }
                if (households.Any(x => x.ContactPerson == householdDto.ContactPerson)
                    || households.Any(x => x.PhoneNumber == householdDto.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }
                //Moje da ima  greshka pri email = null
                if (households.Any(x => x.Email == householdDto.Email))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Household household = new Household()
                {
                    ContactPerson = householdDto.ContactPerson,
                    Email = householdDto.Email,
                    PhoneNumber = householdDto.PhoneNumber
                };

                households.Add(household);
                sb.AppendLine(string.Format(SuccessfullyImportedHousehold, household.ContactPerson));

            }
            context.Households.AddRange(households);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            ImportExpenseDto[] deserializedExpenses = JsonConvert
                .DeserializeObject<ImportExpenseDto[]>(jsonString);

            ICollection<Expense> expenses = new List<Expense>();
            var sb = new StringBuilder();
            foreach (var expenseDto in deserializedExpenses)
            {
                if (!IsValid(expenseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Households.Any(x => x.Id == expenseDto.HouseholdId)
                    || !context.Services.Any(x => x.Id == expenseDto.ServiceId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (expenseDto.PaymentStatus == "Paid"
                    || expenseDto.PaymentStatus == "Unpaid"
                    || expenseDto.PaymentStatus == "Overdue"
                    || expenseDto.PaymentStatus == "Expired")
                {

                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dueDate;
                bool isDateValid = DateTime
                    .TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out dueDate);
                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                
                Expense expense = new Expense()
                {
                    ExpenseName = expenseDto.ExpenseName,
                    Amount = decimal.Parse(expenseDto.Amount.ToString("F2")),
                    DueDate = dueDate,
                    PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), expenseDto.PaymentStatus),
                    HouseholdId = expenseDto.HouseholdId,
                    ServiceId = expenseDto.ServiceId
                };

                expenses.Add(expense);
                sb.AppendLine(string.Format(SuccessfullyImportedExpense, expense.ExpenseName, expense.Amount));
            }
            context.Expenses.AddRange(expenses);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}