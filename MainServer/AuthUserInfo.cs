using MainServer.Service;

namespace MainServer
{
    public class AuthUserInfo
    {
        UserMySqlService UserMySqlService= new UserMySqlService();
        public bool UserConfirmed(string name,string pwd)
        {
            return UserMySqlService.AuthUser(pwd: pwd, user: name);
        }
    }
}
