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
            ViewBag.Title = ID;
            return View(ID);
        }

        public ActionResult ProductInformation(string ID)
        {
            ViewBag.Title = ID;
            return View("~/Views/Product_Information/" + ID+".cshtml");
        }
        public ActionResult News(string ID)
        {
            ViewBag.Title = ID;
            return View("~/Views/News/" + ID + ".cshtml");
        }
        public ActionResult Technology(string ID)
        {
            ViewBag.Title = ID;
            return View("~/Views/Technology/" + ID + ".cshtml");
        }
    }
}