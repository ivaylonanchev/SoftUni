using System.ComponentModel.Design.Serialization;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto;
[XmlRoot("Client")]
public class ExportClientDto
{
    [XmlElement(nameof(ClientName))] 
    public string? ClientName { get; set; } = null!;
    [XmlElement(nameof(VatNumber))]
    public string? VatNumber { get; set; } = null!;

    [XmlArray(nameof(Invoices))]
    public ExportInvoiceDto[] Invoices { get; set; } = null!;

    [XmlAttribute(nameof(InvoicesCount))]
    public int InvoicesCount { get; set; }
}