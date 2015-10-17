using System.Collections.Generic;
using System.Linq;
using MonolithDS.Domain;
using MonolithDS.Domain.Ebay;
using MonolithDS.Domain.Ebay.ProductManagement;
using MonolithDS.Domain.Paging;

namespace MonlithDS.DAL.Repositories.Ebay
{
    public class EbayManagementRepositroy : BaseRepository, IEbayManagementRepository
    {

        public IEbayBaseRepository EbayCore { get; private set; }

        public EbayManagementRepositroy(IUnitOfWork context, IEbayBaseRepository ebayCore) : base(context)
        {
            EbayCore = ebayCore;
        }

        public IEnumerable<EbayListing> GetEbayListings()
        {
            var data = (from e in Context.EbayListing
                        select e)
                        .AsEnumerable()
                        .Select(x=>x.ToDomainObject());

            return data;
        }

        /// <summary>
        /// Creates the model
        /// </summary>
        /// <param name="pricerange"></param>
        /// <param name="page">Page of listings to view</param>
        /// <returns></returns>
        public EbayListingViewModel CreatListingViewModel(string pricerange, int page)
        {
            var ebayListings = GetEbayListings().Where(x => pricerange == null || 
                x.Price > (pricerange == "High" ? 15.00m : 0.00m) ||
                x.Price < (pricerange == "Low" ? 15.00m : 0.00m)).OrderBy(x => x.Price);
            return new EbayListingViewModel
            {
                EbayListings = ebayListings.Skip((page - 1)*5).Take(5),
                PageInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = 5,
                    TotalItems = ebayListings.Count()
                }, PriceRange = pricerange
            };
        }
    }
}
