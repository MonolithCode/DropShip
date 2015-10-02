using System;
using System.Xml;
using EbayModule.eBaySvc;

namespace EbayModule.view
{
    public interface ISiteUtility
    {
        string FormatXml(string sUnformattedXml);
        void UpdateElementName(XmlDocument doc, string oldName, string newName);
        object DeserializeFromXml(string pXmlizedString, Type type);
        XmlDocument SerializeToXmlDoc(object obj);
        void FixEncoding(XmlDocument doc);
        void AddApiCredentials(XmlDocument doc, IEbayProperties properties);
        XmlElement CopyElementToName(XmlElement element, string tagName);
        int GetSiteID(SiteCodeType SiteCodeType);
    }
}