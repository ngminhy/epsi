using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using epsi.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace epsi.Areas.Admin.Controllers
{
    [Authorize]
    public class RuleProductController : Controller
    {


        //
        // GET: /Admin/RuleProduct/
        Biz4Db db = new Biz4Db();
        public ActionResult Index(int productid)
        {
            ViewBag.ProductId = productid;
            return View();
        }
        public JsonResult Get([DataSourceRequest]DataSourceRequest request,int productid)
        {
            var RuleProducts = db.RuleProducts.Where(p=>p.ProductId == productid).OrderByDescending(p => p.RuleProductId).ToList();
            return this.Json(RuleProducts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<epsi.Models.RuleProduct> RuleProducts, int productid)
        {
            var results = new List<epsi.Models.RuleProduct>();

            if (RuleProducts != null && ModelState.IsValid)
            {
                foreach (var RuleProduct in RuleProducts)
                {
                    RuleProduct.ProductId = productid;
                    db.RuleProducts.Add(RuleProduct);

                    results.Add(RuleProduct);
                }
                db.SaveChanges();
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<epsi.Models.RuleProduct> RuleProducts)
        {
            if (RuleProducts != null && ModelState.IsValid)
            {
                foreach (var RuleProduct in RuleProducts)
                {
                    var target = db.RuleProducts.FirstOrDefault(p => p.RuleProductId == RuleProduct.RuleProductId);
                    if (target != null)
                    {
                        target.Title = RuleProduct.Title;
                        target.Description = RuleProduct.Description;
                        target.Price = RuleProduct.Price;
                        target.IsDefault = RuleProduct.IsDefault;
                        //update default Rule for Product
                        if (RuleProduct.IsDefault)
                        {
                            var product = db.Products.Where(p => p.ProductId == RuleProduct.ProductId).FirstOrDefault();
                            product.Price = RuleProduct.Price;
                            db.Products.Add(product);
                            db.SaveChanges();
                        }
                    }

                }
                db.SaveChanges();
            }

            return Json(RuleProducts.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<epsi.Models.RuleProduct> RuleProducts)
        {
            if (RuleProducts.Any())
            {
                foreach (var RuleProduct in RuleProducts)
                {
                    var RuleProductToDelete = db.RuleProducts.First(p => p.RuleProductId == RuleProduct.RuleProductId);
                    if (RuleProductToDelete != null)
                    {
                        db.RuleProducts.Remove(RuleProductToDelete);
                    }
                }
                db.SaveChanges();
            }

            return Json(RuleProducts.ToDataSourceResult(request, ModelState));
        }


    }
}
