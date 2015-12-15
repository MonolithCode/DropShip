using System;
using System.Diagnostics;
using System.Linq;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.Error;
using EbayModule.view;

namespace EbayModule
{
    public class EbaySecurity : BaseProcedures, IEbaySecurity
    {
        private readonly IEbayErrorLogger _logger;

        public EbaySecurity(IEbayProperties properties, IEbayErrorLogger logger) : base (properties)
        {
            if (properties == null){throw new NotImplementedException("IEbayProperties");}
            if (logger == null){throw new NotImplementedException("IEbayErrorLogger");}

            _logger = logger;
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

            var rt = new FetchTokenRequestType { Version = Properties.ServiceVersion, SecretID = secretKey.ToString() };

            var res = service.FetchToken(ref r.RequesterCredentials, rt);
            if (res.Errors == null) return res.Ack != AckCodeType.Success ? string.Empty : res.Any.First().InnerText;
            foreach (var e in res.Errors)
            {
                _logger.WriteToLog(e, EventLogEntryType.Error);
            }

            return res.Ack != AckCodeType.Success ? string.Empty : res.Any.First().InnerText;
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
