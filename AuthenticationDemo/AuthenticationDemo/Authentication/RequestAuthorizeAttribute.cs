using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//AuthorizeAttribute
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace AuthenticationDemo.Authentication
{
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        //然后重写OnAuthorization方法，在这个方法里面取到请求头的Ticket信息，
        //然后校验用户名密码是否合理。
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;

            if((authorization != null) && ( authorization.Parameter != null))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.Parameter;

                if (ValidateTicket(encryptTicket))
                {
                    //base.OnAuthorization(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                // 如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }

            //在具体的Api接口增加我们上面自定义类的特性
            //增加了特性标注之后，每次请求这个API里面的接口之前，程序会先进入到我们override过的 OnAuthorization() 方法里面，
            //验证通过之后，才会进到相应的方法里面去执行，否则返回401。
        }

        /// <summary>
        /// 解密Ticket 并验证 
        /// 登录api创建Ticket时，存储在票证中的用户特定的数据为：string.Format("{0}&{1}", UserName, Password)
        /// </summary>
        /// <param name="encryptTicket"></param>
        /// <returns></returns>
        public bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;

            var index = strTicket.IndexOf("&");
            string strUser = strTicket.Substring(0, index);
            string strPas = strTicket.Substring(index + 1);

            if(strUser == "17673647340" && strPas == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);

            var authentication = actionContext.Request.Headers.Authorization;

        }
    }
}