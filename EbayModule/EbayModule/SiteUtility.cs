using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using EbayModule.eBaySvc;
using EbayModule.view;

// ReSharper disable InconsistentNaming

namespace EbayModule
{
    public class SiteUtility : ISiteUtility
    {
        public string FormatXml(string sUnformattedXml)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(sUnformattedXml);
            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);
            XmlTextWriter xmlTextWriter = null;
            try
            {
                xmlTextWriter = new XmlTextWriter(stringWriter)
                {
                    Formatting = Formatting.Indented
                };
                xmlDocument.WriteTo(xmlTextWriter);
            }
            finally
            {
                if (xmlTextWriter != null)
                {
                    xmlTextWriter.Close();
                }
            }
            return stringBuilder.ToString();
        }

        public void UpdateElementName(XmlDocument doc, string oldName, string newName)
        {
            var itemOf = (XmlElement)doc.GetElementsByTagName(oldName)[0];
            var name = CopyElementToName(itemOf, newName);
            doc.ReplaceChild(name, itemOf);
        }

        public object DeserializeFromXml(string pXmlizedString, Type type)
        {
            return (new XmlSerializer(type, "urn:ebay:apis:eBLBaseComponents")).Deserialize(new StringReader(pXmlizedString));
        }

        public XmlDocument SerializeToXmlDoc(object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType(), "urn:ebay:apis:eBLBaseComponents");
            MemoryStream memoryStream = new MemoryStream();
            xmlSerializer.Serialize(memoryStream, obj);
            memoryStream.Seek(0, SeekOrigin.Begin);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(memoryStream);
            memoryStream.Close();
            return xmlDocument;
        }

        public void FixEncoding(XmlDocument doc)
        {
            if (doc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                ((XmlDeclaration)doc.FirstChild).Encoding = "utf-8";
            }
        }

        public void AddApiCredentials(XmlDocument doc, IEbayProperties properties)
        {
            var xmlElement = doc.CreateElement("RequesterCredentials", "urn:ebay:apis:eBLBaseComponents");
            var apiCredential = doc.CreateElement("eBayAuthToken", "urn:ebay:apis:eBLBaseComponents");
            apiCredential.InnerText = properties.Token;
            xmlElement.AppendChild(apiCredential);
            Debug.Assert(doc.DocumentElement != null, "doc.DocumentElement != null");
            doc.DocumentElement.InsertBefore(xmlElement, doc.DocumentElement.FirstChild);
        }

        public XmlElement CopyElementToName(XmlElement element, string tagName)
        {
            var xmlElement = element.OwnerDocument.CreateElement(tagName);
            for (var i = 0; i < element.Attributes.Count; i++)
            {
                xmlElement.SetAttributeNode((XmlAttribute)element.Attributes[i].CloneNode(true));
            }
            for (var j = 0; j < element.ChildNodes.Count; j++)
            {
                xmlElement.AppendChild(element.ChildNodes[j].CloneNode(true));
            }
            return xmlElement;
        }

        public int GetSiteID(SiteCodeType SiteCodeType)
        {
            if (!Enum.IsDefined(typeof(SiteValueEnum), SiteCodeType.ToString()))
            {
                return 0;
            }
            // ReSharper disable once AssignNullToNotNullAttribute
            return (int)Enum.Parse(typeof(SiteValueEnum), Enum.GetName(typeof(SiteCodeType), SiteCodeType));
        }

        private enum SiteValueEnum
        {
            US = 0,
            Canada = 2,
            UK = 3,
            Australia = 15,
            Austria = 16,
            Belgium_French = 23,
            France = 71,
            Germany = 77,
            eBayMotors = 100,
            Italy = 101,
            Belgium_Dutch = 123,
            Netherlands = 146,
            Spain = 186,
            Switzerland = 193,
            Taiwan = 196,
            HongKong = 201,
            India = 203,
            Ireland = 205,
            Malaysia = 207,
            NewZealand = 208,
            CanadaFrench = 210,
            Philippines = 211,
            Poland = 212,
            Singapore = 216,
            Sweden = 218,
            China = 223
        }
    }
}
