using System.Xml.Serialization;
using Medicines.Data.Models;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType("Medicine")]
public class ExportMedicineDto
{
    [XmlAttribute(nameof(Category))]
    public string Category { get; set; }
    [XmlElement(nameof(Name))]
    public string Name { get; set; }
    [XmlElement(nameof(Price))]
    public decimal Price { get; set; }
    [XmlElement(nameof(Producer))]
    public string Producer { get; set; }
    [XmlElement(nameof(BestBefore))]
    public string BestBefore { get; set; }
    
}