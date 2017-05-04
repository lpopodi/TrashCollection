using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Billing
    {
        [Key]
        public string BillingId { get; set; }
        public decimal Price { get; set; }

    }
}