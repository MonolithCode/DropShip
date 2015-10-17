using System.Linq;
using System.Web.Mvc;
using MonolithDS.Domain.Ebay;

namespace MonolithDS.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IEbayManagementRepository _repository;
        public NavController(IEbayManagementRepository repository)
        {
            _repository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var categories = _repository.GetEbayListings().Select(x => x.Price).Distinct();
            return PartialView(categories);
        }
    }
}