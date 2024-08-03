using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ExportDtos;

[XmlType("Guide")]
public class ExportGuidesDto
{
    [XmlElement(nameof(FullName))]
    public string FullName { get; set; }
    [XmlElement(nameof(TourPackages))]
    public ICollection<ExportTPGuideDto> TourPackages { get; set; }
}