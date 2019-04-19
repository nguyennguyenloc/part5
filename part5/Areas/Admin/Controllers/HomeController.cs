using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace part5.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserId"] == null || Session["UserId"].ToString() == null)
            {
                return Redirect("/Admin/Login");
            }
            return View();
        }

    }
}