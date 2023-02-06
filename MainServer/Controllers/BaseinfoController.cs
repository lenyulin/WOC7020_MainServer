using MainServer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Diagnostics.CodeAnalysis;

namespace MainServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseinfoController : ControllerBase
    {
        [HttpGet]
        public string Get(int id)//, int dt, int keys
        {
            DeviceBaseInfoMysqlService infoMysqlService= new DeviceBaseInfoMysqlService();
            return infoMysqlService.GetInfo(id.ToString());
        }
    }
}
