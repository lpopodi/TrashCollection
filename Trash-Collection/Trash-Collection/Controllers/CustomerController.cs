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
        //private ICollection<Invoice> cInvoice;
        //private bool cOneTimeChange;
        //private bool cPermanentChange;
        //private string cPickupAddress;
        //private string cServiceDay;
        //private bool cServiceHold;
        //private int cServiceId;
        //private DateTime? cTempChangeDay;
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            
            var customerProfile = User.Identity.GetUserId();
            //ApplicationDbContext db = new ApplicationDbContext();
            CustomerViewModel cv = new CustomerViewModel();
            cv.Service = db.Services.Where(c => c.UserId == customerProfile);
            cv.Invoice = db.Invoices;
            cv.Pickup = db.Pickups;

            var customer = db.Services.Single(c => c.UserId == customerProfile);
            //{
            //    cServiceId = customer.ServiceId;
            //    cServiceDay = customer.ServiceDay;
            //    cOneTimeChange = customer.OneTimeChange;
            //    cTempChangeDay = customer.TempChangeDay;
            //    cPermanentChange = customer.PermanentChange;
            //    cServiceHold = customer.ServiceHold;
            //    cPickupAddress = customer.Pickup.DisplayAddress;
            //    cInvoice = customer.Invoices;
            //};

            //var viewModel = db.Services.Select(srv => new CustomerViewModel() { Service = srv, Pickup = srv.Pickup, Invoice = srv.Invoices }).ToList();

            //return View(viewModel);

            //return View(cv);
            return View(customer);

        }
    }
}