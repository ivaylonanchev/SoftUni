using NetPay.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos;

[XmlType("Expense")]
public class ExportExpenseDto
{
    [XmlElement(nameof(ExpenseName))]
    public string ExpenseName { get; set; }

    [XmlElement(nameof(Amount))]
    public decimal Amount { get; set; }

    [XmlElement(nameof(PaymentDate))]
    public string PaymentDate { get; set; }

    [XmlElement(nameof(ServiceName))]
    public string ServiceName { get; set; }
}