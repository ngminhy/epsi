using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using epsi.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Text.RegularExpressions;

namespace epsi.Areas.Admin.Controllers
{
    [Authorize]
    public class QuickLinkController : Controller
    {
        //
        // GET: /bo/QuickLink/
        Biz4Db db = new Biz4Db();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {
            var QuickLinks = db.QuickLinks.OrderByDescending(p => p.QuickLinkId).ToList();
            return this.Json(QuickLinks.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        // GET: /bo/QuickLink/Create

        public ActionResult Create()
        {
            var QuickLink = new QuickLink();
            QuickLink.Order = 0;
            QuickLink.IsDeleted = true;
            return View(QuickLink);
        }

        //
        // POST: /bo/QuickLink/Create

        [HttpPost]
        public ActionResult Create(QuickLink model)
        {
            if (ModelState.IsValid)
            {
                db.QuickLinks.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(QuickLink model)
        {
            if (ModelState.IsValid)
            {
                var updateQuickLink = db.QuickLinks.FirstOrDefault(p => p.QuickLinkId == model.QuickLinkId);
                if (updateQuickLink != null)
                {

                    TryUpdateModel(updateQuickLink);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }
        //
        // GET: /bo/QuickLink/Edit/5

        public ActionResult Edit(int id)
        {
            var QuickLink = db.QuickLinks.FirstOrDefault(p => p.QuickLinkId == id);
            return View("Create", QuickLink);
        }

        //


        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, QuickLink model)
        {
            var QuickLinkToDelete = db.QuickLinks.First(p => p.QuickLinkId == model.QuickLinkId);
            if (QuickLinkToDelete != null)
            {
                db.QuickLinks.Remove(QuickLinkToDelete);
                db.SaveChanges();
            }
            return Json(new[] { QuickLinkToDelete }.ToDataSourceResult(request));
        }
    }
}
