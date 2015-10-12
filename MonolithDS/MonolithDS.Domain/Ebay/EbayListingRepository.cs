using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonlithDS.DAL.Models;
using MonolithDS.Domain.Abstract;

namespace MonolithDS.Domain.Ebay
{
    public class EbayListingRepository : IEbayListingRepository
    {
        private DSEntities context;
        public EbayListingRepository()
        {
            
        }

        public IEnumerable<MonlithDS.DAL.Models.EbayListing> EBayListings
        {
            get { throw new NotImplementedException(); }
        }
    }
}
