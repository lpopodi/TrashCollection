using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollection
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Day { get; set; }
        public DateTime Hold { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
    }
}