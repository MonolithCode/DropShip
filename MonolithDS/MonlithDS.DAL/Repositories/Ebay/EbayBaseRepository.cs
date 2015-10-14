using System.Linq;
using EbayModule;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.view;
using MonolithDS.Domain;
using MonolithDS.Domain.Ebay;

namespace MonlithDS.DAL.Repositories.Ebay
{
    public class EbayBaseRepository : BaseRepository, IEbayBaseRepository
    {
        private readonly Modes _mode;
        private readonly SiteCodeType _siteCode;

        public EbayBaseRepository(IUnitOfWork context, Modes mode, SiteCodeType siteCode)
            : base(context)
        {
            _mode = mode;
            _siteCode = siteCode;
        }

        public IEbayProperties EbayProperties()
        {
            return (from p in Context.EbayAPI.ToList()
                select new EbayProperties(p.AppID, p.DevID, p.AuthCert, p.Token, p.Runame, p.SandBoxToken,
                    _mode, _siteCode)).FirstOrDefault();
        }
    }
}
