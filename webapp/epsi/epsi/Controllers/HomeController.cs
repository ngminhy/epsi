using epsi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using epsi.ViewModels;

namespace epsi.Controllers
{
    public class HomeController : Controller
    {
        Biz4Db db = new Biz4Db();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Slider()
        {
            var banners = db.Banners.Where(p => p.Tag == "Top").OrderBy(p => p.BannerId).ToList();
            return PartialView("_slider", banners);
        }

        public ActionResult FeaturedProduct()
        {
            var featuredproduct = db.Products.Where(p => p.IsHome == true && p.IsSpecial == true).ToList();
            return PartialView("_featuredproduct", featuredproduct);
        }
        public ActionResult NewProduct()
        {
            var newproduct = db.Products.Where(p => p.IsHome == true && p.IsNew == true).ToList();
            return PartialView("_newproduct", newproduct);
        }

        public ActionResult LatestNew()
        {
            var latestnew = db.Articles.Where(p => p.Active == true && p.IsHome == true).ToList();
            return PartialView("_latestnews", latestnew);
        }

        public ActionResult TopMenu()
        {
            var menus = db.Menus.Where(p => p.Tag == "Top").OrderBy(p => p.Order).ToList();
            //foreach (var item in menus)
            //{
            //    item.SubMenus = db.Menus.Where(p => p.ParentId == item.MenuId && p.Tag == "Top").OrderByDescending(p => p.Order).ThenBy(p => p.MenuId).Select(p => new LinkDto() { Title = p.Text, Link = p.Link, MenuId = p.MenuId }).ToList();
            //}
            return PartialView("_menu", menus);
        }
    }
}