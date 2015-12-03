using MonolithDS.Domain;
using MonolithDS.Domain.Paging;

namespace MonlithDS.DAL.Repositories.Navigation
{
    public class NavigationRepository : BaseRepository, INavigationRepository
    {

        public NavigationRepository(IUnitOfWork context): base(context)
        {
            
        }

        public System.Collections.Generic.IEnumerable<MenuItem> GetMenuItems(MenuType menu)
        {
            throw new System.NotImplementedException();
        }

        public MonolithDS.Domain.Ebay.ProductManagement.EbayListingViewModel CreatListingViewModel(string pricerange, int page)
        {
            throw new System.NotImplementedException();
        }
    }
}