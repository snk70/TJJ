using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute("sina", "Admin/Account/LogOff", new { Controller = "Account", action = "LogOff" });
            //routes.MapRoute("sina", "Admin/Account/LogOff", new { Controller = "Account", action = "LogOff" });

            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TJJ.Controllers" }
            );
        }
    }
}