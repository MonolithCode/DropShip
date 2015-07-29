using System;
using System.Linq;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class EbaySelling : BaseProcedures, IEbaySelling
    {
        public IEbayProductManagement ProductManagement { get; private set; }

        public EbaySelling(IEbayProperties properties) : base (properties)
        {
            ProductManagement = new EbayProductManagement(properties);
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

        /// <summary>
        /// Returns sales for the specified date range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
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
                    EntriesPerPage = 200,
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

        /// <summary>
        /// Gets active ebay listings - Active and Sold
        /// </summary>
        /// <param name="orderType"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public GetMyeBaySellingResponseType GetMyEbayListings(OrderStatusFilterCodeType orderType, int pageNumber = 1)
        {
            var service = EbayServiceContext(ServiceCallType.GetMyeBaySelling);
            var filter = new ItemListCustomizationType {
                Include = true,
                Pagination = new PaginationType
                {
                    EntriesPerPage = 200,
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
            SetupRequestType<GetMyeBaySellingRequestType>(request);
            var credentials = Properties.EbayCredentials;
            var apicall = service.GetMyeBaySelling(ref credentials, request);
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
