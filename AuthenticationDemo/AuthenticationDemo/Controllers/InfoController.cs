using AuthenticationDemo.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthenticationDemo.Controllers
{
    //在具体的Api接口增加我们上面自定义类的特性
    //增加了特性标注之后，每次请求这个API里面的接口之前，
    //程序会先进入到我们override过的 OnAuthorization() 方法里面，
    //验证通过之后，才会进到相应的方法里面去执行，否则返回401。
    [RequestAuthorize]
    public class InfoController : ApiController
    {
        [HttpGet]
        public string string1()
        {
            return "这个接口需要header里进行授权";
        }

        /// <summary>
        /// AllowAnonymous:允许匿名，允许某一个方法不需要header验证
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public string string2()
        {
            return "加上AllowAnonymous允许某个接口不需要header验证";
        }
    }
}
