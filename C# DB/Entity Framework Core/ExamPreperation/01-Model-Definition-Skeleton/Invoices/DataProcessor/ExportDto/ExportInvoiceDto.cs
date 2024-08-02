using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Invoices.Data.Models.Enums;

namespace Invoices.DataProcessor.ExportDto;
[XmlRoot("Invoice")]
public class ExportInvoiceDto
{
    [XmlElement(nameof(InvoiceNumber))]
    public int InvoiceNumber { get; set; }

    [XmlElement(nameof(InvoiceAmount))]
    public decimal InvoiceAmount { get; set; }

    [XmlElement(nameof(DueDate))]
    public string? DueDate { get; set; } = null!;

    [XmlElement(nameof(Currency))] 
    public string? Currency { get; set; } = null!;

}