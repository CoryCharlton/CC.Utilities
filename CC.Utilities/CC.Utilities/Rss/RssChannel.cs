using System.Collections.Generic;
using System.Xml;

namespace CC.Utilities.Rss
{
    /// <summary>
    /// Represents an RSS Channel in a RSS 2.0 XML document
    /// </summary>
    public class RssChannel
    {
        #region Constructor
        /// <summary>
        /// Creates a new <see cref="RssChannel"/> from a <see cref="XmlNode"/>
        /// </summary>
        /// <param name="xmlNode">The <see cref="XmlNode"/> use to create the <see cref="RssChannel"/></param>
        public RssChannel(XmlNode xmlNode)
        {
            _Items = new List<RssItem>();

            Title = xmlNode.SelectSingleNodeInnerText("title");
            Link = xmlNode.SelectSingleNodeInnerText("link");
            Description = xmlNode.SelectSingleNodeInnerText("description");

            Category = xmlNode.SelectSingleNodeInnerText("category");
            Copyright = xmlNode.SelectSingleNodeInnerText("copyright");
            Docs = xmlNode.SelectSingleNodeInnerText("copyright");
            Generator = xmlNode.SelectSingleNodeInnerText("generator");
            Language = xmlNode.SelectSingleNodeInnerText("language");
            ManagingEditor = xmlNode.SelectSingleNodeInnerText("managingEditor");
            WebMaster = xmlNode.SelectSingleNodeInnerText("webMaster");

            long tempTtl;
            if (long.TryParse(xmlNode.SelectSingleNodeInnerText("ttl"), out tempTtl))
            {
                Ttl = tempTtl;
            }
            else
            {
                Ttl = -1;                
            }

            XmlNodeList itemNodes = xmlNode.SelectNodes("item");
            if (itemNodes != null)
            {
                foreach (XmlNode itemNode in itemNodes)
                {
                    _Items.Add(new RssItem(itemNode));
                }
            }
        }
        #endregion

        #region Private Fields
        private readonly List<RssItem> _Items;
        #endregion

        #region Public Properties
        #region Required RSS 2.0 Channel elements
        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The link
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; private set; }
        #endregion

        #region Optional RSS 2.0 Channel elements
        /// <summary>
        /// The category
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// The copyright
        /// </summary>
        public string Copyright { get; private set; }

        /// <summary>
        /// The docs
        /// </summary>
        public string Docs { get; private set; }

        /// <summary>
        /// The generator
        /// </summary>
        public string Generator { get; private set; }

        /// <summary>
        /// The items
        /// </summary>
        public IList<RssItem> Items
        {
            get { return _Items.AsReadOnly(); }
        }

        /// <summary>
        /// The language
        /// </summary>
        public string Language { get; private set; }

        /// <summary>
        /// The managing editor
        /// </summary>
        public string ManagingEditor { get; private set; }

        /// <summary>
        /// The ttl
        /// </summary>
        public long Ttl { get; private set; }

        /// <summary>
        /// The webmaster
        /// </summary>
        public string WebMaster { get; private set; }
        #endregion
        #endregion
    }
}