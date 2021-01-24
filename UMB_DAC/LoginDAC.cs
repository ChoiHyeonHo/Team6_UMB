using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class LoginDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public LoginDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void Login(int ID, int Pwd)
        {
            LoginVO.User user = new LoginVO.User();

            string sql = $"select user_id, department_id from TBL_USER where user_id = @user_id and user_pwd = @user_pwd";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {

                cmd.Parameters.AddWithValue("@user_id", ID);
                cmd.Parameters.AddWithValue("@user_pwd", Pwd);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user.ID = int.Parse(reader["user_id"].ToString());
                    user.Department = int.Parse(reader["department_id"].ToString());
                }
                LoginVO.user = user;
            }
        }
    }
}
