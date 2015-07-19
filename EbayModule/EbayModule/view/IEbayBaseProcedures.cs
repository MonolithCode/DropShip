using EbayModule.eBaySvc;
using EbayModule.enums;

namespace EbayModule.view
{
    public interface IEbayBaseProcedures
    {
        eBayAPIInterfaceClient EbayServiceContext(ServiceCallType callName);
        void SetupRequestType<T>(AbstractRequestType requestType);
    }
}