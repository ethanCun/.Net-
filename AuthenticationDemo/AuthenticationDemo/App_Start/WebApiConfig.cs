using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Routing;
using static AuthenticationDemo.Controllers.HttpTool;

namespace AuthenticationDemo
{
    public static class WebApiConfig
    {
#if false
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
#endif

        //session为null： 需要在注册api路由需将RouteHandler 改写，才能使用
        //建立HttpControllerHandler和HttpControllerRouteHandler 并覆写它
        public static void Register(HttpConfiguration config)
        {
            RouteTable.Routes.MapHttpRoute(

            name: "DefaultApi",

            routeTemplate: "api/{controller}/{action}/{id}",

            defaults: new { id = RouteParameter.Optional }

            ).RouteHandler = new SessionControllerRouteHandler();
        }
    }
}
