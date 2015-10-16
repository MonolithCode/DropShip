using System.Collections.Generic;
using MonolithDS.Domain.Ebay.ProductManagement;

namespace MonolithDS.Domain.Ebay
{
    public interface IEbayManagementRepository
    {
        IEbayBaseRepository EbayCore { get; }
        IEnumerable<EbayListing> GetEbayListings();
        EbayListingViewModel CreatListingViewModel(int page);
    }
}