namespace MonlithDS.DAL.Models
{
    public partial class EbayListing
    {
        public MonolithDS.Domain.Ebay.EbayListing ToDomainObject()
        {
            return new MonolithDS.Domain.Ebay.EbayListing
            {
                Name
            };
        }
    }
}
