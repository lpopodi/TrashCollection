using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trash_Collection.Models;

namespace Trash_Collection.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            
            var customerProfile = User.Identity.GetUserId();

            CustomerViewModel cv = new CustomerViewModel();

            var customer = db.Services.Single(c => c.UserId == customerProfile);
            
            //var custPickup = db.Pickups.Single(cp => cp.ServiceId == customer.ServiceId);
            //var custInvoice = db.Invoices.Single(ci => ci.ServiceId == customer.ServiceId);

            //cv.Service = db.Services.Single(c => c.UserId == customerProfile);
            //cv.Pickup = db.Pickups.Single(cp => cp.ServiceId == customer.ServiceId);
            //cv.Invoice = db.Invoices.Single(ci => ci.ServiceId == customer.ServiceId);

            return View(customer);
            //return View();
        }
    }
}