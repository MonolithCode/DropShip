using System;
using System.Linq;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.Extensions;
using EbayModule.view;

namespace EbayModule
{
    public class EbayProductManagement : IEbayProductManagement
    {
        internal IEbayBaseProcedures CoreProcedures { get; private set; }
        internal IEbayProperties Properties { get; private set; }

        public EbayProductManagement(IEbayProperties properties, IEbayBaseProcedures coreProcedures)
        {
            if (properties == null || coreProcedures == null)
            {
                throw new NotImplementedException();
            }

            Properties = properties;
            CoreProcedures = coreProcedures;
        }

        /// <summary>
        /// Submit an update to an Item
        /// </summary>
        /// <param name="request">Request construct to submit</param>
        /// <returns></returns>
        public bool UpdateListing(EbayListingUpdateRequest request)
        {
            var service = CoreProcedures.EbayServiceContext(ServiceCallType.CompleteSale);
            var req = request.RequestType;
            CoreProcedures.SetupRequestType<CompleteSaleRequestType>(req);
            var credentials = Properties.EbayCredentials;
            var apicall = service.CompleteSale(ref credentials, req);
            if (apicall.Errors != null)
            {
                foreach (var e in apicall.Errors.ToArray())
                {
                    //Log errors
                }
            }
            return (apicall.Ack == AckCodeType.Success || apicall.Ack == AckCodeType.Warning);
        }

    }
}
