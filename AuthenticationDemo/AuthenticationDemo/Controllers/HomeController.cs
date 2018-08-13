using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AuthenticationDemo.Controllers
{
    public class HomeController : Controller
    {
        //接收登录页面传过来的UserName和Ticket
        public ActionResult Index(string UserName, string Ticket)
        {
            ViewBag.Title = "Home Page";

            //将登陆之后的信息传给首页index页面
            ViewBag.UserName = UserName;
            ViewBag.Ticket = Ticket;

            return View();
        }
    }
}
