using System;
using System.Linq;
using System.Web.Mvc;
using MonolithDS.Domain.Ebay;
using MonolithDS.Domain.Shopping.Cart;
using MonolithDS.Domain.Shopping.Shipping;

namespace MonolithDS.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IEbayManagementRepository _repository;

        public CartController(IEbayManagementRepository productRepository)
        {
            _repository = productRepository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(
                new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public RedirectToRouteResult AddToCart(Cart cart, string EbayListingId, string returnUrl)
        {
            Guid guidID = Guid.Parse(EbayListingId);
            EbayListing listing = _repository.GetEbayListings().FirstOrDefault(x => x.EbayListingId == guidID);
            if (listing != null)
            {
                cart.AddItem(listing, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, string EbayListingId, string returnUrl)
        {
            Guid guidID = Guid.Parse(EbayListingId);
            EbayListing listing = _repository.GetEbayListings().FirstOrDefault(x => x.EbayListingId == guidID);
            if (listing != null)
            {
                cart.RemoveLine(listing);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}