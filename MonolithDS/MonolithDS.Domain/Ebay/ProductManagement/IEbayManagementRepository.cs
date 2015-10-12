using System.Collections.Generic;

namespace MonolithDS.Domain.Ebay
{
    public interface IEbayManagementRepository
    {
        List<EbayListing> GetEbayListings();
    }
}