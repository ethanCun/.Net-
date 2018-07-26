using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace NLogTest.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Logger logger = LogManager.GetLogger("NLogTest");
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            logger.Trace("homeController 跟踪");
            logger.Fatal("homeController 致命错误");

            return View();
        }
    }
}
