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
    }
}
