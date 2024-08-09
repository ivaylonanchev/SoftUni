using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos;

[XmlType("Household")]
public class ExportHouseholdDto
{
    [XmlElement(nameof(ContactPerson))]
    public string ContactPerson { get; set; }

    [XmlElement(nameof(Email))]
    public string Email { get; set; }

    [XmlElement(nameof(PhoneNumber))]
    public string PhoneNumber { get; set; }

    [XmlArray(nameof(Expenses))]
    public ExportExpenseDto[] Expenses { get; set; }
}