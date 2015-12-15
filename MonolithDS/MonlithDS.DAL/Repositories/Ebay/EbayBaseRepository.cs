using System;
using System.Linq;
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
            if (context == null) { throw new NotImplementedException("IUnitOfWork"); }

            _mode = mode;
            _siteCode = siteCode;
        }

        public IEbayProperties EbayProperties()
        {
            return Context.EbayAPI.First().ToDomainObject(_mode, _siteCode);
        }
    }
}
