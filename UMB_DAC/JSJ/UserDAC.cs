using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class UserDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public UserDAC()
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

        public List<UserVO> UserList()
        {
            using (SqlCommand cmd = new SqlCommand("SP_UserList", conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<UserVO> list = Helper.DataReaderMapToList<UserVO>(reader);
                return list;
            }
        }

        public int RegistUser(UserVO vo)
        {
            string sql = @"insert into TBL_USER (user_name, user_national, user_hiredate, user_pwd, user_phone, user_birth, department_id) 
                           values(@user_name, @user_national, @user_hiredate, @user_pwd, @user_phone, @user_birth, @department_id)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user_name", vo.user_name);
                    cmd.Parameters.AddWithValue("@user_national", vo.user_national);
                    cmd.Parameters.AddWithValue("@user_hiredate", vo.user_hiredate);
                    cmd.Parameters.AddWithValue("@user_pwd", vo.user_pwd);
                    cmd.Parameters.AddWithValue("@user_phone", vo.user_phone);
                    cmd.Parameters.AddWithValue("@user_birth", vo.user_birth);
                    cmd.Parameters.AddWithValue("@department_id", vo.department_id);

                    int iRow = cmd.ExecuteNonQuery();
                    return iRow;
                }
            }
            catch(Exception err)
            {
                string msg = err.Message;
                return 0;
            }
        }

        public UserVO userDetail(int user_id)
        {
            string sql = "select user_name, user_national, user_hiredate, user_pwd, user_phone, user_birth, department_id from TBL_USER where user_id = @user_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@user_id", user_id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                UserVO vo = new UserVO()
                {
                    user_name = reader["user_name"].ToString(),
                    user_national = reader["user_national"].ToString(),
                    user_hiredate = reader["user_hiredate"].ToString(),
                    user_pwd = reader["user_pwd"].ToString(),
                    user_phone = reader["user_phone"].ToString(),
                    user_birth = reader["user_birth"].ToString(),
                    department_id = int.Parse(reader["department_id"].ToString())
                };
                return vo;
            }
        }

        public int UpdateUser(UserVO vo)
        {
            string sql = "update TBL_USER set user_name = @user_name, user_national = @user_national, user_hiredate = @user_hiredate, user_pwd = @user_pwd, user_phone = @user_phone, user_birth = @user_birth, department_id = @department_id, user_udate = replace(convert(varchar(10), getdate(), 120), '-', '-') where user_id = @user_id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", vo.user_id);
                    cmd.Parameters.AddWithValue("@user_name", vo.user_name);
                    cmd.Parameters.AddWithValue("@user_national", vo.user_national);
                    cmd.Parameters.AddWithValue("@user_hiredate", vo.user_hiredate);
                    cmd.Parameters.AddWithValue("@user_pwd", vo.user_pwd);
                    cmd.Parameters.AddWithValue("@user_phone", vo.user_phone);
                    cmd.Parameters.AddWithValue("@user_birth", vo.user_birth);
                    cmd.Parameters.AddWithValue("@department_id", vo.department_id);

                    int iRow = cmd.ExecuteNonQuery();
                    return iRow;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return 0;
            }
        }

        public int EndUser(int user_id)
        {
            string sql = "update TBL_USER set user_enddate = replace(convert(varchar(10), getdate(), 120), '-', '-') where user_id = @user_id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", user_id);

                    int iRow = cmd.ExecuteNonQuery();
                    return iRow;
                }
            }
            catch(Exception err)
            {
                string msg = err.Message;
                return 0;
            }
        }
    }
}
