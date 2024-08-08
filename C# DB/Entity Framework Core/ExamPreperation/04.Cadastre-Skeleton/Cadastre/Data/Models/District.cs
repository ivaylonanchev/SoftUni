using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models;

public class District
{
    public District()
    {
        Properties = new List<Property>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(80)]
    public string? Name { get; set; } = null!;

    [Required]
    [StringLength(8)]
    [RegularExpression(@"[A-Z]{2}\-[0-9]{5}")]
    public string? PostalCode { get; set; } = null!;

    [Required]
    [Range(0,3)]
    public Region Region { get; set; }
    public ICollection<Property> Properties { get; set; }
}