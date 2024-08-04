using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [Required]
    [MinLength(10)]
    [MaxLength(20)]
    [XmlElement("Name")]
    public string? Name { get; set; } = null!;
    [Required]
    [Range(1, 10)]
    [XmlElement(nameof(Rating))]
    public double Rating { get; set; }
    [Required]
    [Range(2018, 2023)]
    [XmlElement(nameof(YearPublished))]
    public int YearPublished { get; set; }

    [Required]
    [Range(0,4)]
    [XmlElement(nameof(CategoryType))]
    public int CategoryType { get; set; }

    [Required]
    [XmlElement(nameof(Mechanics))]
    public string Mechanics { get; set; }
}