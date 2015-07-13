using System;
using System.CodeDom;
using System.Globalization;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class BaseProcedures : IEbayBaseProcedures
    {
        internal IEbayProperties Properties { get; private set; }

        public BaseProcedures(IEbayProperties baseProperties)
        {
            Properties = baseProperties;
        }

        /// <summary>
        /// Builds the service call
        /// </summary>
        /// <param name="callName">Type of call</param>
        /// <returns></returns>
        public eBayAPIInterfaceClient EbayServiceContext(ServiceCallType callName)
        {
            var endpoint = string.Format("{0}?callname={1}&appid={2}&version={3}&routing=default",
                Properties.SigninUrl, callName, Properties.AppId, Properties.ServiceVersion);

            return new eBayAPIInterfaceClient("eBayAPI", endpoint);
        }

        /// <summary>
        /// Gets default credentials for use in service calls
        /// </summary>
        /// <returns></returns>
        public CustomSecurityHeaderType Credentials()
        {
            return new CustomSecurityHeaderType
            {
                Credentials =
                    new UserIdPasswordType
                    {
                        AppId = Properties.AppId,
                        DevId = Properties.DevId,
                        AuthCert = Properties.AuthCert
                    },
                eBayAuthToken = Properties.Token
            };
        }

        /// <summary>
        /// Adds the default requirements of ebay requests so they dont need to be filled in each time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestType"></param>
        /// <returns></returns>
        public T SetupRequestType<T>(AbstractRequestType requestType)
        {
            requestType.Version = Properties.ServiceVersion;
            requestType.DetailLevel = new[]
            {
                DetailLevelCodeType.ReturnAll
            };
            requestType.WarningLevel = WarningLevelCodeType.Low;
            requestType.WarningLevelSpecified = true;
            return (T)Convert.ChangeType(requestType, typeof(T), CultureInfo.InvariantCulture);
        }
    }
}
