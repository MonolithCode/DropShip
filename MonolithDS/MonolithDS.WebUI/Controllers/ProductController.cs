using System.Web.Mvc;
using MonolithDS.Domain.Ebay;

namespace MonolithDS.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IEbayManagementRepository _repository;
        public int PageSize = 10;
        public ProductController(IEbayManagementRepository productRepository)
        {
            _repository = productRepository;
        }
        // GET: Product
        public ViewResult List(int page = 1)
        {
            return View(_repository.CreatListingViewModel(page));
        }
    }
}