using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JPush_Demo.Models;

namespace JPush_Demo.Controllers
{
    public class JPushController : ApiController
    {
        /// <summary>
        /// 通知广播
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="json">json数据</param>
        /// <returns></returns>
        [HttpPost]
        public string NotiAll(JPushModel model)
        {
            return Jpush.JPushAll(model.Title, model.Content, model.Json);
        }

        /// <summary>
        /// 通知别名
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="json">Json数据</param>
        /// <param name="aliases">别名组合</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public string NotiAliases(JPushModel model)
        {
            return Jpush.JPushAliases(model.Title, model.Content, model.Json, model.aliases);
        }

        /// <summary>
        /// 消息广播
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="json">json数据</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public string MessageAll(JPushModel model)
        {
            return Jpush.JPushMessageAll(model.Title, model.Content, model.Json);
        }

        /// <summary>
        /// 消息别名推送
        /// </summary>
        /// <param name="title">消息推送</param>
        /// <param name="content">消息推送</param>
        /// <param name="json">json数据</param>
        /// <param name="aliases">别名组合</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public string MessageAliases(JPushModel model)
        {
            return Jpush.JPushMessageAliases(model.Title, model.Content, model.Json, model.aliases);
        }

    }
}
