using System.Collections.Generic;
using MonolithDS.Domain.Ebay.ProductManagement;

namespace MonolithDS.Domain.Ebay
{
    public interface IEbayManagementRepository
    {
        IEbayBaseRepository EbayCore { get; }
        List<EbayListing> GetEbayListings();
        EbayListingViewModel CreatListingViewModel(int page);
    }
}