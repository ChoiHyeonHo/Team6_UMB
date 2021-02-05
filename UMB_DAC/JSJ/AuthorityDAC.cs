using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class AuthorityDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public AuthorityDAC()
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

        public (List<DepartmentVO>, List<MenuVO>) DepartmentList()
        {
            List<DepartmentVO> department;
            List<MenuVO> menu = null;

            string sql = @"select department_id, department_name, department_comment from TBL_DEPARTMENT
                           select common_name from TBL_COMMON_CODE where common_type = '화면이름'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                department = Helper.DataReaderMapToList<DepartmentVO>(reader);
                if(reader.NextResult())
                {
                    menu = Helper.DataReaderMapToList<MenuVO>(reader);
                }
                return (department, menu);
            }
        }    
        
        public int UpdateAuthority(List<AuthorityVO> list, int department_id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "delete TBL_AUTHORITY where department_id = @department_id";
                cmd.Connection = conn;
                SqlTransaction trans = conn.BeginTransaction();

                cmd.Transaction = trans;

                try
                {
                    cmd.Parameters.AddWithValue("@department_id", department_id);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "insert into TBL_AUTHORITY (department_id, auth_formname, auth_uadmin, auth_udate) values(@department_id, @auth_formname, @auth_uadmin, replace(convert(varchar(10), getdate(), 120), '-', '-'))";

                    cmd.Parameters.Add("@auth_formname", SqlDbType.NVarChar);
                    cmd.Parameters.AddWithValue("@auth_uadmin", LoginVO.user.Name);
                    foreach (AuthorityVO Authority in list)
                    {
                        cmd.Parameters["@auth_formname"].Value = Authority.auth_formname;

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    conn.Close();
                    return 1;
                }
                catch (Exception err)
                {
                    string msg = err.Message;
                    trans.Rollback();
                    conn.Close();
                    return 0;
                }
            }
        }

        //public List<AuthorityVO> MenuCheck(int department_id)
        //{
        //    string sql = "select auth_formname from TBL_AUTHORITY where department_id = @department_id";

        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@department_id", department_id);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        List<AuthorityVO> list = Helper.DataReaderMapToList<AuthorityVO>(reader);
        //        return list;
        //    }
        //}

        public List<string> MenuCheck(int department_id)
        {
            string sql = "select auth_formname from TBL_AUTHORITY where department_id = @department_id";
            List<string> list = new List<string>();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@department_id", department_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    list.Add(Convert.ToString(reader["auth_formname"]));
                }
                conn.Close();
                return list;
            }
        }
    }
}
