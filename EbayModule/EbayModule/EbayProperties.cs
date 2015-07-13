
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
        public SiteCodeType SiteId { get; set; }

        public WarningLevelCodeType WarningLevel { get; set; }

        public string SigninUrl {
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

        public string ServiceVersion { get { return "927"; } }

        public Modes Mode { get; set; }

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
        }

    }
}
