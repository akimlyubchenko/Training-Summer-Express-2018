using System;
using System.IO;
using System.Threading;
using System.Xml;
using URLParser;

namespace ToXMLParser
{
    /// <summary>
    /// parser from txt to xml
    /// </summary>
    class XMLParser
    {
        private readonly string[] strs;
        private XmlDocument doc;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMLParser"/> class.
        /// </summary>
        /// <param name="path">The path to URLs</param>
        /// <exception cref="ArgumentNullException">Fill path</exception>
        public XMLParser(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Fill path");
            }

            strs = File.ReadAllLines(path);
            doc = new XmlDocument();
        }

        /// <summary>
        /// Save urls to .xml file
        /// </summary>
        /// <param name="path">The path to .xml</param>
        public void XMLSaver()
        {
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlNode URLS = AddCatalog(doc, "urlAddresses");

            for (int i = 0; i < strs.Length; i++)
            {
                XmlNode URL = AddCatalog(URLS, "urlAddress");
                if (!IsValid(strs[i]))
                {
                    
                    continue;
                }

                XMLSaver(URL, strs[i]);
            }

            Logger.Log($"Parsing was completed\t\t{DateTime.Now}\n...............................................");
            doc.Save($"XML.xml");
        }

        private void XMLSaver(XmlNode URL, string url)
        {
            string[] sortedParts = DoneString(url);

            URL.AppendChild(Host(sortedParts[0]));

            XmlNode URI = AddCatalog(URL, "uri");

            for (int i = 1; i < sortedParts.Length; i++)
            {
                int questionIndex = sortedParts[i].IndexOf('?');
                if (questionIndex == -1)
                {
                    URI.AppendChild(AddSegment(sortedParts[i]));
                }
                else
                {
                    URI.AppendChild(AddSegment(sortedParts[i].Remove(questionIndex)));
                    XmlNode parameters = (AddCatalog(URL, "parameters"));
                    parameters.AppendChild(AddParameter(sortedParts[i].Remove(0, questionIndex + 1)));
                }
            }
        }

        private string[] DoneString(string url)
        {
            string[] parts = url.Split('/');
            if (parts[parts.Length - 1] == "")
            {
                string[] sortedParts = new string[parts.Length - 3];
                Array.Copy(parts, 2, sortedParts, 0, parts.Length - 3);
                return sortedParts;
            }

            string[] sortedParts2 = new string[parts.Length - 2];
            Array.Copy(parts, 2, sortedParts2, 0, parts.Length - 2);
            return sortedParts2;
        }

        private XmlNode AddParameter(string str)
        {
            int equalIndex = str.IndexOf('=');
            XmlNode parameter = doc.CreateElement("parameter");
            XmlAttribute value = doc.CreateAttribute("value");
            XmlAttribute key = doc.CreateAttribute("key");
            value.Value = str.Remove(equalIndex);
            key.Value = str.Remove(0, equalIndex + 1);
            parameter.Attributes.Append(value);
            parameter.Attributes.Append(key);
            return parameter;
        }

        private XmlNode Host(string name)
        {
            XmlNode host = doc.CreateElement("host");
            XmlAttribute AttName = doc.CreateAttribute(name);
            AttName.Value = name;
            host.Attributes.Append(AttName);
            return host;
        }

        private XmlNode AddCatalog(XmlNode prev, string name)
        {
            XmlNode URI = doc.CreateElement(name);
            prev.AppendChild(URI);
            return URI;
        }

        private XmlNode AddSegment(string str)
        {
            XmlNode segment = doc.CreateElement("segment");
            segment.AppendChild(doc.CreateTextNode(str));
            return segment;
        }

        private bool IsValid(string url)
        {
            if (!url.Contains("://"))
            {
                Logger.Log($"URL: '{url}'  doesn't contain network protocol");
                return false;
            }

            int symb = url.IndexOf(':');
            string subString = url.Remove(0, symb + 3);
            int symb2 = subString.IndexOf('/');
            if (subString.Remove(symb2).IndexOf('.') == -1)
            {
                Logger.Log($"URL: '{url}'  have incorrect host name");
                return false;
            }

            return true;
        }
    }
}
