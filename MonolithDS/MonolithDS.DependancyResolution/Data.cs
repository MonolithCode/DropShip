using MonlithDS.DAL.Models;
using MonolithDS.Domain;
using Ninject.Modules;

namespace MonolithDS.DependancyResolution
{
    public class Data : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<DSEntities>();
        }
    }
}
