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

        #region Private Fields
        private string _Author;
        private string _Category;
        private string _Comments;
        private string _Description;
        private RssEnclosure _Enclosure;
        private string _Guid;
        private int _HashCode;
        private string _Link;
        private string _Title;
        #endregion

        #region Public Properties
        /// <summary>
        /// The author
        /// </summary>
        public string Author
        {
            get { return _Author; }
            set { _Author = value; SetHashCode(); }
        }

        /// <summary>
        /// The category
        /// </summary>
        public string Category
        {
            get { return _Category; }
            set { _Category = value; SetHashCode(); }
        }

        /// <summary>
        /// The comments
        /// </summary>
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; SetHashCode(); }
        }

        /// <summary>
        /// The description
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; SetHashCode(); }
        }

        /// <summary>
        /// The <see cref="RssEnclosure"/>
        /// </summary>
        public RssEnclosure Enclosure
        {
            get { return _Enclosure; }
            set { _Enclosure = value; SetHashCode(); }
        }

        /// <summary>
        /// The guid
        /// </summary>
        public string Guid
        {
            get { return _Guid; }
            set { _Guid = value; SetHashCode(); }
        }

        /// <summary>
        /// The link
        /// </summary>
        public string Link
        {
            get { return _Link; }
            set { _Link = value; SetHashCode(); }
        }

        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; SetHashCode(); }
        }
        #endregion

        #region Private Methods
        private void SetHashCode()
        {
            _HashCode = (_Author + _Category + _Comments + _Description + _Enclosure + _Guid + _Link + _Title).GetHashCode();
        }
        #endregion
        
        #region Public Methods
        public override bool Equals(object obj)
        {
            if (obj is RssItem)
            {
                return Equals(obj as RssItem);
            }

            return false;
        }
        
        public bool Equals(RssItem other)
        {
            return (other != null && (Author == other.Author) && (Category == other.Category) && (Comments == other.Comments) && (Description == other.Description) && (Enclosure == other.Enclosure) && (Guid == other.Guid) && (Link == other.Link) && (Title == other.Title));
        }

        public override int GetHashCode()
        {
            return _HashCode;
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