using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuthenticationDemo.Models;
//引入Authentication
using System.Web.Security;
//引入HttpContext
using System.Web;
using System.Web.Http.WebHost;
using System.Web.SessionState;
using System.Web.Routing;
using AuthenticationDemo.Authentication;

namespace AuthenticationDemo.Controllers
{
    public static class HttpTool
    {
        //session为null： 需要在注册api路由需将RouteHandler 改写，才能使用
        //建立HttpControllerHandler和HttpControllerRouteHandler 并覆写它
        public class SessionRouteHandler : HttpControllerHandler, IRequiresSessionState
        {
            public SessionRouteHandler(RouteData routeData) : base(routeData)
            {

            }
        }

        public class SessionControllerRouteHandler : HttpControllerRouteHandler
        {
            protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
            {

                return new SessionRouteHandler(requestContext.RouteData);

            }
        }

        public static bool IsValidate(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return false;
            }

            if(s.Length < 6)
            {
                return false;
            }

            return true;
        }
    }

    public class AuthenticationDemoController : ApiController
    {
        [HttpGet]
        public object AuthenticationTestApi(string UserName, string Password)
        {
            if (!HttpTool.IsValidate(UserName)
                || !HttpTool.IsValidate(Password))
            {
                return "账号或密码格式错误";
            }

            //
            // 摘要:
            //     使用 cookie 名、版本、目录路径、发布日期、过期日期、持久性以及用户定义的数据初始化 System.Web.Security.FormsAuthenticationTicket
            //     类的新实例。
            //
            // 参数:
            //   version:
            //     票证的版本号。
            //
            //   name:
            //     与票证关联的用户名。
            //
            //   issueDate:
            //     票证发出时的本地日期和时间。
            //
            //   expiration:
            //     票证过期时的本地日期和时间。
            //
            //   isPersistent:
            //     如果票证将存储在持久性 Cookie 中（跨浏览器会话保存），则为 true；否则为 false。如果该票证存储在 URL 中，将忽略此值。
            //
            //   userData:
            //     存储在票证中的用户特定的数据。
            //
            //   cookiePath:
            //     票证存储在 Cookie 中时的路径。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, UserName, DateTime.Now,
                DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", UserName, Password),
                FormsAuthentication.FormsCookiePath);

            //返回用户登录结果 用户信息 用户验证票据信息
            //创建一个字符串，其中包含适用于 HTTP Cookie 的加密的 Forms 身份验证票证。
            //
            // 参数:
            //   ticket:
            //     用于创建加密的 Forms 身份验证票证的 System.Web.Security.FormsAuthenticationTicket 对象。
            //
            // 返回结果:
            //     一个字符串，其中包含加密的 Forms 身份验证票证。
            var UserInfo = new UserInfo { bRes = true, UserName = UserName, Password = Password, Ticket = FormsAuthentication.Encrypt(ticket) };

            //将身份信息保存到session  验证当前请求是否有效
            //WebApi默认是没有开启Session的: 需要在注册api路由需将RouteHandler 改写，才能使用
            HttpContext.Current.Session[UserName] = UserInfo;

            return UserInfo;
        }

        //[RequestAuthorize]
        [HttpPost]
        public string TestAfterLogin()
        {
            return "登录之后的带验证请求示例";
        }
    }
}
