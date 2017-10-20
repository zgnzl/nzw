using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ztxh_buy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPage(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return RedirectToAction("INDEX");
            }
            return View(ID);
        }
    }
}