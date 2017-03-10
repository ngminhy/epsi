using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace epsi.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Subject { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}