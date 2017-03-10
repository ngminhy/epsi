using epsi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace epsi.Controllers
{
    public class ContactController : Controller
    {
        Biz4Db db = new Biz4Db();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string name,string email,string phone,string subject,string message)
        {
            var contact = new Contact();
            contact.FullName = name;
            contact.Email = email;
            contact.Phone = phone;
            contact.Subject = subject;
            contact.Description = message;
            db.Contact.Add(contact);
            db.SaveChanges();
            ViewBag.message = "Chúng tôi sẽ sớm liên hệ lại với ban. Xin cảm ơn!";
            return View();
            //return Json(new { data = true },JsonRequestBehavior.AllowGet);
            
        }
   }
}