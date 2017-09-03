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
                //if ("噢易云服务器;噢易云终端(X86ARM);噢易云一体机(X86ARM);".Contains(id + ";"))
                //{
                //   return RedirectToAction("CloudService", new { @id="硬件配置"});
                //}
                //else
                {
                return View(id);
                }

            }
        }
        public ActionResult CloudService(string id)
        {
            return View(id);
        }
    }
}