using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TestApp.Services
{
    public static class XmlHelper
    {
        public static T ConvertNode<T>(XmlNode node) where T : class
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(node.OuterXml);
            writer.Flush();

            stream.Position = 0;

            var serializer = new XmlSerializer(typeof(T));
            T result = (serializer.Deserialize(stream) as T);

            return result;
        }
    }
}
