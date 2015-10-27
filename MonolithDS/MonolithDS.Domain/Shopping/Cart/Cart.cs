using System.Collections.Generic;
using System.Linq;
using MonolithDS.Domain.Ebay;

namespace MonolithDS.Domain.Shopping.Cart
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection;

        public Cart()
        {
            _lineCollection = new List<CartLine>();
        }

        public void AddItem(EbayListing item, int quantity)
        {
            var listing = _lineCollection.FirstOrDefault(x => x.EbayListing.EbayListingId == item.EbayListingId);
            if (listing == null)
            {
                _lineCollection.Add(new CartLine { EbayListing = item, Quantity = quantity });
            }
            else
            {
                listing.Quantity += quantity;
            }
        }

        public void RemoveLine(EbayListing product)
        {
            _lineCollection.RemoveAll(p => p.EbayListing.EbayListingId == product.EbayListingId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(p => p.EbayListing.Price * p.Quantity);
        }

        public IEnumerable<CartLine> Lines
        {
            get { return _lineCollection; }
        }

        public void Clear()
        {
            _lineCollection.Clear();
        }
    }
}
