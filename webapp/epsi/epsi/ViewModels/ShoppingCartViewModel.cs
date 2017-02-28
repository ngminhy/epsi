using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using epsi.Models;

namespace epsi.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}