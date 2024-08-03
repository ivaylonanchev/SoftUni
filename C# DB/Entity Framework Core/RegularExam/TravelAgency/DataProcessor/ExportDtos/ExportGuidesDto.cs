using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ExportDtos;

[XmlType("Guide")]
public class ExportGuidesDto
{
    [XmlElement(nameof(FullName))]
    public string FullName { get; set; }

    [XmlArray(nameof(TourPackages))]
    public ExportTPGuideDto[] TourPackages { get; set; }
}