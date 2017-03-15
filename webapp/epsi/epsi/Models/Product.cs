using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using epsi.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace epsi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Code { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        
        [AllowHtml]
        public String Content { get; set; }

        [StringLength(200)]
        public string Tags { get; set; }
        public bool Active { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsNew { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NumofViews { get; set; }
        public int BasePrice { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }
        public string Colors { get; set; }
        public string Material { get; set; }
        public string Power { get; set; }
        public string Size { get; set; }
        public string OtherFeatures { get; set; }
        [StringLength(200)]
        public string MainImage { get; set; }

        public int CategoryId { get; set; }
        public int ParentId { get; set; }
        public string PageURL { get; set; }

        public Product() { }
        public Product(ProductDto model)
        {
            ProductId = model.ProductId;
            CategoryId = model.CategoryId;
            ParentId = model.ParentId;
            Code = model.Code;
            Description = model.Description;
            Tags = model.Tags;
            Name = model.Name;
            Content = model.Content;
            Active = model.Active;
            MainImage = model.MainImage;
            IsSpecial = model.IsSpecial;
            IsNew = model.IsNew;
            IsHome = model.IsHome;
            Price = model.Price;
            Colors = model.Colors;
            Material = model.Material;
            Power = model.Power;
            Size = model.Size;
            OtherFeatures = model.OtherFeatures;
            BasePrice = model.BasePrice;
            CreatedDate = DateTime.Now;
            PageURL = model.PageURL;
        }
    }
}
