using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastre.Data.Models;

public class Property
{
    public Property()
    {
        PropertiesCitizens = new List<PropertyCitizen>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(16)]
    [MaxLength(20)]
    public string? PropertyIdentifier { get; set; } = null!;

    [Required]
    [Range(0,100000000)]
    public int Area { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(500)]
    public string? Details { get; set; } = null!;

    [Required]
    [MinLength(5)]
    [MaxLength(200)]
    public string? Address { get; set; } = null!;

    [Required]
    public DateTime DateOfAcquisition { get; set; }

    [Required]
    [ForeignKey(nameof(DistrictId))]
    public int DistrictId { get; set; }
    public District District { get; set; }

    public ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
}
