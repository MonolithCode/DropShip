using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MonlithDS.DAL.Models;
using MonolithDS.Domain.Shopping.Cart;
using MonolithDS.WebUI.Binders.Shopping;

namespace MonolithDS.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DSEntities, MonlithDS.DAL.Migrations.Configuration>());

            //Update the DB as required
            var configuration = new MonlithDS.DAL.Migrations.Configuration();
            var migrator = new System.Data.Entity.Migrations.DbMigrator(configuration);
            if (migrator.GetPendingMigrations().Any())
            {
                migrator.Update();
            }

            //Database.SetInitializer<DSEntities>(null);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
