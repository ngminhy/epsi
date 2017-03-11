using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace epsi_static.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Forgottenpassword()
        {
            return View();
        }
        public ActionResult Resetpassword()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}