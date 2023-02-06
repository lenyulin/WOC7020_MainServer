using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MainServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgeController : ControllerBase
    {
        [HttpGet]
        public string Get(string id)
        {
            DeviceAuthService deviceAuthService= new DeviceAuthService();
            string user = deviceAuthService.AuthId(id);
            if (user != "-1")
            {
                string url = "localhost";
                return url+","+user;
            }
            else
            {
                return "-1";
            }
        }
    }
}
