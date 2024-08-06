using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Microsoft.Extensions.Options;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType("Pharmacy")]
public class ImportPharmaciesDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    [XmlElement(nameof(Name))]
    public string? Name { get; set; } = null!;

    [Required]
    [StringLength(14)]
    [RegularExpression(@"\([0-9]{3}\)\ [0-9]{3}\-[0-9]{4}")]
    [XmlElement(nameof(PhoneNumber))]
    public string? PhoneNumber { get; set; } = null!;
    
    [Required]
    [XmlAttribute(nameof(IsNonStop))]
    public bool IsNonStop { get; set; }

    [XmlArray(nameof(Medicines))]
    public ImportMedicineDto[] Medicines { get; set; }
}