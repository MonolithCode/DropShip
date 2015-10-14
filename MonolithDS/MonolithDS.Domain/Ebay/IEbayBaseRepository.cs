using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace MonolithDS.Domain.Ebay
{
    public interface IEbayBaseRepository
    {
        IEbayProperties EbayProperties();
    }
}
