using EbayModule.eBaySvc;
using EbayModule.enums;

namespace EbayModule.view   
{
    public interface IEbayProperties
    {
        string AppId { get; }
        string DevId { get; }
        string AuthCert { get; }
        string Token { get; }
        string RunName { get; }
        string SandboxToken { get; }
        string ServiceVersion { get; }
        string SigninUrl { get; }
        string EpsServerUrl { get; }
        int EntriesPerRequest { get; set; }

        Modes Mode { get; set; }
        WarningLevelCodeType WarningLevel { get; set; }
        SiteCodeType SiteId { get; set; }
        CustomSecurityHeaderType EbayCredentials { get; }

    }
}