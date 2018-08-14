using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Image_Upload.Upload
{
    public class WithExtensionMultipartFormDataStreamProvider: MultipartFormDataStreamProvider
    {
        public string guid { get; set; }

        public WithExtensionMultipartFormDataStreamProvider(string rootPath, string guidStr):base(rootPath)
        {
            guid = guidStr;
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            //IsNullOrWhiteSpace:指示指定的字符串是 null、空还是仅由空白字符组成
            //返回指定的路径字符串的扩展名: Path.GetExtension
            string extension = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ?
                Path.GetExtension(GetValidFileName(headers.ContentDisposition.FileName)) : "";

            return guid + extension;
        }

        private string GetValidFileName(string filePath)
        {
            //获取包含不允许在文件名中使用的字符的数组
            char[] invalids = Path.GetInvalidFileNameChars();
            //StringSplitOptions.RemoveEmptyEntries:返回值不包括含有空字符串的数组元素
            return string.Join("_", filePath.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
        }
    }
}