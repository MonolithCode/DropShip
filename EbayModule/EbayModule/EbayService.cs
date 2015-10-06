using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class EbayService : BaseProcedures, IEbayService
    {
        public IEbaySecurity Security { get; private set; }
        public IEbaySelling Sales { get; private set; }

        public IEbayProperties SystemProperties
        {
            get { return Properties; }
        }
            
        public Modes Mode { 
            get { return Properties.Mode; }
            set { Properties.Mode = value; }
        }

        /// <summary>
        /// Setup the service
        /// </summary>
        public EbayService(IEbayProperties properties)
            : base(properties)
        {
            Security = new EbaySecurity(Properties);
            Sales = new EbaySelling(Properties);
        }

        /// <summary>
        /// Get current eBay categories - All of them
        /// </summary>
        /// <returns></returns>
        public GetCategoriesResponseType GetEbayCategories()
        {
            var service = EbayServiceContext(ServiceCallType.GetCategories);
            var req = new GetCategoriesRequest
            {
                RequesterCredentials = Properties.EbayCredentials
            };

            var reqType = new GetCategoriesRequestType
            {
                CategorySiteID = "0"
            };
            SetupRequestType<GetCategoriesRequestType>(reqType);

            var res = service.GetCategories(ref req.RequesterCredentials, reqType);
            return res;
            //return (res.Ack == AckCodeType.Success || res.Ack == AckCodeType.Warning);
        }
    }
}
