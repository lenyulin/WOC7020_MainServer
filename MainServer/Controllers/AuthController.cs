using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWT;
using Microsoft.AspNetCore.Mvc.Formatters;
using JWT.Algorithms;
using MainServer.Service;

namespace MainServer.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        AuthDeviceInfo authInfo = new();
        [HttpPost]
        public string Post([FromBody] LoginForm form)
        {
            if (authInfo.UserConfirmed(form.name, form.id))
            {
                GenerateJWT generateJWT = new();
                return generateJWT.GetToken(form.name);
            }
            else
                return "-1";
        }
    }
}
