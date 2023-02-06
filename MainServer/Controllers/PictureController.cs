using JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace MainServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        [HttpPost]
        public string Post(IFormFile formFile, string id)//写入BODY.ID的文件夹下面
        {
            try
            {
                var ms = formFile.OpenReadStream();
                byte[] bytes = new byte[ms.Length];
                ms.Read(bytes, 0, bytes.Length);
                ms.Seek(0, SeekOrigin.Begin);
                string url = "./Image/"+id;
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + url))
                {

                }
                else
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + url);
                }
                IDateTimeProvider provider = new UtcDateTimeProvider();
                var now = provider.GetNow();
                var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
                var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);
                url = @"C:/Users/lyl69/source/repos/MainServer/MainServer/bin/Debug/net7.0/Image/"+id;
                string file=url+"/WarningAt"+ secondsSinceEpoch.ToString()+".jpg";
                System.IO.File.WriteAllBytes(file, bytes);
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
