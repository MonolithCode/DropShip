using System.Collections.Generic;
using MonlithDS.DAL.Models;

namespace MonolithDS.Domain.Abstract
{
    public interface IEbayListingRepository
    {   
        IEnumerable<EbayListing> EBayListings { get; }
    }
}