using EbayModule.eBaySvc;
using EbayModule.Extensions;

namespace EbayModule.view
{
    public interface IEbayProductManagement
    {
        IEbayImageManagement ImageManager { get; }
        bool UpdateListing(EbayListingUpdateRequest request);
        void AddListing(AddFixedPriceItemRequestType itemToAdd);
    }
}
