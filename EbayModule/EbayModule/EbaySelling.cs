using System;
using System.Diagnostics;
using System.Linq;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.Error;
using EbayModule.view;

namespace EbayModule
{
    public class EbaySelling : BaseProcedures, IEbaySelling
    {
        public IEbayProductManagement ProductManagement { get; private set; }
        private readonly IEbayErrorLogger _logger;

        public EbaySelling(IEbayProperties properties, IEbayProductManagement productManagement, IEbayErrorLogger logger) : base (properties)
        {
            if (properties == null)         { throw new NotImplementedException("IEbayProperties");}
            if (productManagement == null)  { throw new NotImplementedException("IEbayProductManagement");}
            if (logger == null)             { throw new NotImplementedException("IEbayErrorLogger");}

            ProductManagement = productManagement;
            _logger = logger;
        }

        /// <summary>
        /// Returns the order information for the listed orderIDS
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        public GetOrdersResponseType GetOrderDetails(string[] orderIds)
        {   
            var service = EbayServiceContext(ServiceCallType.GetOrders);
            var request = new GetOrdersRequestType
            {
                OrderIDArray = orderIds
            };
            SetupRequestType<GetOrdersRequestType>(request);
            var credentials = Properties.EbayCredentials;
            var apicall = service.GetOrders(ref credentials, request);
            if (apicall.Errors != null)
            {
                foreach (var e in apicall.Errors.ToArray())
                {
                    _logger.WriteToLog(e, EventLogEntryType.Error);
                }
            }
            if ((apicall.Ack == AckCodeType.Success || apicall.Ack == AckCodeType.Warning))
            {
                return apicall;
            }
            return null;
        }

        /// <summary>
        /// Returns sales for the specified date range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public GetSellerTransactionsResponseType GetSales(DateTime from, DateTime to, int pageNumber = 1)
        {
            var service = EbayServiceContext(ServiceCallType.GetSellerTransactions);

            var request = new GetSellerTransactionsRequestType
            {
                ModTimeFromSpecified = true,
                ModTimeFrom = from,
                ModTimeToSpecified = true,
                ModTimeTo = to,
                Pagination = new PaginationType
                {
                    EntriesPerPage = Properties.EntriesPerRequest,
                    EntriesPerPageSpecified = true,
                    PageNumber = pageNumber,
                    PageNumberSpecified = true
                },
                Platform = TransactionPlatformCodeType.eBay,
                PlatformSpecified = true
            };
            SetupRequestType<GetSellerTransactionsRequestType>(request);
            var credentials = Properties.EbayCredentials;
            var apicall = service.GetSellerTransactions(ref credentials, request);
            if (apicall.Errors != null)
            {
                foreach (var e in apicall.Errors.ToArray())
                {
                    _logger.WriteToLog(e, EventLogEntryType.Error);
                }
            }
            if ((apicall.Ack == AckCodeType.Success || apicall.Ack == AckCodeType.Warning))
            {
                return apicall;
            }
            return null;
        }

        /// <summary>
        /// Gets ebay listings - Filtered by order type
        /// </summary>
        /// <param name="orderType">Type of order - sold, awaiting payment etc</param>
        /// <param name="pageNumber">Page number to return. Returns 200 per page</param>
        /// <returns></returns>
        public GetMyeBaySellingResponseType GetMyEbayListings(OrderStatusFilterCodeType orderType, int pageNumber = 1)
        {
            var service = EbayServiceContext(ServiceCallType.GetMyeBaySelling);
            var filter = new ItemListCustomizationType {
                Include = true,
                Pagination = new PaginationType
                {
                    EntriesPerPage = Properties.EntriesPerRequest,
                    EntriesPerPageSpecified = true,
                    PageNumber = pageNumber,
                    PageNumberSpecified = true
                },
                OrderStatusFilter = orderType,
                OrderStatusFilterSpecified = true
            };
            var request = new GetMyeBaySellingRequestType {
                ActiveList = filter,
                SoldList = filter
            };
            request.ActiveList.Include = true;
            SetupRequestType<GetMyeBaySellingRequestType>(request);
            var credentials = Properties.EbayCredentials;
            var apicall = service.GetMyeBaySelling(ref credentials, request);
            if (apicall.Errors != null)
            {
                foreach (var e in apicall.Errors.ToArray())
                {
                    _logger.WriteToLog(e, EventLogEntryType.Error);
                }
            }
            if ((apicall.Ack == AckCodeType.Success || apicall.Ack == AckCodeType.Warning))
            {
                return apicall;
            }
            return null;
        }
    }
}
