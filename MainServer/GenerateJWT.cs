using JWT.Algorithms;
using JWT.Serializers;
using JWT;
using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MainServer
{
    public class GenerateJWT
    {
        public string GetToken(string id)
        {
            byte[] secret = System.Text.Encoding.Default.GetBytes("nishouya");
            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
            var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);
           // var pub = "[robotdata/${username},testpubtopic/public]" ;
           // var sub = new Dictionary<string, object> { { "robotcmd/${ username }", "testsubtopic/public" } };
            var secload = JToken.Parse(@"{""pub"":[""robotdata/${clientid}"",""robotwarning/${username}""],""sub"":[""robotcmd/${clientid}""]}");
            var payload = new Dictionary<string, object>{
        { "username", id },{"exp",(int)(secondsSinceEpoch+100)},{ "acl",secload } };
            var res=JsonConvert.SerializeObject(payload);
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(JToken.Parse(res), secret);
            return token;
        }
    }
}
