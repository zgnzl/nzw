﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Caching;

namespace nzw.Controllers
{
    public class HomeController : Controller
    {
        private Cache caching = new Cache();
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
                return View("AnLiDetail/" + id);
            }
        }
        public ActionResult SearchAnLi(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                ViewBag.keyword = keyword;
                ViewBag.list = GetAnLiDetailList().FindAll(c => c.Contains(keyword));
            }
            return View();
        }
        public List<string> GetAnLiDetailList()
        {
            List<string> listanli = new List<string>();
                string path = Server.MapPath("~/views/Home/anlidetail");
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (FileInfo fileinfo in dir.GetFiles())
                {
                    listanli.Add(fileinfo.Name.Replace(".cshtml", ""));
                }
            return listanli;
        }

        public ActionResult Search(string text)
        {
            ViewBag.text = text;
            return View();
        }
    }
}