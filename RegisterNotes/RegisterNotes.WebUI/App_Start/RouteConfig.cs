using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RegisterNotes.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new { controller = "Note", action = "List", pblc = (string)null, page = 1 }
            );

            routes.MapRoute(null,
                "Page{page}",
                new { controller = "Note", action = "List", pblc = (string)null },
                new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{pblc}",
                new { controller = "Note", action = "List", page = 1 }
            );

            routes.MapRoute(null,
                "{pblc}/Page{page}",
                new { controller = "Note", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
