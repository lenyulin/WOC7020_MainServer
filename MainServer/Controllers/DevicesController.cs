using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MainServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        [HttpGet]
        public string Get(string name, int auth,int random)
        {
            //var payload = new Dictionary<string, int> { { "Local_Number_1", 21345 } };
            //var res = JsonConvert.SerializeObject(payload);
            string res = @"Local_Number_1,21345+Local_Number_1,23456";
            return res;
        }
    }
}
