using System;
using System.Web.Mvc;

namespace epsi.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "BO/{controller}/{action}/{id}",
                new { area = "admin", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
