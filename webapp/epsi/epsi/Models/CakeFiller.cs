using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace epsi.Models
{
    public class CakeFiller
    {
        public int CakeFillerId { get; set; }
        [StringLength(200)]
        public String Name { get; set; }
        public int Price { get; set; }
        [StringLength(200)]
        public String FillerImage { get; set; }

    }
}