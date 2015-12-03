using System.Linq;
using System.Web.Mvc;
using MonolithDS.Domain.Ebay;

namespace MonolithDS.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IEbayManagementRepository _repository;
        public NavController(IEbayManagementRepository repository)
        {
            _repository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var categories = _repository.GetEbayListings().Select(x => x.Name).Distinct();
            return PartialView(categories);
        }
    }
}