using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class EbayService : EbayServiceBase, IEbayService
    {
        public string AppId { get; private set; }
        public string DevId { get; private set; }
        public string AuthCert { get; private set; }
        public string Token { get; private set; }
        public string RunName { get; private set; }
        public string SandboxToken { get; private set; }

        public string SigninUrl { get { return "https://api.ebay.com/wsapi"; } }
        public string SandboxSigninUrl { get { return "https://api.sandbox.ebay.com/wsapi"; } }
        public string ServiceVersion {  get { return "927"; } }

        public Modes Mode { get; set; }

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
            AppId = appid;
            DevId = devid;
            AuthCert = authCert;
            Token = token;
            RunName = runname;
            SandboxToken = sandboxToken;
            Mode = mode;
        }

        /// <summary>
        /// Get current eBay categories
        /// </summary>
        /// <returns></returns>
        public GetCategoriesResponseType GetEbayCategories()
        {
            const string callname = "GetCategories";
            var endpoint = SigninUrl + "?callname=" + callname +
                                    "&appid=" + AppId +
                                    "&version=" + ServiceVersion +
                                    "&routing=default";
            //&siteid=3 - UK
            var service = new eBayAPIInterfaceClient("eBayAPI", endpoint);
            var req = new GetCategoriesRequest
            {
                RequesterCredentials = new CustomSecurityHeaderType
                {
                    Credentials =
                        new UserIdPasswordType
                        {
                            AppId = AppId,
                            DevId = DevId,
                            AuthCert = AuthCert
                        },
                    eBayAuthToken = Token
                }
            };

            var detailLevels = new DetailLevelCodeType[1];
            detailLevels[0] = DetailLevelCodeType.ReturnAll;

            var reqType = new GetCategoriesRequestType
            {
                Version = ServiceVersion,
                WarningLevel = WarningLevelCodeType.Low,
                DetailLevel = detailLevels,

                CategorySiteID = "0"
            };


            var res = service.GetCategories(ref req.RequesterCredentials, reqType);
            return res;
            //return (res.Ack == AckCodeType.Success || res.Ack == AckCodeType.Warning);
        }
    


}
}
