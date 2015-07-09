using EbayModule.eBaySvc;
using EbayModule.enums;

namespace EbayModule.view
{
    public interface IEbayService
    {
        string AppId { get;}
        string DevId { get; }
        string AuthCert { get; }
        string Token { get; }
        string RunName { get; }
        string SandboxToken { get; }

        string ServiceVersion { get; }
        string SigninUrl { get; }
        string SandboxSigninUrl { get; }

        Modes Mode { get; set; }

        GetCategoriesResponseType GetEbayCategories();
    }
}