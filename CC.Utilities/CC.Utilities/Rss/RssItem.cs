using System;
using System.Xml;
using System.Xml.Serialization;

namespace CC.Utilities.Rss
{
    /// <summary>
    /// Represents an Item element in an RSS 2.0 XML document.
    /// </summary>
    [Serializable, XmlRoot("item")]
    public class RssItem: IEquatable<RssItem>
    {
        #region Constructor
        /// <summary>
        /// Create a new <see cref="RssItem"/>.
        /// </summary>
        public RssItem()
        {
            Author = string.Empty;
            Category = string.Empty;
            Comments = string.Empty;
            Description = string.Empty;
            Guid = string.Empty;
            Link = string.Empty;
            Title = string.Empty;
        }

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
        public string Author { get; set; }

        /// <summary>
        /// The category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The <see cref="RssEnclosure"/>
        /// </summary>
        public RssEnclosure Enclosure { get; set; }

        /// <summary>
        /// The guid
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// The link
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }
        #endregion

        #region Public Methods
        public bool Equals(RssItem other)
        {
            bool returnValue = false;

            if (other != null && Author.Equals(other.Author) && Category.Equals(other.Category) && Comments.Equals(other.Comments) && Description.Equals(other.Description) && Guid.Equals(other.Guid) && Link.Equals(other.Link) && Title.Equals(other.Title))
            {
                if (Enclosure != null && Enclosure.Equals(other.Enclosure))
                {
                    returnValue = true;
                }
                else if (Enclosure == null && other.Enclosure == null)
                {
                    returnValue = true;                    
                }
            }

            return returnValue;
        }
        #endregion
    }
}