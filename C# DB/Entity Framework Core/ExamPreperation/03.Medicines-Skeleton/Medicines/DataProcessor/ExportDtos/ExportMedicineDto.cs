using System.Data;
using System.Xml.Serialization;
using Medicines.Data.Models;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType("Medicine")]
public class ExportMedicineDto
{
    [XmlAttribute(nameof(Category))]
    public string Category { get; set; } = null!;

    [XmlElement(nameof(Name))]
    public string Name { get; set; } = null!;
    [XmlElement(nameof(Price))]
    public decimal Price { get; set; }

    [XmlElement(nameof(Producer))] 
    public string Producer { get; set; } = null!;

    [XmlElement(nameof(BestBefore))] 
    public string BestBefore { get; set; }

}