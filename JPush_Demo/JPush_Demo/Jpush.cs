using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jiguang.JPush;
using Jiguang.JPush.Model;
//引入ArrayList
using System.Collections;
//引入ConfigurationManager
using System.Configuration;

namespace JPush_Demo
{
    public class Jpush
    {
        public static string AppKey = ConfigurationManager.AppSettings["JPushAppKey"];
        public static string Master_Secret = ConfigurationManager.AppSettings["JPushMasterSecret"];

        #region 广播
        /// <summary>
        /// 全员广播
        /// </summary>
        /// <param name="title">广播标题</param>
        /// <param name="content">广播内容</param>
        /// <param name="json">json数据</param>
        /// <returns></returns>
        public static string JPushAll(string title, string content, Dictionary<string, object> json)
        {
            JPushClient jpushClient = new JPushClient(AppKey, Master_Secret);

            PushPayload payload = new PushPayload();
            payload.Platform = "all";
            payload.Audience = "all";

            Notification noti = new Notification();
            noti.Alert = content;
            noti.Android = new Android() { Alert = content, Title = title, Extras = json };
            noti.IOS = new IOS() { Alert = content, Category = title, Extras = json };
            payload.Notification = noti;

            Jiguang.JPush.Model.HttpResponse response = jpushClient.SendPush(payload);

            return response.Content;
        }

        /// <summary>
        /// 指定别名广播
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="json">推送内容</param>
        /// <param name="aliases">别名集合</param>
        /// <returns></returns>
        public static string JPushAliases(string title, string content, Dictionary<string, object> json, ArrayList aliases)
        {
            JPushClient jpushClient = new JPushClient(AppKey, Master_Secret);

            PushPayload payload = new PushPayload();
            payload.Platform = "all";

            Dictionary<string, ArrayList> audis = new Dictionary<string, ArrayList>();
            audis.Add("alias", aliases);
            payload.Audience = audis;

            Notification noti = new Notification();
            noti.Alert = title;
            noti.Android = new Android() { Title = title, Alert = content, Extras = json };
            noti.IOS = new IOS() { Alert = content, Category = title, Extras = json };
            payload.Notification = noti;

            Jiguang.JPush.Model.HttpResponse response = jpushClient.SendPush(payload);

            return response.Content;
        }
        #endregion

        #region 消息
        /// <summary>
        /// 全员消息
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="json">json数据</param>
        /// <returns></returns>
        public static string JPushMessageAll(string title, string content, Dictionary<string, object> json)
        {
            JPushClient jpushClient = new JPushClient(AppKey, Master_Secret);

            PushPayload payload = new PushPayload();
            payload.Platform = "all";
            payload.Audience = "all";

            Message msg = new Message();
            msg.Content = content;
            msg.Title = title;
            msg.Extras = json;
            msg.ContentType = "text";

            payload.Message = msg;

            Jiguang.JPush.Model.HttpResponse response = jpushClient.SendPush(payload);

            return response.Content;
        }

        /// <summary>
        /// 别名消息
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="json">json数据</param>
        /// <param name="aliases">别名集合</param>
        /// <returns></returns>
        public static string JPushMessageAliases(string title, string content, Dictionary<string, object> json, ArrayList aliases)
        {
            JPushClient jpushClient = new JPushClient(AppKey, Master_Secret);

            PushPayload payload = new PushPayload();
            payload.Platform = "all";

            Dictionary<string, ArrayList> aliasSet = new Dictionary<string, ArrayList>();
            aliasSet.Add("alias", aliases);
            payload.Audience = aliasSet;

            Message msg = new Message();
            msg.ContentType = "text";
            msg.Title = title;
            msg.Content = content;
            msg.Extras = json;

            payload.Message = msg;

            Jiguang.JPush.Model.HttpResponse response = jpushClient.SendPush(payload);

            return response.Content;
        }

        #endregion

    }
}