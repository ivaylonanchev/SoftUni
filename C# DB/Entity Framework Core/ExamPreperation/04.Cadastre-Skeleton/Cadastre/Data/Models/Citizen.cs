using System.ComponentModel.DataAnnotations;
using Cadastre.Data.Enumerations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cadastre.Data.Models;

public class Citizen
{
    public Citizen()
    {
        PropertiesCitizens = new List<PropertyCitizen>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string? FirstName { get; set; } = null!;

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string? LastName { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [Range(0,3)]
    public MaritalStatus MaritalStatus { get; set; }

    public ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
}