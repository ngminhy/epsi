using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace epsi.Models
{
  
        public partial class Order
        {
            public int OrderId { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Note { get; set; }
            public decimal PaymentType { get; set; }
            public decimal Total { get; set; }
            public string OrderCode { get; set; }
            public int OrderStatusId { get; set; }
            public string OrderStatus { get; set; }
            public System.DateTime OrderDate { get; set; }
            public List<OrderDetail> OrderDetails { get; set; }
        }
}