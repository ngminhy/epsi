using System.Web;
using System.Web.Mvc;

namespace epsi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomAuthorizeAttribute());
        }
        public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var routeData = httpContext.Request.RequestContext.RouteData;
                var area = routeData.DataTokens["area"];
                var user = httpContext.User;
               if (area != null && area.ToString() == "Admin")
                {
                    if (!user.Identity.IsAuthenticated)
                        return false;
                    if (!user.IsInRole("admin"))
                        return false;
                }
                return true;
            }
        }
    }
}
