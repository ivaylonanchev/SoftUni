using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace TravelAgency.DataProcessor.ExportDtos;

[XmlType("TourPackage")]
public class ExportTourPackagesDto
{
    [XmlElement(nameof(Name))]
    public string Name { get; set; }
    [XmlElement(nameof(Description))]
    public string Description { get; set; }
    [XmlElement(nameof(Price))]
    public decimal Price { get; set; }
}