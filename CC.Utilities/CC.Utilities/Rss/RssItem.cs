using System;
using System.Xml;
using System.Xml.Serialization;

namespace CC.Utilities.Rss
{
    /// <summary>
    /// Represents an Item element in an RSS 2.0 XML document.
    /// </summary>
    [Serializable, XmlRoot("item")]
    public class RssItem : IEquatable<RssItem>
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

            if (other != null && (Author == other.Author) && (Category == other.Category) && (Comments == other.Comments) && (Description == other.Description) && (Enclosure == other.Enclosure) && (Guid == other.Guid) && (Link == other.Link) && (Title == other.Title))
            {
                returnValue = true;
                //if (Enclosure != null && Enclosure.Equals(other.Enclosure))
                //{
                //    returnValue = true;
                //}
                //else if (Enclosure == null && other.Enclosure == null)
                //{
                //    returnValue = true;
                //}
            }

            return returnValue;
        }
        #endregion

        #region Public Operators
        /// <summary>
        /// Determines if both <see cref="RssItem"/> are equal
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(RssItem x, RssItem y)
        {
            if ((object)x == null)
            {
                return (object)y == null;
            }
            return x.Equals(y);
        }

        /// <summary>
        /// Determines if both <see cref="RssItem"/> are not equal
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(RssItem x, RssItem y)
        {
            return !(x == y);
        }
        #endregion
    }
}