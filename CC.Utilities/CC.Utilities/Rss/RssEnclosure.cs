using System;
using System.Xml;
using System.Xml.Serialization;

namespace CC.Utilities.Rss
{
    /// <summary>
    /// Represents a RSS enclosure.
    /// </summary>
    [Serializable, XmlRoot("enclosure")]
    public class RssEnclosure: IEquatable<RssEnclosure>
    {
        #region Constructor
        /// <summary>
        /// Create a new <see cref="RssEnclosure"/>.
        /// </summary>
        public RssEnclosure()
        {
            Length = -1;
            Type = string.Empty;
            Url = string.Empty;
        }

        /// <summary>
        /// Create a new <see cref="RssEnclosure"/> from a <see cref="XmlNode"/>.
        /// </summary>
        /// <param name="xmlNode">The <see cref="XmlNode"/> to parse.</param>
        public RssEnclosure(XmlNode xmlNode)
        {
            Type = xmlNode.AttributeValue("type");
            Url = xmlNode.AttributeValue("url");

            long tempLength;

            if (long.TryParse(xmlNode.AttributeValue("length"), out tempLength))
            {
                Length = tempLength;
            }
            else
            {
                Length = -1;
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The length
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// The type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The url
        /// </summary>
        public string Url { get; set; }
        #endregion

        #region Public Methods
        public bool Equals(RssEnclosure other)
        {
            bool returnValue = false;

            if (other != null && Length.Equals(other.Length) && Type.Equals(other.Type) && Url.Equals(other.Url))
            {
                returnValue = true;
            }

            return returnValue;
        }
        #endregion
    }
}
