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
            ViewBag.cateURL = "tin-tuc";
            ViewBag.PageIndex = index;

            if (!string.IsNullOrEmpty(pageURL))
            {
                var cateId = db.Categorys.Where(p => p.PageURL == pageURL && p.Tag == "Article" && p.IsDeleted).FirstOrDefault();
                ViewBag.cateName = cateId.Name;
                ViewBag.cateURL = cateId.PageURL;
                CategoryID = cateId.CategoryId;
            }
            var products = db.Articles.Where(p => (CategoryID == 0 || p.CategoryId == CategoryID) && p.Active).OrderByDescending(p => p.CategoryId).Skip((index - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPage = (int)Math.Ceiling(((double)db.Articles.Where(p => (CategoryID == 0 || p.CategoryId == CategoryID) && p.Active).Count()) / pageSize);
            return View(products);
        }
        public ActionResult Detail(string cateURL,string pageURL)
        {
            var article = db.Articles.Where(p => p.PageURL == pageURL && p.Active).FirstOrDefault();
            if (article == null) article = db.Articles.Where(p => p.Active).OrderByDescending(p => p.ArticleId).FirstOrDefault();
            if (article == null) return RedirectToAction("index", "home");
            ViewBag.cateURL = cateURL;
            ViewBag.RelatedArticles = db.Articles.Where(p => p.CategoryId == article.CategoryId && p.ArticleId != article.ArticleId && p.Active).OrderByDescending(p => p.ArticleId).Take(30).AsEnumerable().ToList();
            return View(article);
        }

        public ActionResult FooterMenu(int id)
        {
            var cate = db.Categorys.Where(p => p.CategoryId == id && p.IsDeleted).FirstOrDefault();

            var footermenu = db.Articles.Where(p => p.CategoryId == id && p.Active).ToList();
            ViewBag.cateURL = cate.PageURL;
            return PartialView("_FooterMenu", footermenu);
        }
    }
}