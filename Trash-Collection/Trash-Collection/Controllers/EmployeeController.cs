using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trash_Collection.Models;

namespace Trash_Collection.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        string zipInput { get; set; }
        string dateInput { get; set; }
         // GET: Employee
        public ActionResult Index(EmployeeSearchModel searchModel)
        {
            //var business = new EmployeeBusinessLogic();
            //var model = business.GetStops(searchModel);
            //return View(model);
            EmployeeViewModel ev = new EmployeeViewModel();

            var stops = db.Services.Single(s => s.ServiceDay.Contains(dateInput) && s.Pickup.Zip.Contains(zipInput)
            //{
            //    ServiceDay = stops.ServiceDay;
            //    PickupAddress = stops.Pickup.DisplayAddress;
            //}
            );

            return View(stops);
            //return View();
        }

       
    }
}