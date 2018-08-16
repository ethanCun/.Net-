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
using System.Web;

//petapoco
using PetaPoco;

using Image_Upload.Models;
using Image_Upload.Tool;

namespace Image_Upload.Controllers
{
    public class UploadController : ApiController
    {
        private Database db = new Database("client");

        [HttpPost]
        //[Route("api/Upload")] web
        public async Task<string> Upload(string guid)
        {
            //检查是否是 multipart/form-data 
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            // 文件保存目录路径
            //关于Server.MapPath和HostingEnvironment.MapPath:
            //https://blog.csdn.net/xrjohn/article/details/50952503
            //string UploadFilePath = HostingEnvironment.MapPath("~/Upload");
            string UploadFilePath = HttpContext.Current.Server.MapPath("~/Images");

            //如果路径不存在 创建路径
            if (Directory.Exists(UploadFilePath))
            {
                Directory.CreateDirectory(UploadFilePath);
            }

            List<string> files = new List<string>();

            // 设置上传目录 
            var provider = new WithExtensionMultipartFormDataStreamProvider(UploadFilePath, guid);

            try
            {
                //读取data
                var task = await Request.Content.ReadAsMultipartAsync(provider);

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

        /// <summary>
        /// Base64转Image
        /// </summary>
        /// <param name="ImageName"></param>
        /// <param name="base64Str"></param>
        /// 
        [HttpPost]
        public CommonResult<string> Base64ToImage(ImageConvert Model)
        {
            CommonResult<string> res = ImageBase64Convert<string>.Base64StringToImage(Model.Name, Model.ImageBase64Str);

            if(res.Code == Code.Success)
            {
                //插入数据库
                Client client = new Client();
                client.Name = Model.Name;
                client.Avator = res.Message;

                object obj = db.Insert("client_info", "Id", client);

                if((int)obj > 0)
                {
                    Console.WriteLine("新增成功");
                }
                else
                {
                    Console.WriteLine("新增失败");
                }
            }

            return res;
        }

        /// <summary> 
        /// Image转Base64字符串 app
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public CommonResult<string> ImageToBase64Str(string Name)
        {

            CommonResult<string> res = ImageBase64Convert<string>.ImageToBase64String<string>(Name);

            return res;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpPost]
        public Client GetClientInfo(string Name)
        {
            Client client = db.SingleOrDefault<Client>("select * from client_info where Name=" + "'" + Name+"'");

            return client;
        }

        /// <summary>
        /// 获取网站站点
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetRootPath()
        {
            return WebBase.GetRootPath();
        }
    }
}
