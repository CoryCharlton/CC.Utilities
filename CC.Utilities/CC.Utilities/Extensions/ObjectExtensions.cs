using System.IO;
using System.Xml.Serialization;

namespace CC.Utilities
{
    /// <summary>
    /// Contains common extension methods
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Converts and object to a serialized Xml string
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToXml(this object o)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(memoryStream))
                {
                    xmlSerializer.Serialize(streamWriter, o);
                    streamWriter.Flush();
                    memoryStream.Flush();
                    memoryStream.Position = 0;

                    using (StreamReader streamReader = new StreamReader(memoryStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}
