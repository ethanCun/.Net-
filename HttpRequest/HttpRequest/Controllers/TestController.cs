using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using HttpRequest.Common;
using HttpRequest.HttpBase;

namespace HttpRequest.Controllers
{
    public class TestController : ApiController
    {
        #region HttpClient
        /// <summary>
        /// 不带参数 简单的HttpClient get请求 
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public object SendRequestWithHttpClientReturnJson(string requestUrl)
        {
            var httpClient = new HttpClient();

            //json
            var responseJson = httpClient.GetAsync(requestUrl).Result.Content.ReadAsStringAsync().Result;

            //json序列化
            var res = JsonConvert.DeserializeObject(responseJson);

            return JsonConvert.DeserializeObject(responseJson);
        }

        /// <summary>
        /// 带参数的HttpClient get请求
        /// </summary>
        /// <param name="param"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpPost]
        public object SendReuqestWithHttpClientSignalParam(List<KeyValuePair<string, string>> param, string url)
        {
            HttpClient httpClient = new HttpClient();

            //将参数以1=1&2=2&3=3的方式拼接在url后面
            var urlString = url + "?" + Tool.BuildParam(param, Encoding.UTF8);

            var responseJson = httpClient.GetAsync(urlString).Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject(responseJson);
        }

        [HttpPost]
        public object SendRequestWithHttpClientSignalParam2(Dictionary<string, string> param, string url)
        {
            HttpClient httpClient = new HttpClient();

            var urlString = url + "?" + Tool.BuildParam(param, Encoding.UTF8);

            var responseJson = httpClient.GetAsync(urlString).Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject(responseJson);
        }

        /// <summary>
        /// 封装的HttpClient Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public object SendRe1(string url, string data)
        {
            return HttpBase.NetWorkManager.PostParam<object>(url, data);
        }

        /// <summary>
        /// 封装的HttpClient Post请求 发送一个键值对
        /// </summary>
        /// <param name="url"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object SendRe2(string url, Dictionary<string, string> para)
        {
            return HttpBase.NetWorkManager.PostParam<object>(url, para);
        }

        /// <summary>
        /// 封装的object参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object SendRe3(string url, object param)
        {
            return HttpBase.NetWorkManager.StartPostWithParam<object>(url, param);
        }

        #endregion

        #region HttpWebRequest

        /// <summary>
        /// 不带参数的HttpWebRequest请求
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public object SendRequestWithHttpWebRequest(string requestUrl)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);

            var response = request.GetResponse();

            var responseJson = "";

            //StreamReader需要引入System.IO  Encoding需要引入System.Text
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                responseJson = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject(responseJson);
        }

        /// <summary>
        /// HttpWebRequest post请求
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public object SendPostRequestWithHttpWebRequest (string requestUrl, Dictionary<string, string> param)
        {
            //创建httpWebRequest对象 
            //HttpWebRequest不能直接通过new来创建，只能通过WebRequest.Create(url)的方式来获得。 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);

            //请求类型 默认GET
            request.Method = "post";

            //现将字典转换成json字符串
            string paramStr = JsonConvert.SerializeObject(param);

            //转换输入参数的编码类型，获取bytep[] 数组
            byte[] bytes = Encoding.UTF8.GetBytes(paramStr);

            //内容长度
            request.ContentLength = bytes.Length;

            //
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                //输出流写入数据
                requestStream.Write(bytes, 0, bytes.Count());
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();

            if(httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException(string.Format("fail:{0}", httpResponse.StatusCode));
            }

            var responseJson = "";

            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8))
            {
                responseJson = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject(responseJson);
        }

        #endregion

    }
}
