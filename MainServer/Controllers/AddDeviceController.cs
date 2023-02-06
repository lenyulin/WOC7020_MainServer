using MainServer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDeviceController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] string body)
        {
            body.Remove(body.Length-1);
            body.Remove(0);
            Console.WriteLine(body);
            var c =body.Split('+');
            try
            {
                string id = c[0];
                string name = c[1];
                string key = c[2];
                if (key != "")
                {
                    AddDeviceService addDeviceService = new AddDeviceService();
                    var res=addDeviceService.Add(id: id, user: name);
                    return res;
                }
                return "-1";
            }
            catch (Exception E)
            {
                return "-1";
            }
        }
    }
}
