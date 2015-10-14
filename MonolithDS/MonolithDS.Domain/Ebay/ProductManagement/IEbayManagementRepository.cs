using System.Collections.Generic;

namespace MonolithDS.Domain.Ebay
{
    public interface IEbayManagementRepository
    {
        IEbayBaseRepository EbayCore { get; }
        List<EbayListing> GetEbayListings();
    }
}