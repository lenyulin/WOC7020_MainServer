using MainServer.Service;

namespace MainServer
{
    public class AuthDeviceInfo
    {
        DecivceMySqlService decivceMySqlService = new DecivceMySqlService();
        public bool UserConfirmed(string name,string id)
        {
            return decivceMySqlService.AuthDevice(id: id, user: name);
        }
    }
}
