using System;
using System.Xml;
using System.Xml.Serialization;

namespace CC.Utilities.Rss
{
    /// <summary>
    /// Represents a RSS enclosure.
    /// </summary>
    [Serializable, XmlRoot("enclosure")]
    public class RssEnclosure : IEquatable<RssEnclosure>
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

        #region Private Fields
        private int _HashCode;
        private long _Length = -1;
        private string _Type;
        private string _Url;
        #endregion

        #region Public Properties
        /// <summary>
        /// The length
        /// </summary>
        public long Length
        {
            get { return _Length; }
            set { _Length = value; SetHashCode();}
        }

        /// <summary>
        /// The type
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set { _Type = value; SetHashCode(); }
        }

        /// <summary>
        /// The url
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; SetHashCode(); }
        }
        #endregion

        #region Private Methods
        private void SetHashCode()
        {
            _HashCode = (_Length + _Type + _Url).GetHashCode();
        }
        #endregion

        #region Public Methods
        public override bool Equals(object obj)
        {
            if (obj is RssEnclosure)
            {
                return Equals(obj as RssEnclosure);
            }

            return false;
        }

        public bool Equals(RssEnclosure other)
        {
            return (other != null && (Length == other.Length) && (Type == other.Type) && (Url == other.Url));
        }

        public override int GetHashCode()
        {
            return _HashCode;
        }

        public override string ToString()
        {
            return (_Length + " " + _Type + " " + _Url);
        }
        #endregion

        #region Public Operators
        /// <summary>
        /// Determines if both <see cref="RssEnclosure"/> are equal
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(RssEnclosure x, RssEnclosure y)
        {
            if ((object)x == null)
            {
                return (object)y == null;
            }
            return x.Equals(y);
        }

        /// <summary>
        /// Determines if both <see cref="RssEnclosure"/> are not equal
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(RssEnclosure x, RssEnclosure y)
        {
            return !(x == y);
        }
        #endregion
    }
}
