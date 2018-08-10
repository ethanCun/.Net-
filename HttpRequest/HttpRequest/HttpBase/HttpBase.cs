using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Formatting;


namespace HttpRequest.HttpBase
{
    public static class NetWorkManager
    {
        /// <summary>
        /// 封装的post请求 
        /// </summary>
        /// <typeparam name="T">请求地址</typeparam>
        /// <param name="url">请求内容：字符串</param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static T PostParam<T>(string url, string postData) where T : class, new()
        {
            //https
            if (url.StartsWith("https"))
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;
            }

            //http请求内容
            HttpContent httpContent = new StringContent(postData);
            //http请求header
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpClient httpclient = new HttpClient();

            T result = default(T);

            HttpResponseMessage response = httpclient.PostAsync(url, httpContent).Result;

            //是否响应成功
            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }

            return result;
        }

        /// <summary>
        /// HttpClient 封装的Post请求 带对象参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T PostParam<T>(string url, Dictionary<string, string> param) where T:class, new()
        {
            //https
            if (url.StartsWith("https"))
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;
            }

            //内容
            HttpContent httpContent = new ObjectContent(typeof(Dictionary<string, string>), param, new JsonMediaTypeFormatter());

            //headers
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpClient httpClient = new HttpClient();

            //post请求
            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            T result = default(T);

            if (response.IsSuccessStatusCode)
            {
                string s = response.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }

            return result;
        }

        /// <summary>
        /// 封装的 HttpClient Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T StartPostWithParam<T>(string requestUrl, object param) where T:class, new()
        {
            T result = default(T);

            if (requestUrl == "" 
                || requestUrl == null
                || requestUrl == "{url}")
            {
                CommonHttpResult<string> res = new CommonHttpResult<string> { code = CommonResult.Exception, Message = "请求url为null", Data = "" };

                return res as T;
            }

            //https
            if (requestUrl.StartsWith("https"))
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;
            }

            //内容
            HttpContent content = new ObjectContent(typeof(object), param, new JsonMediaTypeFormatter());

            //传输方式
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            //
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = httpClient.PostAsync(requestUrl, content).Result;


            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }
    }
}