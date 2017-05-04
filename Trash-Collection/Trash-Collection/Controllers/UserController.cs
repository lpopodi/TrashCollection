using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trash_Collection.Models;

namespace Trash_Collection.Controllers
{
    public class UserController : Controller
    {
        //protected string RedirectPath = string.Empty;
        //protected bool DoRedirect = false;
        //protected string UserStatus = string.Empty;

        [Authorize]
        public ActionResult Index()
        {
            var user = User.Identity;
            ViewBag.Name = user.Name;
            ViewBag.DisplayMenu = "No";
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var s = UserManager.GetRoles(user.GetUserId());

            do
            {
                if (s[0].ToString() == "Admin")
                {
                    //UserStatus = "Admin";
                    ViewBag.displayMenu = "Yes";
                    return View();
                }
                
                else if (s[0].ToString() == "Employee")
                {
                    //UserStatus = "Employee";
                    return RedirectToAction("Index", "Home");
                }
                else if (s[0].ToString() == "Customer")
                {
                    //UserStatus = "Customer";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //UserStatus = "na";
                    return RedirectToAction("Index", "Home");
                }
            }
            while (User.Identity.IsAuthenticated);
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }
}