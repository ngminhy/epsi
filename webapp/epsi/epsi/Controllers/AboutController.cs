using epsi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace epsi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Biz4Db db = new Biz4Db();
        public ActionResult Index()
        {
            var about = db.Articles.Where(p => p.CategoryId == 29 && p.Active).FirstOrDefault();
            ViewBag.listBanner = db.Banners.Where(p => p.Tag == "About").ToList();
            return View(about);
        }
    }
}