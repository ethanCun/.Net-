using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Image_Upload.Tool
{
    public class ImageBase64Convert<T>
    {
        /// <summary>
        /// base64转Image
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="base64Str"></param>
        public static CommonResult<T> Base64StringToImage(string Name, string base64Str)
        {
            CommonResult<T> result = new CommonResult<T> { Code = Code.Success, Message = "", Result = default(T) };

            try
            {
                string inputStr = base64Str;

                //将base64转成byte[]
                byte[] bytes = Convert.FromBase64String(inputStr);

                //bytes -> MemoryStream
                MemoryStream ms = new MemoryStream(bytes);

                //MemoryStream -> Bitmap
                Bitmap bmap = new Bitmap(ms);

                //保存图片到指定路径
                bmap.Save(HttpContext.Current.Server.MapPath(@"~/Images/" + Name + ".jpg"), 
                    System.Drawing.Imaging.ImageFormat.Jpeg);

                ms.Close();

                result.Message = WebBase.GetRootPath() + @"Images/" + Name + ".jpg";

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());

                result.Code = Code.Failed;
                result.Message = "失败";

                return result;
            }
        }


        /// <summary>
        /// 图片转base64
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ImageName"></param>
        /// <returns></returns>
        public static CommonResult<T> ImageToBase64String<T>(string ImageName) where T:class
        {
            CommonResult<T> result = new CommonResult<T> { Code = Code.Success, Message = "", Result = default(T)};

            string path1 = HttpContext.Current.Server.MapPath(@"~/Images/" + ImageName);

            try
            {
                //Image途径实例化位图
                Bitmap bmap = new Bitmap(path1);

                //内存流
                MemoryStream ms = new MemoryStream();

                //将图片以jpeg形式 保存到内存流中
                bmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                //实例化内存流长度的byte数组
                byte[] arr = new byte[ms.Length];

                //设置内存流读的起始位置
                ms.Position = 0;

                //读取
                ms.Read(arr, 0 , (int)ms.Length);

                ms.Close();

                string base64 = Convert.ToBase64String(arr);

                result.Result = base64 as T;
                result.Message = "成功";

                return result;

            }catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());

                result.Code = Code.Failed;
                result.Message = "失败";

                return result;
            }
        }

    }
}