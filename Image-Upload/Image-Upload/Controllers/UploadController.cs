using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;


//HostingEnvironment
using System.Web.Hosting;
//Directory
using System.IO;
using System.Threading.Tasks;
using Image_Upload.Upload;
using System.Web.Http;
using System.Net.Http;

namespace Image_Upload.Controllers
{
    public class UploadController : ApiController
    {
        [HttpPost]
        //[Route("api/Upload")]
        public async Task<string> Upload(string guid)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            
            string UploadFilePath = HostingEnvironment.MapPath("~/Upload");

            //如果路径不存在 创建路径
            if (Directory.Exists(UploadFilePath))
            {
                Directory.CreateDirectory(UploadFilePath);
            }

            List<string> files = new List<string>();

            var provider = new WithExtensionMultipartFormDataStreamProvider(UploadFilePath, guid);

            try
            {
                //读取data
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    files.Add(Path.GetFileName(file.LocalFileName));
                }
            }
            catch
            {
                throw;
            }

            return string.Join(",", files);
        }
    }
}
