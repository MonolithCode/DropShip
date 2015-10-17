using MonolithDS.Domain.Ebay;

namespace MonolithDS.Domain.Shopping.Cart
{
    public class CartLine
    {
        public EbayListing EbayListing { get; set; }
        public int Quantity { get; set; }
    }
}
