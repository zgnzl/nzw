﻿using System;
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
        public ActionResult Product()
        {
            return View();
        }
    }
}