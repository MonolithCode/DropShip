using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;

namespace EbayModule
{
    public class EbayProperties : IEbayProperties
    {
        public string AppId { get; private set; }
        public string DevId { get; private set; }
        public string AuthCert { get; private set; }
        public string Token { get; private set; }
        public string RunName { get; private set; }
        public string SandboxToken { get; private set; }
        public string ServiceVersion { get { return "927"; } }
        public int EntriesPerRequest { get; set; }
        public SiteCodeType SiteId { get; set; }
        public WarningLevelCodeType WarningLevel { get; set; }
 
        public string SigninUrl
        {
            get
            {
                switch (Mode)
                {
                    case Modes.Live:
                        return "https://api.ebay.com/wsapi";
                    case Modes.Sandbox:
                        return "https://api.sandbox.ebay.com/wsapi";
                    default:
                        return "https://api.ebay.com/wsapi";
                }
            }
        }

        /// <summary>
        /// Service URL for image uploads
        /// </summary>
        public string EpsServerUrl
        {
            get
            {
                switch (Mode)
                {
                    case Modes.Live:
                        return "https://api.ebay.com/ws/api.dll";
                    case Modes.Sandbox:
                        return "https://api.sandbox.ebay.com/ws/api.dll";
                    default:
                        return "https://api.ebay.com/ws/api.dll";
                }
            }
        }
            
        /// <summary>
        /// Gets default credentials for use in service calls
        /// </summary>
        /// <returns></returns>
        public CustomSecurityHeaderType EbayCredentials
        {
            get
            {
                return new CustomSecurityHeaderType
                {
                    Credentials =
                        new UserIdPasswordType
                        {
                            AppId = AppId,
                            DevId = DevId,
                            AuthCert = AuthCert
                        },
                    eBayAuthToken = Token
                };
            }
        }

        /// <summary>
        /// Service Mode (live/test)
        /// </summary>
        public Modes Mode { get; set; }

        /// <param name="appid">Application ID</param>
        /// <param name="devid"> DevID</param>
        /// <param name="authCert"> CertID</param>
        /// <param name="token">Access token</param>
        /// <param name="runname">App Name</param>
        /// <param name="sandboxToken">Sandbox Token</param>
        /// <param name="mode">Live/Test Environment</param>
        /// <param name="siteCode">Site code for ebay</param>
        public EbayProperties(string appid, string devid, string authCert, string token, 
            string runname, string sandboxToken, Modes mode, SiteCodeType siteCode)
        {
            SiteId = siteCode;
            AppId = appid;
            DevId = devid;
            AuthCert = authCert;
            Token = token;
            RunName = runname;
            SandboxToken = sandboxToken;
            Mode = mode;
            WarningLevel = WarningLevelCodeType.Low;
            EntriesPerRequest = 200;
        }
    }
}
