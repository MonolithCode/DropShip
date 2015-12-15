using System;
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
            if (baseProperties == null) { throw new NotImplementedException("IEbayProperties"); }
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
        /// Adds the default requirements of ebay requests so they dont need to be filled in each time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestType"></param>
        /// <returns></returns>
        public void SetupRequestType<T>(AbstractRequestType requestType)
        {
            requestType.Version = Properties.ServiceVersion;
            requestType.DetailLevel = new[]
            {
                DetailLevelCodeType.ReturnAll
            };
            requestType.WarningLevel = WarningLevelCodeType.Low;
            requestType.WarningLevelSpecified = true;
        }
    }
}
