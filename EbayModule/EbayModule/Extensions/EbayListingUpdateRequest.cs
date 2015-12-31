using EbayModule.eBaySvc;
using EbayModule.view;

namespace EbayModule.Extensions
{
    public class EbayListingUpdateRequest : IEbayListingUpdateRequest
    {
        public string ItemId { get { return RequestType.ItemID; } set { RequestType.ItemID = value; } }
        public CompleteSaleRequestType RequestType { get; private set; }

        /// <summary>
        /// CompleteSaleRequestType Extension, to be submitted to UpdateOrder command
        /// </summary>
        /// <param name="itemId">Item to update</param>
        public EbayListingUpdateRequest(string itemId)
        {
            RequestType = new CompleteSaleRequestType {ItemID = itemId};
        }

        /// <summary>
        /// CompleteSaleRequestType Extension, to be submitted to UpdateOrder command
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shipped"></param>
        public EbayListingUpdateRequest(string itemId, bool shipped)
        {
            RequestType = new CompleteSaleRequestType {ItemID = itemId};
            MarkAsShipped(shipped);
        }

        /// <summary>
        /// Product shipped status
        /// </summary>
        /// <param name="setting">True or false</param>
        public void MarkAsShipped(bool setting = true)
        {
            RequestType.ShippedSpecified = true;
            RequestType.Shipped = setting;
        }

        public void UpdateImages()
        {
            
        }

        public void Mark()
        {
            
        }


        //public CompleteSaleResponseType Submit()
        //{
        //    var service = CoreProcedures.EbayServiceContext(ServiceCallType.CompleteSale);
        //    CoreProcedures.SetupRequestType<GetOrdersRequestType>(this);
        //    var credentials = CoreProcedures.Credentials();
        //    var apicall = service.CompleteSale(ref credentials, this);
        //    if (apicall.Errors != null)
        //    {
        //        foreach (var e in apicall.Errors.ToArray())
        //        {
        //            //Log errors
        //        }
        //    }
        //    if ((apicall.Ack == AckCodeType.Success || apicall.Ack == AckCodeType.Warning))
        //    {
        //        //Log Success
        //        return apicall;
        //    }
        //    return null;
        //}

    }
}
