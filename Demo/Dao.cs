using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;




namespace Demo
{
    class Dao
    {
        SqlConnection sc1;
        public SqlConnection connection()
        {
         string str = "Server=LAPTOP-PMDRRHMT;Database=Demo;User Id=sa;Password=sql123456;";
         SqlConnection sc = new SqlConnection(str);
         sc.Open();//打开数据库链接
         return sc;
        }
        public SqlCommand command(string sql)
        {
            
            SqlCommand sc = new SqlCommand(sql,connection());
            return sc;
        }

        //用于delete updata insert,返回受影响的行数
        public int Excute(string sql)
        {
            using (var cmd = command(sql))
            {
                return cmd.ExecuteNonQuery();
            }
        }
        //用于select,返回SqldataReader对象，包含select到的数据
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
    }

        

}


