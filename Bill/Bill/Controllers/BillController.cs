using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

//IHttpActionResult在这个命名空间内
using System.Web.Http;

//
using System.Web.Http.Results;

using Bill.Models;
using Bill.Interface;
using System.Data.SqlClient;

namespace 对账单数据模型.Controllers
{
    public class BillController : ApiController
    {
        //对账单
        CkeckBillOperator blo = new CkeckBillOperator();

        /// <summary>
        /// 根据年月查询对账单信息
        /// </summary>
        /// <param name="gscode">客户编码</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IHttpActionResult GetBills(string gscode, string year, string month)
        {
            return Json<CheckBill>(blo.GetBills(gscode, year, month));
        }

        /// <summary>
        /// 测试返回类型的接口  返回类型为 ： Json<T>(T content)
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult SayWithIHttpActionResult()
        {
            string haha = "haha";

            return Json<string>(haha);
        }

        /// <summary>
        /// 返回值为void的接口 
        /// </summary>
        public void sayWithVoid()
        {
            
        }

        /// <summary>
        /// 返回值传递匿名类型
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult sayWithAnonymousType()
        {
            return Json<dynamic>(new { name="zhangsan", age=100, gender="男"} );
        }


        /// <summary>
        /// 返回值为Ok() 只告诉客户端返回成功 不返回任何数据
        /// </summary>
        /// <param name="haha"></param>
        /// <returns></returns>
        public IHttpActionResult sayWithOk2Result(string haha)
        {
            //直接返回Ok()表示告诉客户端返回成功 但是不返回任何类型
            return Ok();
        }

        /// <summary>
        /// 返回值类型传递 Ok<T>(T content)
        /// </summary>
        /// <param name="haha"></param>
        /// <returns></returns>
        public IHttpActionResult sayWithOK1Result(string haha)
        {
            //返回给客户端一个数据
            return Ok<String>(haha);
        }

        /// <summary>
        /// NotFound会返回一个404给客户端
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult NotFoundTest()
        {
            return NotFound();
        }

        /// <summary>
        /// 向客户端返回值和http状态码 Content<T>(HttpStatusCode statusCode, T value) 204 NO Content
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult NoThing()
        {
            return Content<string>(HttpStatusCode.NoContent, "没有找到相关内容");
        }

        /// <summary>
        /// 404
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult ErrorFound()
        {
            return Content<string>(HttpStatusCode.NotFound, "错误");
        }

        /// <summary>
        /// 400
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult BadRequest()
        {
            return Content<string>(HttpStatusCode.BadRequest, "无效请求：400");
        }

        /// <summary>
        /// 没有内容时 虽然设置了NoContent 但是啥也不返回
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult NoContent()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("code", 0);
            result.Add("message", "没有相关内容");

            return Content<Dictionary<string, object>>(HttpStatusCode.NoContent, result);
        }

        /// <summary>
        /// 正常返回内容 字典里面包含数组
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult ReturnContent()
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            res.Add("code", 0);
            res.Add("message", "查询成功");

            List<string> sts = new List<string>();
            for(int i=0; i < 10; i++)
            {
                sts.Add("zhangsan");
            }

            res.Add("data", sts);

            return Content<Dictionary<string, object>>(HttpStatusCode.OK, res);
        }

        /// <summary>
        /// 没有数据的时候返回编码以及结果提示文字
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult ReturnMessageWhenNoContent()
        {
            Dictionary<string, object> res = new Dictionary<string, object>();

            List<string> data = new List<string>();

            if(data.Count == 0)
            {
                res.Add("code", 1);
                res.Add("message", "没有相关数据");
            }
            else
            {
                res.Add("code", 0);
                res.Add("message", "数据获取成功");
            }

            res.Add("data", data);

            return Content<Dictionary<string, object>>(HttpStatusCode.OK, res);
        }
    }
}
