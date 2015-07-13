using System;
using System.Globalization;
using System.Linq;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class EbayProductManagement : IEbayProductManagement
    {
        internal IEbayBaseProcedures CoreProcedures { get; private set; }
        internal IEbayProperties Properties { get; private set; }

        public EbayProductManagement(IEbayProperties properties, IEbayBaseProcedures coreProcedures)
        {
            if (properties == null || coreProcedures == null)
            {
                throw new NotImplementedException();
            }

            Properties = properties;
            CoreProcedures = coreProcedures;
        }

        public CompleteSaleResponseType UpdateOrder(CompleteSaleRequestType request)
        {           
            var service = CoreProcedures.EbayServiceContext(ServiceCallType.CompleteSale);
            CoreProcedures.SetupRequestType<GetOrdersRequestType>(request);
            var credentials = CoreProcedures.Credentials();
            var apicall = service.CompleteSale(ref credentials, request);
            if (apicall.Errors != null)
            {
                foreach (var e in apicall.Errors.ToArray())
                {
                    //Log errors
                }
            }
            if ((apicall.Ack == AckCodeType.Success || apicall.Ack == AckCodeType.Warning))
            {
                //Log Success
                return apicall;
            }
            return null;
        }

        
    }
}
