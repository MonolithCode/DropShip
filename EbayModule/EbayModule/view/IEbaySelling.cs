using System;
using EbayModule.eBaySvc;

namespace EbayModule.view
{
    public interface IEbaySelling
    {
        IEbayProductManagement ProductManagement { get; }
        GetMyeBaySellingResponseType GetMyEbayListings(OrderStatusFilterCodeType orderType, int pageNumber=1);
        GetSellerTransactionsResponseType GetSales(DateTime from, DateTime to);
        GetOrdersResponseType GetOrderDetails(string[] orderIds);
    }
}