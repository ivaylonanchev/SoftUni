using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType("Medicine")]
public class ImportMedicineDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(150)]
    [XmlElement(nameof(Name))]
    public string Name { get; set; } = null!;

    [Required]
    [Range(0.01, 1000)]
    [XmlElement(nameof(Price))]
    public decimal Price { get; set; }

    [Required]
    [XmlElement(nameof(ProductionDate))]
    public string ProductionDate { get; set; }

    [Required]
    [XmlElement(nameof(ExpiryDate))]
    public string ExpiryDate { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    [XmlElement(nameof(Producer))]
    public string Producer { get; set; } = null!;

    [Required]
    [Range(0, 4)]
    [XmlAttribute(nameof(Category))]
    public int Category { get; set; }
}