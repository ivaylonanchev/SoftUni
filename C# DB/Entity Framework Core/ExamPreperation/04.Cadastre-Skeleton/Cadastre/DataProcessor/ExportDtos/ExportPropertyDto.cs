using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ExportDtos;

[XmlType("Property")]
public class ExportPropertyDto
{
    [XmlAttribute("postal-code")]
    public string PostalCode { get; set; }

    [XmlElement(nameof(PropertyIdentifier))]
    public string PropertyIdentifier { get; set; }

    [XmlElement(nameof(Area))]
    public int Area { get; set; }

    [XmlElement(nameof(DateOfAcquisition))]
    public string DateOfAcquisition { get; set; }
}