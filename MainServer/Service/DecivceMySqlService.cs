using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;

namespace MainServer.Service
{
    public class DecivceMySqlService
    {
        [NotNull]
        MySqlConnection connection_device_data=new MySqlConnection("server=xxxxx;database=device_data;username=xxxxxx;password=xxxxx;");
        public DecivceMySqlService()
        {
            var res = Conn();
            if (res=="OK")
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
            catch(Exception e)
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
        
        public bool AuthDevice(string id,string user)
        {
            string sql = "SELECT * FROM device WHERE id='"+ id + "' AND user='"+ user+"';";//MySql语句，查询列表内容
            MySqlCommand cmd = new MySqlCommand(sql, connection_device_data);
            MySqlDataReader reader = cmd.ExecuteReader();//执行一些查询
                                                         //cmd.ExecuteScalar();//执行一些查询，返回一个单个的值
                                                         //读取第一次Read()，ke输出读取第一列数据，如果再Read()一次，可输出读取第二列数据，但是只能读取第二列数据
                                                         //reader.Read();//读取一列数据如果读取(有数据)成功，返回True,如果没有（数据），读取失败的话返回false
            return reader.Read();
        }
    }
}
