using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collection.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "A Service Day is required")]
        public bool OneTimeChange { get; set; }
        public DateTime? TempChangeDay { get; set; }
        public bool PermanentChange { get; set; }
        public string ServiceDay { get; set; }
        public bool ServiceHold { get; set; }
        public DateTime? HoldDate { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Pickup Pickup { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}