using System;
using System.Linq;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class EbaySecurity : BaseProcedures, IEbaySecurity
    {

        public EbaySecurity(IEbayProperties properties) : base (properties)
        {
            if (properties == null)
            {
                throw new NotImplementedException("IEbayProperties");
            }
        }

        /// <summary>
        /// Returns the access key for the account once they have granted access
        /// </summary>
        /// <param name="secretKey">Guid ID that was passed when requesting access</param>
        /// <returns></returns>
        public string FetchAccessToken(Guid secretKey)
        {
            var service = EbayServiceContext(ServiceCallType.FetchToken);
            var r = new FetchTokenRequest
            {
                RequesterCredentials = Properties.EbayCredentials
            };
            //Required if the secret key is not provided
            //r.RequesterCredentials.Credentials.Username = "";

            var rt = new FetchTokenRequestType { Version = Properties.ServiceVersion, SecretID = secretKey.ToString() };

            var res = service.FetchToken(ref r.RequesterCredentials, rt);
            if (res.Errors == null) return res.Ack != AckCodeType.Success ? "" : res.Any.First().InnerText;
            foreach (var e in res.Errors)
            {
                //Log error
            }

            return res.Ack != AckCodeType.Success ? "" : res.Any.First().InnerText;
        }

        /// <summary>
        /// Link to authorise account access
        /// </summary>
        /// <param name="secretKey">GUID for use as the secret key</param>
        /// <returns></returns>
        public string AuthoriseAccountLink(Guid secretKey)
        {
            var ebaySignInUrl = "https://signin.ebay.com/ws/eBayISAPI.dll?SignIn&runame=" + Properties.RunName
                                + "&sid=" + secretKey;
            return ebaySignInUrl;
        }
    }
}
