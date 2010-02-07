using System.Xml;

namespace CC.Utilities.Rss
{
    /// <summary>
    /// Represents an Item element in an RSS 2.0 XML document.
    /// </summary>
    public class RssItem
    {
        #region Constructor
        /// <summary>
        /// Create a new <see cref="RssItem"/> from a <see cref="XmlNode"/>.
        /// </summary>
        /// <param name="xmlNode">The <see cref="XmlNode"/> to parse.</param>
        public RssItem(XmlNode xmlNode)
        {
            Author = xmlNode.SelectSingleNodeInnerText("author");
            Category = xmlNode.SelectSingleNodeInnerText("category");
            Comments = xmlNode.SelectSingleNodeInnerText("comments");
            Description = xmlNode.SelectSingleNodeInnerText("description");
            Link = xmlNode.SelectSingleNodeInnerText("link");
            Guid = xmlNode.SelectSingleNodeInnerText("guid");
            Title = xmlNode.SelectSingleNodeInnerText("title");

            XmlNode selectedNode = xmlNode.SelectSingleNode("enclosure");
            if (selectedNode != null)
            {
                Enclosure = new RssEnclosure(selectedNode);
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The author
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// The category
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// The comments
        /// </summary>
        public string Comments { get; private set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The <see cref="RssEnclosure"/>
        /// </summary>
        public RssEnclosure Enclosure { get; private set; }

        /// <summary>
        /// The guid
        /// </summary>
        public string Guid { get; private set; }

        /// <summary>
        /// The link
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; private set; }
        #endregion
    }
}