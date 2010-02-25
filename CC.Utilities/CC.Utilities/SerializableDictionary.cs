using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CC.Utilities
{
    /// <summary>
    /// A serializable <see cref="Dictionary{TKey,TValue}"/>
    /// </summary>
    /// <typeparam name="TKey">The Key <see cref="Type"/></typeparam>
    /// <typeparam name="TValue">The Value <see cref="Type"/></typeparam>
    [Serializable, XmlRoot("Dictionary")]
    public class SerializableDictionary<TKey, TValue>: Dictionary<TKey, TValue>, IXmlSerializable
    {
        #region IXmlSerializable Members
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader xmlReader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            bool wasEmpty = xmlReader.IsEmptyElement;

            xmlReader.Read();

            if (wasEmpty)
            {
                return;
            }

            while (xmlReader.NodeType != XmlNodeType.EndElement)
            {
                xmlReader.ReadStartElement("Item");
                xmlReader.ReadStartElement("Key");

                TKey key = (TKey)keySerializer.Deserialize(xmlReader);

                xmlReader.ReadEndElement();
                xmlReader.ReadStartElement("Value");

                TValue value = (TValue)valueSerializer.Deserialize(xmlReader);

                xmlReader.ReadEndElement();

                Add(key, value);

                xmlReader.ReadEndElement();
                xmlReader.MoveToContent();
            }

            xmlReader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            if (Count > 0)
            {
                XmlSerializer keySerializer = new XmlSerializer(typeof (TKey));
                XmlSerializer valueSerializer = new XmlSerializer(typeof (TValue));

                foreach (TKey key in Keys)
                {
                    writer.WriteStartElement("Item");
                    writer.WriteStartElement("Key");

                    keySerializer.Serialize(writer, key);

                    writer.WriteEndElement();
                    writer.WriteStartElement("Value");

                    TValue value = this[key];

                    valueSerializer.Serialize(writer, value);

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }
        }
        #endregion
    }
}
