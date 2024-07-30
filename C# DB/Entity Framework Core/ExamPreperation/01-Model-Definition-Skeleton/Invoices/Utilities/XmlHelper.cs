using System.Security;
using System.Text;
using System.Xml.Serialization;

namespace Invoices.Utilities;

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
        var sb = new StringBuilder();
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add(string.Empty, string.Empty);

        using StringWriter writer = new StringWriter();
        xmlSerializer.Serialize(writer, obj);

        return sb.ToString().Trim();
    }
}