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
            return PartialView("_menu", menus);
        }

        public ActionResult MenuCategory()
        {
            var ListCategoryParent = db.Categorys.Where(p => p.Tag == "Product" && p.ParentId == 0).ToList();
            return PartialView("_menuCategory", ListCategoryParent);
        }
        public ActionResult MenuCategoryChild(int parentId)
        {
            var ListCategoryChild = db.Categorys.Where(p => p.Tag == "Product" && p.ParentId == parentId).ToList();
            return PartialView("_menuCategoryChild", ListCategoryChild);
        }
        public ActionResult MenuMobileCategory()
        {
            var ListCategoryParent = db.Categorys.Where(p => p.Tag == "Product" && p.ParentId == 0).ToList();
            return PartialView("_menuMobileCategory", ListCategoryParent);
        }
        public ActionResult MenuMobileCategoryChild(int parentId)
        {
            var ListCategoryChild = db.Categorys.Where(p => p.Tag == "Product" && p.ParentId == parentId).ToList();
            return PartialView("_menuMobileCategoryChild", ListCategoryChild);
        }
    }
}