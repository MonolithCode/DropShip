using System.Collections.Generic;
using System.Linq;
using MonolithDS.Domain;
using MonolithDS.Domain.Ebay;

namespace MonlithDS.DAL.Repositories.Ebay
{
    public class EbayManagementRepositroy : BaseRepository, IEbayManagementRepository
    {
        public EbayManagementRepositroy(IUnitOfWork context) : base(context)
        {
        }

        public List<EbayListing> GetEbayListings()
        {
            var data = (from e in Context.EbayListing
                select new EbayListing
                {
                    Name = e.Title,
                    EbayListingId = e.EbayListingID
                }).ToList();

            return data;
        }
    }
}
