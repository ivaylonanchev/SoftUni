using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("Property")]
public class ImportPropertyDto
{
    [Required]
    [MinLength(16)]
    [MaxLength(20)]
    [XmlElement(nameof(PropertyIdentifier))]
    public string PropertyIdentifier { get; set; } = null!;

    [Required]
    [Range(0, 100000000)]
    [XmlElement(nameof(Area))]
    public int Area { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(500)]
    [XmlElement(nameof(Details))]
    public string? Details { get; set; } = null!;

    [Required]
    [MinLength(5)]
    [MaxLength(200)]
    [XmlElement(nameof(Address))]
    public string? Address { get; set; } = null!;

    [Required]
    [XmlElement(nameof(DateOfAcquisition))]
    public string? DateOfAcquisition { get; set; } = null!;
}