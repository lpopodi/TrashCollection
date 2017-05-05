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

            //cv.Service = from s in db.Services where (Id == customerProfile) select s;
            //cv.Pickup = from p in db.Pickups where (select p;
            //cv.Invoice = from i in db.Invoices select i;

            return View(customer);
            //return View();
        }
    }
}