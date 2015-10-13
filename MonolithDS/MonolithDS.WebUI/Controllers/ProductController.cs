using System.Web.Mvc;
using MonolithDS.Domain.Abstract;
using MonolithDS.Domain.Ebay;

namespace MonolithDS.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IEbayManagementRepository _repository;
        public ProductController(IEbayManagementRepository productRepository)
        {
            _repository = productRepository;
        }
        // GET: Product
        public ViewResult List()
        {
            return View(_repository.GetEbayListings());
        }
    }
}