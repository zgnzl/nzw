using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nzw.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View(); 
        }
        public ActionResult ZhaoPin()
        {
            return View();
        }
        public ActionResult Product(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                return View(id);
            }
        }
        public ActionResult CloudService(string id)
        {
            return View("CloudService/" + id);
        }

        public ActionResult AnLi(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                return View(id);
            }
        }

        public ActionResult AnLiDetail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("AnLi", new { id = "" });
            }
            else
            {
                return View("AnLiDetail/"+id);
            }
        }
        public ActionResult SearchAnLi(string id)
        {
            string name = "";
            return RedirectToAction("AnLiDetail",new { id=name});
        }
    }
}