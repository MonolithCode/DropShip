namespace MonlithDS.DAL.Models
{
    public sealed partial class EbayListing
    {
        public MonolithDS.Domain.Ebay.EbayListing ToDomainObject()
        {
            return new MonolithDS.Domain.Ebay.EbayListing
            {
                EbayListingId = this.EbayListingID,
                Name =  this.Title,
                Price = this.Price
            };
        }
    }
}
