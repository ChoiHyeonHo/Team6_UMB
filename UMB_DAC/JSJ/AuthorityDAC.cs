using System;
using System.Collections.Generic;
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
    }
}
