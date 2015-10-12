using System.Linq;
using System.Runtime.Remoting.Contexts;
using MonolithDS.Domain;
using MonolithDS.Domain.Ebay;

namespace MonlithDS.DAL.Repositories.Ebay
{
    public class EbayManagementRepositroy : BaseRepository, IEbayManagementRepository
    {
        public EbayManagementRepositroy(IUnitOfWork context) : base(context)
        {
        }

        public System.Collections.Generic.List<EbayListing> GetEbayListings()
        {
            return Context.EbayListing;
        }
    }
}
