using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using EbayModule.Error;

namespace EbayModule
{
    public class EbayImageManagement : BaseProcedures, IEbayImageManagement
    {
        private readonly ISiteUtility _utility;
        private readonly IEbayErrorLogger _logger;

        public EbayImageManagement(IEbayProperties properties, IEbayErrorLogger logger, ISiteUtility siteUtility) : base(properties)
        {
            if (properties == null)     { throw new NotImplementedException("IEbayProperties"); }
            if (siteUtility == null)    { throw new NotImplementedException("ISiteUtility"); }
            if (logger == null)         { throw new NotImplementedException("IEbayErrorLogger"); }

            _utility = siteUtility;
            _logger = logger;
        }

        public string[] UploadSelfHostedImages(PhotoDisplayCodeType photoDisplay, string[] pictureFileList)
        {   
            var service = EbayServiceContext(ServiceCallType.UploadSiteHostedPictures);
            var request = new UploadSiteHostedPicturesRequestType();
            var arrayLists = new ArrayList();
            var strArrays = pictureFileList;
            foreach (var str in strArrays)
            {
                if (photoDisplay == PhotoDisplayCodeType.PicturePack || photoDisplay == PhotoDisplayCodeType.SuperSize)
                {
                    request.PictureSet = PictureSetCodeType.Supersize;
                }

                request.PictureName = str;
                request.PictureData = new Base64BinaryType();
                request.ExternalPictureURL = pictureFileList;

                SetupRequestType<UploadSiteHostedPicturesRequestType>(request);
                var credentials = Properties.EbayCredentials;
                var apicall = service.UploadSiteHostedPictures(ref credentials, request);
                arrayLists.Add(apicall.SiteHostedPictureDetails.FullURL);
                if (apicall.Errors == null) continue;
                foreach (var e in apicall.Errors.ToArray())
                {
                    _logger.WriteToLog(e, EventLogEntryType.Error);
                }
            }

            return (string[])arrayLists.ToArray(typeof(string));
        }

        public string UpLoadPictureFile(PhotoDisplayCodeType photoDisplay, string pictureFile)
        {
            string[] strArrays = { pictureFile };
            return UpLoadPictureFiles(photoDisplay, strArrays)[0];
        }

        //Corect arrayLists.Add - need to return a dictionary reallly to link pic to local photo
        public string[] UpLoadPictureFiles(PhotoDisplayCodeType photoDisplay, string[] pictureFileList)
        {
            var uploadSiteHostedPicturesRequestType = new UploadSiteHostedPicturesRequestType();
            var arrayLists = new ArrayList();
            var strArrays = pictureFileList;
            foreach (var str in strArrays)
            {
                if (photoDisplay == PhotoDisplayCodeType.PicturePack || photoDisplay == PhotoDisplayCodeType.SuperSize)
                {
                    uploadSiteHostedPicturesRequestType.PictureSet = PictureSetCodeType.Supersize;
                }
                var uploadSiteHostedPicturesResponseType = UpLoadSiteHostedPicture(uploadSiteHostedPicturesRequestType, str);
                //arrayLists.Add(uploadSiteHostedPicturesResponseType.SiteHostedPictureDetails.FullURL);
            }
            return (string[])arrayLists.ToArray(typeof(string));
        }

        //Add ebay std error handle
        private UploadSiteHostedPicturesResponseType UpLoadSiteHostedPicture(UploadSiteHostedPicturesRequestType request, string fileName)
        {
            UploadSiteHostedPicturesResponseType uploadSiteHostedPicturesResponseType;
            UploadSiteHostedPicturesResponseType uploadSiteHostedPicturesResponseType1 = null;
            try
            {
                var xmlDoc = _utility.SerializeToXmlDoc(request);
                _utility.FixEncoding(xmlDoc);
                _utility.AddApiCredentials(xmlDoc, Properties);
                _utility.UpdateElementName(xmlDoc, "UploadSiteHostedPicturesRequestType", "UploadSiteHostedPicturesRequest");
                var outerXml = SendFile(fileName, xmlDoc.OuterXml);
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(outerXml);
                _utility.UpdateElementName(xmlDocument, "UploadSiteHostedPicturesResponse", "UploadSiteHostedPicturesResponseType");
                outerXml = xmlDocument.OuterXml;
                uploadSiteHostedPicturesResponseType1 = (UploadSiteHostedPicturesResponseType)_utility.DeserializeFromXml(outerXml, typeof(UploadSiteHostedPicturesResponseType));
                if (uploadSiteHostedPicturesResponseType1 != null && uploadSiteHostedPicturesResponseType1.Errors != null && uploadSiteHostedPicturesResponseType1.Errors.Length > 0)
                {
                    foreach (var e in uploadSiteHostedPicturesResponseType1.Errors)
                    {
                        _logger.WriteToLog(e, EventLogEntryType.Error);
                    }
                }
                uploadSiteHostedPicturesResponseType = uploadSiteHostedPicturesResponseType1;
            }
            catch
            {
                return uploadSiteHostedPicturesResponseType1;
            }
            return uploadSiteHostedPicturesResponseType;
        }

        private string SendFile(string fileName, string requestXmlString)
        {
            var version10 = (HttpWebRequest)WebRequest.Create(Properties.EpsServerUrl);
            version10.Method = "POST";
            version10.ProtocolVersion = HttpVersion.Version10;

            version10.Headers.Add("X-EBAY-API-COMPATIBILITY-LEVEL", Properties.ServiceVersion);
            var headers = version10.Headers;
            var siteId = _utility.GetSiteID(Properties.SiteId);
            headers.Add("X-EBAY-API-SITEID", siteId.ToString());
            version10.Headers.Add("X-EBAY-API-DETAIL-LEVEL", "0");
            version10.Headers.Add("X-EBAY-API-CALL-NAME", "UploadSiteHostedPictures");
            version10.ContentType = "multipart/form-data; boundary=MIME_boundary";
            byte[] numArray;
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                var binaryReader = new BinaryReader(fileStream);
                numArray = binaryReader.ReadBytes((int) fileStream.Length);
                binaryReader.Close();
                fileStream.Close();
            }
            var str = string.Concat("--MIME_boundary\r\nContent-Disposition: form-data; name=document\r\nContent-Type: text/xml; charset=\"UTF-8\"\r\n\r\n", requestXmlString, "\r\n--MIME_boundary\r\nContent-Disposition: form-data; name=image; filename=image\r\nContent-Transfer-Encoding: binary\r\nContent-Type: application/octet-stream\r\n\r\n");
            const string str1 = "\r\n--MIME_boundary--\r\n";
            var bytes = Encoding.ASCII.GetBytes(str);
            var bytes1 = Encoding.ASCII.GetBytes(str1);
            var length = bytes.Length + bytes1.Length + numArray.Length;
            version10.ContentLength = length;
            using (var requestStream = version10.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Write(numArray, 0, numArray.Length);
                requestStream.Write(bytes1, 0, bytes1.Length);
                requestStream.Close();
            }
            var response = (HttpWebResponse)version10.GetResponse();
            // ReSharper disable once AssignNullToNotNullAttribute
            var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            var end = streamReader.ReadToEnd();
            response.Close();
            return end;
        }
    }
}
