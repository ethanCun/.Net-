using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace HttpRequest.HttpBase
{
    public enum CommonResult
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Failed,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 0,

        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        Exception
    }

    /// <summary>
    /// 通用的返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Description("返回结果")]
    public class CommonHttpResult<T>
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        [Description("返回结果代码编号")]
        public CommonResult code { get; set; }

        /// <summary>
        /// 返回说明
        /// </summary>
        [Description("返回说明")]
        public string Message { get; set; }

        /// <summary>
        /// 返回的具体数据
        /// </summary>
        [Description("返回具体数据")]
        public T Data { get; set; }
    }
}