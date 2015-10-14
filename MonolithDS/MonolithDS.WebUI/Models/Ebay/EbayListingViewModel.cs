using System.Collections.Generic;

namespace MonolithDS.WebUI.Models.Ebay
{
    public class EbayListingViewModel
    {
        public IEnumerable<Domain.Ebay.EbayListing> EbayListings { get; set; }
        public PagingInfo PageInfo { get; set; }
    }
}
