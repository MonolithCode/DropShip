using System;
using System.Diagnostics;
using System.Linq;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.Error;
using EbayModule.Extensions;
using EbayModule.view;

namespace EbayModule
{
    public class EbayProductManagement : BaseProcedures, IEbayProductManagement
    {
        public IEbayImageManagement ImageManager { get; }
        private readonly IEbayErrorLogger _logger;

        public EbayProductManagement(IEbayProperties properties,IEbayImageManagement itemManagement, IEbayErrorLogger logger)
            : base(properties)
        {
            if (properties == null){
                throw new NotImplementedException("IEbayProperties");
            }
            if (itemManagement == null){
                throw new NotImplementedException("IEbayImageManagement");
            }
            if (logger == null){
                throw new NotImplementedException("ILogger");
            }

            ImageManager = itemManagement;
            _logger = logger;
        }

        /// <summary>
        /// Submit an update to an Item
        /// </summary>
        /// <param name="request">Request construct to submit</param>
        /// <returns></returns>
        public bool UpdateListing(EbayListingUpdateRequest request)
        {
            var service = EbayServiceContext(ServiceCallType.CompleteSale);
            var req = request.RequestType;
            SetupRequestType<CompleteSaleRequestType>(req);
            var credentials = Properties.EbayCredentials;
            var apicall = service.CompleteSale(ref credentials, req);
            if (apicall.Errors == null)
                return (apicall.Ack == AckCodeType.Success || apicall.Ack == AckCodeType.Warning);
            foreach (var e in apicall.Errors.ToArray())
            {
                _logger.WriteToLog(e, EventLogEntryType.Error);
            }
            return (apicall.Ack == AckCodeType.Success || apicall.Ack == AckCodeType.Warning);
        }

        /// <summary>
        /// Uploads a listing to Ebay
        /// </summary>
        /// <param name="itemToAdd">FixedPriceItem Request type - includes all submission detials for the request</param>
        public void AddListing(AddFixedPriceItemRequestType itemToAdd)
        {
            //var request = new AddFixedPriceItemRequest {RequesterCredentials = Properties.EbayCredentials};
            var service = EbayServiceContext(ServiceCallType.AddFixedPriceItem);
            var cred = Properties.EbayCredentials;
            //itemToAdd.Item.Site = SiteCodeType.UK;

            //Can error
            try
            {
                service.AddFixedPriceItem(ref cred, itemToAdd);
            }
            catch (Exception  ex)
            {

                throw;
            }
            
        }

    }
}
