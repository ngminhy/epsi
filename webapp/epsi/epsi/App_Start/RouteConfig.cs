using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace epsi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         
            routes.MapRoute(
             name: "product",
             url: "san-pham/{pageURL}",
             defaults: new { controller = "Product", action = "Index", pageURL = UrlParameter.Optional },
             namespaces: new String[] { "epsi.Controllers" }
          );
            routes.MapRoute(
          name: "article",
          url: "news/{pageURL}",
          defaults: new { controller = "Article", action = "Index", pageURL = UrlParameter.Optional },
          namespaces: new String[] { "epsi.Controllers" }
       );
            routes.MapRoute(
           name: "productdetail",
           url: "d/{pageURL}",
           defaults: new { controller = "Product", action = "Detail", pageURL = UrlParameter.Optional },
           namespaces: new String[] { "epsi.Controllers" }
        );
            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                  namespaces: new String[] { "epsi.Controllers" }
             );
        }
    }
}
