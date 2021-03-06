﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using epsi.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using epsi.ViewModels;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace epsi.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        //
        // GET: /Admin/product/
        Biz4Db db = new Biz4Db();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {
            var Products = (from p in db.Products
                            join c in db.Categorys
                            on p.CategoryId equals c.CategoryId
                            orderby p.ProductId descending
                            select new ProductDto
                            {
                                ProductId = p.ProductId,
                                CategoryId = p.CategoryId,
                                Code = p.Code,

                                Description = p.Description,
                                Tags = p.Tags,
                                Name = p.Name,
                                CategoryName = c.Name,
                                PageURL = p.PageURL
                            }).ToList();

            return this.Json(Products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetCascadeCategories()
        {
           var category = db.Categorys.Where(p => p.Tag == "product" && p.ParentId==0 && p.IsDeleted==true).ToList();

            return Json(category.Select(c => new { CategoryId = c.CategoryId, Name = c.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeSubCategories(int? categories)
        {

            var category = db.Categorys.Where(p => p.ParentId == categories && p.IsDeleted == true).ToList();

            return Json(category.Select(c => new { CategoryId = c.CategoryId, Name = c.Name }), JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/product/Create

        public ActionResult Create()
        {
            var Product = new ProductDto();
            return View(Product);
        }

        //
        // POST: /Admin/product/Create

        [HttpPost]
        public ActionResult Create(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.PageURL)) model.PageURL = ConvertToUnSign(model.Name.ToLower());
                Product Product = new Product(model);                
                db.Products.Add(Product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var updateProduct = db.Products.FirstOrDefault(p => p.ProductId == model.ProductId);
                if (updateProduct != null)
                {
                    TryUpdateModel(updateProduct);
                    if (string.IsNullOrEmpty(updateProduct.PageURL)) updateProduct.PageURL = ConvertToUnSign(updateProduct.Name.ToLower());
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }
        //
        // GET: /Admin/product/Edit/5

        public ActionResult Edit(int id)
        {
            var ProductDto = new ProductDto(  db.Products.FirstOrDefault(p => p.ProductId == id));
            return View("Create", ProductDto);
        }

        //


        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, ProductDto model)
        {
            var ProductToDelete = db.Products.First(p => p.ProductId == model.ProductId);

            if (ProductToDelete != null)
            {
                db.Products.Remove(ProductToDelete);
                db.SaveChanges();
            }

            return Json(new[] { ProductToDelete }.ToDataSourceResult(request));
        }
        public static string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            text = text.Replace(" ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
