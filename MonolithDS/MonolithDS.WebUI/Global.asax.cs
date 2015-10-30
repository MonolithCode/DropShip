using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
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

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DSEntities, MonlithDS.DAL.Migrations.Configuration>());
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
