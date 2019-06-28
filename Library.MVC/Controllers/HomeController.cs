using Library.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckFirstRedirect()
        {
            if (User.IsInRole(UserRoles.Admin) || User.IsInRole(UserRoles.User))
            {
                RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}