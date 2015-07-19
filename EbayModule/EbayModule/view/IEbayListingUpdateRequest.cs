namespace EbayModule.view
{
    public interface IEbayListingUpdateRequest
    {
        string ItemId { get; set; }
        void MarkAsShipped(bool shipped = true);
        
    }
}