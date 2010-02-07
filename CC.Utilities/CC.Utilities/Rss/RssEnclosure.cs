using System.Xml;

namespace CC.Utilities.Rss
{
    /// <summary>
    /// Represents a RSS enclosure.
    /// </summary>
    public class RssEnclosure
    {
        #region Constructor
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
        public long Length { get; protected set; }

        /// <summary>
        /// The type
        /// </summary>
        public string Type { get; protected set; }

        /// <summary>
        /// The url
        /// </summary>
        public string Url { get; protected set; }
        #endregion
    }
}
