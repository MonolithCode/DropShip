using EbayModule.Extensions;

namespace EbayModule.view
{
    public interface IEbayProductManagement
    {
        bool UpdateListing(EbayListingUpdateRequest request);
    }
}
