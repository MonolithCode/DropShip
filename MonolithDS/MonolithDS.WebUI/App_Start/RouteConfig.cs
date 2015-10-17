using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MonolithDS.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "{controller}/PriceRange/{pricerange}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(null,
                "{pricerange}",
                new { controller = "Product", action = "List", page = 1 }
                );

            routes.MapRoute(null, "Page{page}",
                new
                {
                    controller = "Product",
                    action = "List",
                    PriceRange =
                        (string)null
                },
                new { page = @"\d+" });

            routes.MapRoute(null,
                "{controller}/{PriceRange}",
                new { controller = "Product", action = "List", page = 1 }
                );

            routes.MapRoute(null,
                "{pricerange}/Page{page}",
                new { controller = "Product", action = "List" },
                new { page = @"\d+" }
                );
        }
    }
}
