using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MB_Pipeline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "StaticPageAbout",
                url: "About",
                defaults: new { controller = "StaticPages", action = "About" }
            );

            routes.MapRoute(
                name: "StaticPageContact",
                url: "Contact",
                defaults: new { controller = "StaticPages", action = "Contact" }
            );

            routes.MapRoute(
                name: "StaticPage404",
                url: "404",
                defaults: new { controller = "StaticPages", action = "AccessDenied" }
            );

            routes.MapRoute(
                name: "Signin",
                url: "Signin",
                defaults: new { controller = "Sessions", action = "Index" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}