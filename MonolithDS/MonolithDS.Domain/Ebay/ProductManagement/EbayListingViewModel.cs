using System.Collections.Generic;
using MonolithDS.Domain.Paging;

namespace MonolithDS.Domain.Ebay.ProductManagement
{
    public class EbayListingViewModel
    {
        public IEnumerable<EbayListing> EbayListings { get; set; }
        public PagingInfo PageInfo { get; set; }
    }
}
