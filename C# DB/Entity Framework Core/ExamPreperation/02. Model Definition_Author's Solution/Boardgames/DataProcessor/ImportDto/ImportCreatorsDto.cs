using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Boardgames.Data.Models;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Creator")]
public class ImportCreatorsDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(7)]
    [XmlElement(nameof(FirstName))]
    public string? FirstName { get; set; } = null!;

    [Required]
    [MinLength(2)]
    [MaxLength(7)]
    [XmlElement(nameof(LastName))]
    public string? LastName { get; set; } = null!;

    [XmlArray("Boardgames")] 
    public ImportBoardgameDto[] Boardgames { get; set; }
}