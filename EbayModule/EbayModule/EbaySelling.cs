using System;
using System.Linq;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class EbaySelling : IEbaySelling
    {
        public IEbayProductManagement ProductManagement { get; private set; }
        internal IEbayProperties Properties { get; private set; }
        internal IEbayBaseProcedures CoreProcedures { get; private set; }

        public EbaySelling(IEbayProperties properties, IEbayBaseProcedures coreProcedures)
        {
            Properties = properties;
            CoreProcedures = coreProcedures;
            ProductManagement = new EbayProductManagement(properties, CoreProcedures);
        }

        /// <summary>
        /// Returns the order information for the listed orderIDS
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        public GetOrdersResponseType GetOrderDetails(string[] orderIds)
        {   
            var service = CoreProcedures.EbayServiceContext(ServiceCallType.GetOrders);
            var request = new GetOrdersRequestType
            {
                OrderIDArray = orderIds
            };
            CoreProcedures.SetupRequestType<GetOrdersRequestType>(request);
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
        public GetSellerTransactionsResponseType GetSales(DateTime from, DateTime to)
        {
            var service = CoreProcedures.EbayServiceContext(ServiceCallType.GetSellerTransactions);

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
                    PageNumber = 1,
                    PageNumberSpecified = true
                },
                Platform = TransactionPlatformCodeType.eBay,
                PlatformSpecified = true
            };
            CoreProcedures.SetupRequestType<GetSellerTransactionsRequestType>(request);
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
            var service = CoreProcedures.EbayServiceContext(ServiceCallType.GetMyeBaySelling);
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
            CoreProcedures.SetupRequestType<GetMyeBaySellingRequestType>(request);
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
