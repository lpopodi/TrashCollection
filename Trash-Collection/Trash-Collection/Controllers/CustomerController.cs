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
        // GET: Customer
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var customerProfile = User.Identity.GetUserId();

            CustomerViewModel cv = new CustomerViewModel();

            //cv.ServiceData = from s in db.Service where (UserId == customerProfile) select s;
            //cv.Pickup = from p in db.Pickup select p;
            //cv.Invoice = from i in db.Invoice select i;

            return View(/*cv*/);
            //return View();
        }
    }
}