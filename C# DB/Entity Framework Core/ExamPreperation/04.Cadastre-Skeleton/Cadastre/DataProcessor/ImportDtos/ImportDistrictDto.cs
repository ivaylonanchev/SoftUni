using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using AutoMapper.Configuration.Conventions;
using Cadastre.Data.Models;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("District")]
public class ImportDistrictDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(80)]
    [XmlElement(nameof(Name))]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(8)]
    [RegularExpression(@"[A-Z]{2}\-[0-9]{5}")]
    [XmlElement(nameof(PostalCode))]
    public string PostalCode { get; set; } = null!;

    public ImportPropertyDto[] Properties { get; set; }
}