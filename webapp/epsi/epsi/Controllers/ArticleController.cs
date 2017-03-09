using epsi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace epsi.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        Biz4Db db = new Biz4Db();
        public ActionResult Index(string pageURL, int? page)
        {
            int pageSize = 0;
            int.TryParse(ConfigurationManager.AppSettings["PageSize"].ToString(), out pageSize);
            if (pageSize == 0) { pageSize = 8; }
            int index = page.HasValue ? page.Value : 1;
            int CategoryID = 0;
            ViewBag.cateName = "Tin tức";
            ViewBag.PageIndex = index;

            if (!string.IsNullOrEmpty(pageURL))
            {
                var cateId = db.Categorys.Where(p => p.PageURL == pageURL && p.Tag == "Article" && p.IsDeleted).FirstOrDefault();
                ViewBag.cateName = cateId.Name;
                CategoryID = cateId.CategoryId;
            }
            var products = db.Articles.Where(p => (CategoryID == 0 || p.CategoryId == CategoryID) && p.Active).OrderByDescending(p => p.CategoryId).Skip((index - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPage = (int)Math.Ceiling(((double)db.Articles.Where(p => (CategoryID == 0 || p.CategoryId == CategoryID) && p.Active).Count()) / pageSize);
            return View(products);
        }
    }
}