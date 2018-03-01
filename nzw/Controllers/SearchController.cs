using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace nzw.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pub(string url)
        {
            ViewBag.url = url;
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            ViewBag.content= client.DownloadString(url);
            return View();
        }
    }
}