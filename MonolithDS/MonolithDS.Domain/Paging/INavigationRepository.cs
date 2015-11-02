using System.Collections.Generic;
using MonolithDS.Domain.Ebay;
using MonolithDS.Domain.Ebay.ProductManagement;

namespace MonolithDS.Domain.Paging
{
    public interface INavigationRepository
    {
        IEnumerable<MenuItem> GetMenuItems();
        EbayListingViewModel CreatListingViewModel(string pricerange, int page); 
    }
}