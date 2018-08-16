using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Image_Upload.Tool
{
    public enum Code{

        Success = 0,

        Failed,

        UnAuthentation,
    }

    public class CommonResult<T>
    {
        public Code Code { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }
    }
}