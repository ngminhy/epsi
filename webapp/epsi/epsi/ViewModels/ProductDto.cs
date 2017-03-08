using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using epsi.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace epsi.ViewModels
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string MainImage { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public int ParentId { get; set; }
        public string CategoryName { get; set; }
        public int BasePrice { get; set; }
        public int Price { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsNew { get; set; }
        public bool IsHome { get; set; }
        public string Code { get; set; }
        public string PageURL { get; set; }
        public ProductDto(Product model)
        {
            ProductId = model.ProductId;
            CategoryId = model.CategoryId;
            ParentId = model.ParentId;
            Code = model.Code;
            Description = model.Description;
            Content = model.Content;
            MainImage = model.MainImage;
            Tags = model.Tags;
            Name = model.Name;
            Active = model.Active;
            IsSpecial = model.IsSpecial;
            IsNew = model.IsNew;
            IsHome = model.IsHome;
            BasePrice = model.BasePrice;
            Price = model.Price;
            PageURL = model.PageURL;

        }
        public ProductDto()
        { }



    }
}