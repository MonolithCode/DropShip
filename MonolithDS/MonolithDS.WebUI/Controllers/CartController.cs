using System;
using System.Linq;
using System.Web.Mvc;
using MonolithDS.Domain.Ebay;
using MonolithDS.Domain.Shopping.Cart;

namespace MonolithDS.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IEbayManagementRepository _repository;

        public CartController(IEbayManagementRepository productRepository)
        {
            _repository = productRepository;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(
                new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(string EbayListingId, string returnUrl)
        {
            Guid guidID = Guid.Parse(EbayListingId);
            EbayListing listing = _repository.GetEbayListings().FirstOrDefault(x => x.EbayListingId == guidID);
            if (listing != null)
            {
                GetCart().AddItem(listing, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, Guid productId, string returnUrl)
        {
            EbayListing listing = _repository.GetEbayListings().FirstOrDefault(x => x.EbayListingId == productId);
            if (listing != null)
            {
                cart.RemoveLine(listing);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }
            return (Cart) Session["Cart"];
        }
    }
}