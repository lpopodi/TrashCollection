using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trash_Collection.Models
{
    public class CustomerViewModel
    {
        public IQueryable<Service> Service { get; set; }
        public IQueryable<Pickup> Pickup { get; set; }
        public IQueryable<Invoice> Invoice { get; set; }

    //    public CustomerViewModel()
    //    {
    //        Service = new Service();
    //        Pickup = new Pickup();
    //        Invoice = new List<Invoice>();
    //    }
    }
}