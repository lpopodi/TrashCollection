using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Customer
    {
       
        [Key]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "A Service Day is required")]
        public string Day { get; set; }
        public bool ServiceHold { get; set; }
        public DateTime HoldDate { get; set; }
        public string LocationId { get; set; }
        public string BillingId { get; set; }
    }
}