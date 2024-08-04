using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType("Creator")]
public class ExportCreatorDto
{
    [XmlElement(nameof(CreatorName))]
    public string CreatorName { get; set; }
    [XmlArray(nameof(Boardgames))]
    public ExportBoardgamesDto[] Boardgames { get; set; }

    [XmlAttribute] 
    public int BoardgamesCount { get; set; }
}