using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class DepartmentDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public DepartmentDAC()
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

        public List<DepartmentVO> DepartmentCboList()
        {
            string sql = "select department_id, department_name from TBL_DEPARTMENT";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<DepartmentVO> list = Helper.DataReaderMapToList<DepartmentVO>(reader);
                return list;
            }
        }

        public List<DepartmentVO> DepartmentList()
        {
            string sql = "select department_id, department_name, department_uadmin, department_udate from TBL_DEPARTMENT";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<DepartmentVO> list = Helper.DataReaderMapToList<DepartmentVO>(reader);
                return list;
            }
        }

        public int InsertDept(DepartmentVO vo)
        {
            string sql = "insert into TBL_DEPARTMENT (department_name, department_comment) values(@department_name, @department_comment)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@department_name", vo.department_name);
                    cmd.Parameters.AddWithValue("@department_comment", vo.department_comment);

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

        public DepartmentVO DetailDepartment(int department_id)
        {
            string sql = "select department_name, department_comment from TBL_DEPARTMENT where department_id = @department_id";
            
            using(SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@department_id", department_id);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                DepartmentVO vo = new DepartmentVO()
                {
                    department_name = reader["department_name"].ToString(),
                    department_comment = reader["department_comment"].ToString()
                };
                return vo;
            }
        }

        public int UpdateDept(DepartmentVO vo)
        {
            string sql = "update TBL_DEPARTMENT set department_name = @department_name, department_comment = @department_comment, department_udate = replace(convert(varchar(10), getdate(), 120), '-', '-'), department_uadmin = @department_uadmin where department_id = @department_id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@department_id", vo.department_id);
                    cmd.Parameters.AddWithValue("@department_name", vo.department_name);
                    cmd.Parameters.AddWithValue("@department_comment", vo.department_comment);
                    cmd.Parameters.AddWithValue("@department_uadmin", vo.department_uadmin);

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
    }
}
