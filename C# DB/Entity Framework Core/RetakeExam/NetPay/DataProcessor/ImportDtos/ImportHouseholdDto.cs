using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos;

[XmlType("Household")]
public class ImportHouseholdDto
{
    [Required]
    [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
    [StringLength(15)]
    [XmlAttribute("phone")]
    public string PhoneNumber { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string ContactPerson { get; set; } = null!;

    [MinLength(6)]
    [MaxLength(80)]
    public string? Email { get; set; }

}