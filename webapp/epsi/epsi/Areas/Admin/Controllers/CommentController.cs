using epsi.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace epsi.Areas.Admin.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        Biz4Db db = new Biz4Db();
        // GET: Admin/Comment
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {
            var contact = db.Contact.OrderByDescending(p => p.ContactId).ToList();
            return this.Json(contact.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Edit(Contact model)
        {
            if (ModelState.IsValid)
            {
                var updateContact = db.Contact.FirstOrDefault(p => p.ContactId == model.ContactId);
                if (updateContact != null)
                {

                    TryUpdateModel(updateContact);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }
        //
        // GET: /bo/Article/Edit/5

        public ActionResult Edit(int id)
        {
            var contact = db.Contact.FirstOrDefault(p => p.ContactId == id);
            return View("Create", contact);
        }

        //


        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, Contact model)
        {
            var deleteContact = db.Contact.First(p => p.ContactId == model.ContactId);
            if (deleteContact != null)
            {
                db.Contact.Remove(deleteContact);
                db.SaveChanges();
            }
            return Json(new[] { deleteContact }.ToDataSourceResult(request));
        }
    }
}