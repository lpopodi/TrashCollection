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

namespace TrashCollection.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        //public ActionResult Index()
        //{

        //    if (User.Identity.IsAuthenticated)
        //    {


        //        if (!isAdminUser())
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var Roles = context.Roles.ToList();
        //    return View(Roles);

        //}
    }
}