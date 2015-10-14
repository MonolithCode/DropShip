using EbayModule;
using EbayModule.view;
using Ninject.Modules;

namespace MonlithDS.DAL
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IEbayProperties>().To<EbayProperties>();
        }
    }
}
