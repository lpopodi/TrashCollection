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
        protected string RedirectPath = string.Empty;
        protected bool DoRedirect = false;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            // Your logic to determine whether to redirect or not goes here. Bellow is an example...
            if (requestContext.HttpContext.User.IsInRole("Admin"))
            {
                DoRedirect = true;
                RedirectPath = Url.Action("Admin", "User");
            }
            else if (requestContext.HttpContext.User.IsInRole("Employee"))
            {
                DoRedirect = true;
                RedirectPath = Url.Action("Employee", "User");
            }
            else if (requestContext.HttpContext.User.IsInRole("Customer"))
            {
                DoRedirect = true;
                RedirectPath = Url.Action("Customer", "User");
            }
            else
            {
                DoRedirect = false;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (DoRedirect)
            {
                // Option 1: TRANSFER the request to another url
                //filterContext.Result = new TransferResult(RedirectPath);
                // Option 2: REDIRECT the request to another url
                filterContext.Result = new RedirectResult(RedirectPath);
            }

        }
    }
}