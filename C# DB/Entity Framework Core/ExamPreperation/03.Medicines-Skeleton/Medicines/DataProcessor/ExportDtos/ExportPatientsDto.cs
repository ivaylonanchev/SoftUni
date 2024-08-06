using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType("Patient")]
public class ExportPatientsDto
{
    [XmlAttribute(nameof(Gender))] 
    public string Gender { get; set; } = null!;

    [XmlElement(nameof(Name))]
    public string Name { get; set; } = null!;

    [XmlElement(nameof(AgeGroup))]
    public string AgeGroup { get; set; } = null!;
    [XmlArray(nameof(Medicines))]
    public ExportMedicineDto[] Medicines { get; set; }
}