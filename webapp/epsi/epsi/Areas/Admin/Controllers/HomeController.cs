using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace epsi.Areas.Admin.Controllers
{
    //[Authorize]
    
    public class HomeController : Controller
    {
        //
        // GET: /bo/Home/


        public ActionResult Index()
        {
            return View();
        }

    }
}
