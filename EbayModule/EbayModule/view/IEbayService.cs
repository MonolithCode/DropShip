using EbayModule.eBaySvc;
using EbayModule.enums;

namespace EbayModule.view
{
    public interface IEbayService
    {   
        Modes Mode { get; set; }
        IEbaySecurity Security { get; }
        IEbayProperties SystemProperties { get; }
        IEbaySelling Sales { get; }

        GetCategoriesResponseType GetEbayCategories();
    }
}