using System.Web.Mvc;
using MonolithDS.Domain.Abstract;

namespace MonolithDS.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }
        // GET: Product
        public ViewResult List()
        {
            return View(_repository.Products);
        }
    }
}