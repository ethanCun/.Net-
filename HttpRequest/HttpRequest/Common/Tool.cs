using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace HttpRequest.Common
{
    public static class Tool
    {


        /// <summary>
        /// 数组包含字典情况：将参数按照1=1&2=2&3=3的方式拼接起来
        /// </summary>
        /// <param name="paramArray"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string BuildParam(List<KeyValuePair<string, string>> paramArray, Encoding encoding)
        {
            string url = "";

            //不过没有编码则用UTF8编码
            if(encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            if(paramArray == null || paramArray.Count == 0)
            {
                return "";
            }
            else
            {
                string paramStr = "";

                foreach(var item in paramArray)
                {
                    paramStr += String.Format("{0}={1}&", Encode(item.Key, encoding), Encode(item.Value, encoding));
                }

                if (paramStr != "")
                {
                    paramStr = paramStr.TrimEnd('&');
                }

                url += paramStr;
            }

            return url;
        }

        /// <summary>
        /// 字典 将键值对以&符号拼接起来
        /// </summary>
        /// <param name="param"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string BuildParam(Dictionary<string, string> param, Encoding encoding)
        {
            if(encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            string paramStr = "";

            foreach(KeyValuePair<string, string> kv in param)
            {
                paramStr = String.Format("{0}={1}&", Encode(kv.Key, encoding), Encode(kv.Value, encoding));
            }

            paramStr = paramStr.TrimEnd('&');

            return paramStr;
        }

        /// <summary>
        /// 将字符串转成UTF8编码
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static string Encode(string content, Encoding encoding)
        {
            if(encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return System.Web.HttpUtility.UrlEncode(content, encoding);
        }
    }
}