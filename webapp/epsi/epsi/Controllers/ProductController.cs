using epsi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace epsi.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        Biz4Db db = new Biz4Db();
        public ActionResult Index(string pageURL, int? page)
        {
            int pageSize = 0;
            int.TryParse(ConfigurationManager.AppSettings["PageSize"].ToString(), out pageSize);
            if (pageSize == 0) { pageSize = 8; }
            int index = page.HasValue ? page.Value : 1;
            int CategoryID = 0;
            ViewBag.PageIndex = index;

            if (!string.IsNullOrEmpty(pageURL))
            {
                var cateId = db.Categorys.Where(p => p.PageURL == pageURL && p.Tag == "Product" && p.IsDeleted).FirstOrDefault();
                CategoryID = cateId.CategoryId;
            }

                //if (!string.IsNullOrEmpty(pageURL))
                //{
                //    ViewBag.Title = ViewBag.Category.Name + (ViewBag.PageIndex > 1 ? " - Page: " + ViewBag.PageIndex : "");
                //    ViewBag.Description = ViewBag.Category.Description;
                //    CategoryID = ViewBag.CategoryID = ViewBag.Category.CategoryId;
                //}
                //else
                //{
                //    ViewBag.Title = "Tin tức" + (ViewBag.PageIndex > 1 ? " - Page: " + ViewBag.PageIndex : "");
                //    ViewBag.CategoryID = 0;
                //}
                var products = db.Products.Where(p => (CategoryID == 0 || p.CategoryId == CategoryID || p.ParentId ==CategoryID) && p.Active).OrderByDescending(p => p.ProductId).Skip((index - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPage = (int)Math.Ceiling(((double)db.Products.Where(p => (CategoryID == 0 || p.CategoryId == CategoryID || p.ParentId == CategoryID) && p.Active).Count()) / pageSize);
            return View(products);
        }

        public ActionResult SidebarCategory()
        {
            var ListCategoryParent = db.Categorys.Where(p => p.Tag == "Product" && p.ParentId == 0).ToList();
            return PartialView("_sidebarCategory", ListCategoryParent);
        }
        public ActionResult SidebarCategoryChild(int parentId)
        {
            var ListCategoryChild = db.Categorys.Where(p => p.Tag == "Product" && p.ParentId == parentId).ToList();
            return PartialView("_sidebarCategoryChild", ListCategoryChild);
        }

        public ActionResult CountProductbyCate(int cateId)
        {
            ViewBag.countproduct = db.Products.Where(p => p.Active && (p.ParentId == cateId || p.CategoryId == cateId)).Count();
            return PartialView("_CountProductByCate");
        }

        public ActionResult Detail(string pageURL)
        {
            var product = db.Products.Where(p => p.Active && p.PageURL == pageURL).FirstOrDefault();
            return View(product);
        }
    }
}