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

        private string name;
        [StringLength(200)]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.UpdateSearchField();
            }
        }

        private string code;
        [StringLength(200)]
        public string Code
        {
            get
            {
                return this.code;
            }

            set
            {
                this.code = value;
                this.UpdateSearchField();
            }
        }

        private string desc;
        [StringLength(1000)]
        public string Description
        {
            get
            {
                return this.desc;
            }

            set
            {
                this.desc = value;
                this.UpdateSearchField();
            }
        }

        [AllowHtml]
        public String Content { get; set; }

        private string tags;
        [StringLength(200)]
        public string Tags
        {
            get
            {
                return this.tags;
            }

            set
            {
                this.tags = value;
                this.UpdateSearchField();
            }
        }
        public bool Active { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsNew { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NumofViews { get; set; }
        public int BasePrice { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }
        private string colors;
        public string Colors
        {
            get
            {
                return this.colors;
            }

            set
            {
                this.colors = value;
                this.UpdateSearchField();
            }
        }
        private string material;
        public string Material
        {
            get
            {
                return this.material;
            }

            set
            {
                this.material = value;
                this.UpdateSearchField();
            }
        }

        private string power;
        public string Power
        {
            get
            {
                return this.power;
            }

            set
            {
                this.power = value;
                this.UpdateSearchField();
            }
        }

        private string size;
        public string Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
                this.UpdateSearchField();
            }
        }
        public string OtherFeatures { get; set; }
        [StringLength(200)]
        public string MainImage { get; set; }

        private int categoryId;
        public int CategoryId
        {
            get
            {
                return this.categoryId;
            }

            set
            {
                this.categoryId = value;
                this.UpdateSearchField();
            }
        }
        public int ParentId { get; set; }

        private string pageURL;
        public string PageURL
        {
            get
            {
                return this.pageURL;
            }

            set
            {
                this.pageURL = value;
                this.UpdateSearchField();
            }
        }

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

        private void UpdateSearchField()
        {
            this.Search = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", this.Code, this.Colors, this.Description, this.Material, this.Name, this.Power, this.PageURL, (this.CategoryId > 0) ? string.Empty : this.GetCategory(this.CategoryId), this.Size);
        }
        private string GetCategory(int categoryId)
        {
            //Biz4Db db = new Biz4Db();
            //var cate = db.Categorys.SingleOrDefault(p => p.CategoryId == categoryId);
            //return (cate == null) ? string.Empty : cate.Name + cate.PageURL + cate.Description; 
            return categoryId + " den chieu sang philip";
        }
        public string Search { get; private set; }
    }
}
