using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JPush_Demo.Models
{
    public enum Code
    {
        Success = 0,

        Failed,

        UnAuthorized
    }

    public class CommonResult<T>
    {
        public Code Code { get; set; }

        public string Message { get; set; }

        public T result { get; set; }
    }
}