using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        AuthUserInfo authInfo = new();
        [HttpPost]
        public string Post([FromBody] User user)
        {
            if (authInfo.UserConfirmed(user.user, user.pwd))
            {
                return "Ok";
            }
            else
                return "-1";
        }
    }
}
