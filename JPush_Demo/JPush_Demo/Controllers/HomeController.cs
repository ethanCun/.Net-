using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jiguang.JPush;
using Jiguang.JPush.Model;

namespace JPush_Demo.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";



            return View();
        }
    }
}
