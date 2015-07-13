using EbayModule.eBaySvc;
using EbayModule.enums;

namespace EbayModule.view
{
    public interface IEbayBaseProcedures
    {
        eBayAPIInterfaceClient EbayServiceContext(ServiceCallType callName);
        CustomSecurityHeaderType Credentials();
        T SetupRequestType<T>(AbstractRequestType requestType);
    }
}