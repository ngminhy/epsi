using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace epsi.ViewModels
{
    public class InfoOrder
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public int PaymentType { get; set; }
    }
}