using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TrashCollection.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Routing;

namespace TrashCollection.Controllers
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
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var s = UserManager.GetRoles(user.GetUserId());

            do
            {
                if (s[0].ToString() == "Admin")
                {
                    //UserStatus = "Admin";
                    return View("Admin", "User");
                }
                else if (s[0].ToString() == "Employee")
                {
                    //UserStatus = "Employee";
                    return View("Index", "Employee");
                }
                else if (s[0].ToString() == "Customer")
                {
                    //UserStatus = "Customer";
                    return View("Index", "Customer");
                }
                else
                {
                    //UserStatus = "na";
                    return View("Index", "Home");
                }
            }
            while (User.Identity.IsAuthenticated);
        }

    }
}