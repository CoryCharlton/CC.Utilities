using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CC.Utilities.Rss
{
    /// <summary>
    /// Represents a RSS feed
    /// </summary>
    public class RssFeed
    {
        #region Constructors
        /// <summary>
        /// Creates a new <see cref="RssFeed"/>
        /// </summary>
        /// <param name="url">The url to the RSS feed</param>
        public RssFeed(string url) : this(new Uri(url))
        {
            // Empty method
        }

        /// <summary>
        /// Creates a new <see cref="RssFeed"/>
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> to the RSS feed</param>
        public RssFeed(Uri uri)
        {
            Uri = uri;
            LoadRssFeed();
        }
        #endregion

        #region Private Fields
        private readonly List<RssChannel> _Channels = new List<RssChannel>();
        #endregion

        #region Public Properties
        /// <summary>
        /// The <see cref="RssChannel"/>s
        /// </summary>
        public IList<RssChannel> Channels { get { return _Channels.AsReadOnly(); } }

        /// <summary>
        /// Indicates wether or not an error occured while loading the RSS feed
        /// </summary>
        public bool IsError { get; private set; }

        /// <summary>
        /// The last updated
        /// </summary>
        public DateTime LastUpdated { get; private set; }

        /// <summary>
        /// The <see cref="Uri"/>
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// The url
        /// </summary>
        public string Url { get { return Uri.AbsolutePath; } }
        #endregion

        #region Private Methods
        private void LoadRssFeed()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("user-agent", string.Format("{0}/{1} (http://www.ccswe.com)", Application.ProductName, Application.ProductVersion));

                    using (Stream stream = webClient.OpenRead(Uri))
                    {
                        using (XmlReader xmlReader = XmlReader.Create(stream))
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(xmlReader);

                            ParseRssFeed(xmlDocument);
                            LastUpdated = DateTime.Now;
                        }
                    }
                }

                IsError = false;
            }
            catch (Exception exception)
            {
                Logging.LogException(exception);
                ParseRssFeed(GenerateErrorRssFeed(exception));

                IsError = true;
            }
        }

        private static XmlNode GenerateErrorRssFeed(Exception exception)
        {
            /*
            <rss version="2.0">
              <channel>
                <title>CC.Utilities.Rss Error</title>
                <link>http://www.ccswe.com</link>
                <description>CC.Utilities.Rss Error</description>
                <item>
                  <title>Error text...</title>
                  <description>Error title...</description>
                </item>
              </channel>
            </rss>
            */

            XmlDocument xmlDocument = new XmlDocument();
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true, Encoding = Encoding.ASCII };
            XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, xmlWriterSettings);
            
            if (xmlWriter != null)
            {
                xmlWriter.WriteStartElement("rss");
                xmlWriter.WriteAttributeString("version", "2.0");
                xmlWriter.WriteStartElement("channel");
                
                xmlWriter.WriteStartElement("title");
                xmlWriter.WriteRaw("CC.Utilities.Rss Error!");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("link");
                xmlWriter.WriteRaw("http://www.ccswe.com/");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("description");
                xmlWriter.WriteRaw("CC.Utilities.Rss Error");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("item");

                xmlWriter.WriteStartElement("description");
                xmlWriter.WriteRaw("An error occurred while loading the RSS feed: " + exception.Message);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("title");
                xmlWriter.WriteRaw("Error loading RSS feed");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();

                xmlWriter.Flush();
                xmlWriter.Close();
            }

            xmlDocument.LoadXml(stringBuilder.ToString());

            return xmlDocument;
        }

        private void ParseRssFeed(XmlNode xmlNode)
        {
            _Channels.Clear();

            XmlNodeList channelNodes = xmlNode.SelectNodes("rss/channel");
            
            if (channelNodes != null)
            {
                foreach (XmlNode channelNode in channelNodes)
                {
                    _Channels.Add(new RssChannel(channelNode));
                }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Refresh the <see cref="RssFeed"/>
        /// </summary>
        /// <returns>true if the <see cref="RssFeed"/> was refreshed; false otherwise.</returns>
        public bool Refresh()
        {
            LoadRssFeed();
            return !IsError;
        }
        #endregion
    }
}