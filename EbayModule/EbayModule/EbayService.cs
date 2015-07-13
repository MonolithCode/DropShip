using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class EbayService : IEbayService
    {
        public IEbaySecurity Security { get; private set; }
        public IEbayProperties Properties { get; private set; }
        public IEbayBaseProcedures CoreProcedures { get; private set; }
        public IEbaySelling Sales { get; private set; }

        public Modes Mode { 
            get { return Properties.Mode; }
            set { Properties.Mode = value; }
        }

        /// <summary>
        /// Setup the service
        /// </summary>
        /// <param name="appid">Application ID</param>
        /// <param name="devid"> DevID</param>
        /// <param name="authCert"> CertID</param>
        /// <param name="token">Access token</param>
        /// <param name="runname">App Name</param>
        /// <param name="sandboxToken">Sandbox Token</param>
        /// <param name="mode">Live/Test Environment</param>
        public EbayService(string appid, string devid, string authCert, string token,
            string runname, string sandboxToken, Modes mode)
        {
            Properties = new EbayProperties(appid, devid, authCert, token, runname, sandboxToken, mode, SiteCodeType.UK);
            CoreProcedures = new BaseProcedures(Properties);
            CoreProcedures = new BaseProcedures(Properties);
            Security = new EbaySecurity(Properties, CoreProcedures);
            Sales = new EbaySelling(Properties, CoreProcedures);
        }

        /// <summary>
        /// Get current eBay categories
        /// </summary>
        /// <returns></returns>
        public GetCategoriesResponseType GetEbayCategories()
        {
            var service = CoreProcedures.EbayServiceContext(ServiceCallType.GetCategories);
            var req = new GetCategoriesRequest
            {
                RequesterCredentials = CoreProcedures.Credentials()
            };

            var reqType = new GetCategoriesRequestType
            {
                CategorySiteID = "0"
            };
            CoreProcedures.SetupRequestType<GetCategoriesRequestType>(reqType);

            var res = service.GetCategories(ref req.RequesterCredentials, reqType);
            return res;
            //return (res.Ack == AckCodeType.Success || res.Ack == AckCodeType.Warning);
        }
    }
}
