using System.Collections.Generic;
using MonolithDS.Domain.Ebay.ProductManagement;

namespace MonolithDS.Domain.Paging
{
    public interface INavigationRepository
    {
        IEnumerable<MenuItem> GetMenuItems(MenuType menu);
        EbayListingViewModel CreatListingViewModel(string pricerange, int page); 
    }
}