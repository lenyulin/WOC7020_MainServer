using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace MainServer.Service
{
    public class AddDeviceService
    {
        [NotNull]
        MySqlConnection connection_device_data = new MySqlConnection("server=43.156.64.6;database=device_data;username=lenyulin;password=Java19970203..;");

        public AddDeviceService()
        {
            var res = Conn();
            if (res == "OK")
            {
                Console.WriteLine("Connect Succeed !");
            }
            else
            {
                Console.WriteLine("Connect Faild : " + res);
            }
        }
        public string Conn()
        {
            try
            {
                connection_device_data.Open();
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public bool DisConnection()
        {
            try
            {
                connection_device_data.Close();
                return true;
            }
            catch { return false; }
        }
        public string Search(string id)
        {
            try
            {
                string sql = "SELECT * FROM device WHERE id='" + id + "';";//MySql语句，查询列表内容
                MySqlCommand cmd = new MySqlCommand(sql, connection_device_data);
                MySqlDataReader reader = cmd.ExecuteReader();//执行一些查询
                                                             //cmd.ExecuteScalar();//执行一些查询，返回一个单个的值
                                                             //读取第一次Read()，ke输出读取第一列数据，如果再Read()一次，可输出读取第二列数据，但是只能读取第二列数据
                                                             //reader.Read();//读取一列数据如果读取(有数据)成功，返回True,如果没有（数据），读取失败的话返回false
                DeviceInfoMember device = new DeviceInfoMember();
                if (reader.Read())
                {
                    connection_device_data.Close();
                    reader.Close();
                    return "Device is Registered";
                }
                connection_device_data.Close();
                reader.Close();
                return "OK";
            }
            catch
            {
                return "Mysql Error";
            }
        }
        public string Add(string id, string user)
        {
            var res = Search(id);
            if (res!="OK")
            {
                return res;
            }
            Conn();
            try
            {
                //INSERT INTO `device_data`.`device` (`id`, `user`) VALUES ('56789', 'lenyulin')
                string sql = "INSERT INTO `device_data`.`device` (`id`, `user`) VALUES ('"+id+"','"+user+"')";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, connection_device_data);
                int Cmd = cmd.ExecuteNonQuery();//执行一些查询
                connection_device_data.Close();
                return "OK";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "-1";
            }
        }
    }
}
