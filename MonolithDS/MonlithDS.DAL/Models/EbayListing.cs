namespace MonlithDS.DAL.Models
{
    public sealed partial class EbayListing
    {
        public MonolithDS.Domain.Ebay.EbayListing ToDomainObject()
        {
            return new MonolithDS.Domain.Ebay.EbayListing
            {
                EbayListingId = EbayListingID,
                Name =  Title,
                Price = Price
            };
        }

        public void FromDomainObject(MonolithDS.Domain.Ebay.EbayListing ebayListing)
        {
            EbayListingID = ebayListing.EbayListingId;
            Title = ebayListing.Name;
            Price = ebayListing.Price;
        }
    }
}
