using System.Xml;

namespace CC.Utilities
{
    /// <summary>
    /// Contains <see cref="XmlNode"/> extension methods
    /// </summary>
    public static class XmlNodeExtensions
    {
        /// <summary>
        /// Gets an attibute value from an <see cref="XmlNode"/>
        /// </summary>
        /// <param name="xmlNode">The <see cref="XmlNode"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns>The attribute value</returns>
        public static string AttributeValue(this XmlNode xmlNode, string name)
        {
            string returnValue = string.Empty;

            if (xmlNode.Attributes[name] != null)
            {
                returnValue = xmlNode.Attributes[name].Value;
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the InnerText of an <see cref="XmlNode"/> based on an XPath expression.
        /// </summary>
        /// <param name="xmlNode">The <see cref="XmlNode"/></param>
        /// <param name="xpath">The XPath expression</param>
        /// <returns>The InnerText of the selected <see cref="XmlNode"/></returns>
        public static string SelectSingleNodeInnerText(this XmlNode xmlNode, string xpath)
        {
            string returnValue = string.Empty;

            XmlNode selectedNode = xmlNode.SelectSingleNode(xpath);
            if (selectedNode != null)
            {
                returnValue = selectedNode.InnerText;
            }

            return returnValue;
        }
    }
}
