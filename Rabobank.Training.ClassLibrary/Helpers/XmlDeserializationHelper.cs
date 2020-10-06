using System.IO;
using System.Xml.Serialization;

namespace Rabobank.Training.ClassLibrary.Helpers
{
    public class XmlDeserializationHelper
    {
        public static T Deserialize<T>(string xmlData) where T : class
        {
            var ser = new XmlSerializer(typeof(T));
            using (var sr = new StringReader(xmlData))
            {
                return (T) ser.Deserialize(sr);
            }
        }
    }
}