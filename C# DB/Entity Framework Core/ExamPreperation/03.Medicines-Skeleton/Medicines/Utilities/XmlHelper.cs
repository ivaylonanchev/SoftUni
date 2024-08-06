using System.Text;
using System.Xml.Serialization;

namespace Boardgames.Utilities;

public class XmlHelper
{
    public T Deseriaize<T>(string inputXml, string rootName)
        where T : class
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        using StringReader reader = new StringReader(inputXml);
        object? deserializedObject = xmlSerializer.Deserialize(reader);
        if (deserializedObject == null
            || deserializedObject is not T deserializedObjectTypes)
        {
            throw new InvalidOperationException();
        }
        return deserializedObjectTypes;
    }

    public string Sereialize<T>(T obj, string rootName)
    {
        using StringWriter writer = new StringWriter();
        
        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        xmlNamespaces.Add(string.Empty, string.Empty);
        
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
        xmlSerializer.Serialize(writer, obj, xmlNamespaces);

        var xmlText = writer.GetStringBuilder();
        
        return xmlText.ToString().Trim();
    }
}