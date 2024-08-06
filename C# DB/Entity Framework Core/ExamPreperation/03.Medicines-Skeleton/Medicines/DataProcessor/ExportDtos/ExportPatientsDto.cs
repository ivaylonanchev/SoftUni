using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType("Patient")]
public class ExportPatientsDto
{
    [XmlAttribute(nameof(Gender))]
    public string Gender { get; set; }
    [XmlElement(nameof(Name))]
    public string Name { get; set; }
    [XmlElement(nameof(AgeGroup))]
    public string AgeGroup { get; set; }
    [XmlArray(nameof(Medicines))]
    public ExportMedicineDto[] Medicines { get; set; }
}