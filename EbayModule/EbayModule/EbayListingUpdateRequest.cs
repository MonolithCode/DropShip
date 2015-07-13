using System.Linq;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class EbayListingUpdateRequest : CompleteSaleRequestType, IEbayListingUpdateRequest
    {
        internal IEbayProperties Properties { get; private set; }
        internal IEbayBaseProcedures CoreProcedures { get; private set; }
        public string ItemId { get; private set; }


        public EbayListingUpdateRequest(string itemId, IEbayProperties properties, IEbayBaseProcedures coreProcedures)
        {
            Properties = properties;
            CoreProcedures = coreProcedures;
            CoreProcedures.SetupRequestType<GetOrdersRequestType>(this);
        }

        public void MarkAsShipped()
        {
            this.ShippedSpecified = true;
            this.Shipped = Shipped;
        }

        public CompleteSaleResponseType Submit()
        {
            var service = CoreProcedures.EbayServiceContext(ServiceCallType.CompleteSale);
            CoreProcedures.SetupRequestType<GetOrdersRequestType>(this);
            var credentials = CoreProcedures.Credentials();
            var apicall = service.CompleteSale(ref credentials, this);
            if (apicall.Errors != null)
            {
                foreach (var e in apicall.Errors.ToArray())
                {
                    //Log errors
                }
            }
            if ((apicall.Ack == AckCodeType.Success || apicall.Ack == AckCodeType.Warning))
            {
                //Log Success
                return apicall;
            }
            return null;
        }

    }
}
