using EbayModule;
using EbayModule.eBaySvc;
using EbayModule.enums;

namespace MonlithDS.DAL.Models
{
    public partial class EbayAPI
    {
        public EbayProperties ToDomainObject(Modes mode, SiteCodeType code)
        {
            return new EbayProperties(AppID, DevID, AuthCert, Token, Runame, SandBoxToken, mode, code);
        }
    }
}
