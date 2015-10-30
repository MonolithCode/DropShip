using EbayModule.eBaySvc;
using EbayModule.enums;
using MonlithDS.DAL.Repositories.Ebay;
using MonolithDS.Domain.Ebay;
using Ninject.Modules;

namespace MonolithDS.DependancyResolution
{
    public class EbayModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEbayManagementRepository>().To<EbayManagementRepositroy>();
            Bind<IEbayBaseRepository>().To<EbayBaseRepository>()
                .WithConstructorArgument("mode", Modes.Live)
                .WithConstructorArgument("siteCode", SiteCodeType.UK);

            
        }
    }
}
