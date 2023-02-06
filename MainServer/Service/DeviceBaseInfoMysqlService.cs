using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace MainServer.Service
{
    public class DeviceBaseInfoMysqlService
    {
        [NotNull]
        MySqlConnection connection_device_data = new MySqlConnection("server=43.156.64.6;database=dataMirror;username=lenyulin;password=Java19970203..;");
        public DeviceBaseInfoMysqlService()
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

        public string GetInfo(string id)
        {
            try
            {
                string sql = "SELECT * FROM DeviceInfo WHERE Uid='" + id + "';";//MySql语句，查询列表内容
                MySqlCommand cmd = new MySqlCommand(sql, connection_device_data);
                MySqlDataReader reader = cmd.ExecuteReader();//执行一些查询
                                                             //cmd.ExecuteScalar();//执行一些查询，返回一个单个的值
                                                             //读取第一次Read()，ke输出读取第一列数据，如果再Read()一次，可输出读取第二列数据，但是只能读取第二列数据
                                                             //reader.Read();//读取一列数据如果读取(有数据)成功，返回True,如果没有（数据），读取失败的话返回false
                DeviceInfoMember device = new DeviceInfoMember();
                if (reader.Read())
                {
                    device.Uid = reader["Uid"].ToString();
                    device.SoftwareVer = reader["SoftwareVer"].ToString();
                    device.CPU = reader["CPU"].ToString();
                    device.Registration= reader["Registration"].ToString();

                }
                connection_device_data.Close();
                reader.Close();
                return JsonConvert.SerializeObject(device);
            }
            catch
            {
                return "-1";
            }
        }
    }
}
