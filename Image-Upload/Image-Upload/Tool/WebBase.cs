using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Image_Upload.Tool
{
    public class WebBase
    {
           /// <summary>
          /// 得到当前网站的根地址
          /// </summary>
          /// <returns></returns>
          public static string GetRootPath()
          {
              // 是否为SSL认证站点
              string secure = HttpContext.Current.Request.ServerVariables["HTTPS"];
              string httpProtocol = (secure == "on" ? "https://" : "http://");

             // 服务器名称
             string serverName = HttpContext.Current.Request.ServerVariables["Server_Name"];
             string port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];

             // 应用服务名称
             string applicationName = HttpContext.Current.Request.ApplicationPath;
             return httpProtocol + serverName + (port.Length > 0 ? ":" + port : string.Empty) + applicationName;
         }
    }
}