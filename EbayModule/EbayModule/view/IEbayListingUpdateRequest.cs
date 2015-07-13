namespace EbayModule.view
{
    public interface IEbayListingUpdateRequest
    {
        string ItemId { get; }
        void MarkAsShipped();
        
    }
}