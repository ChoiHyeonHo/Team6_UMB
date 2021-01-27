using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC.ASB
{
    public class MachineDAC : ConnectionAccess, IDisposable
    {
        SqlConnection conn;
        string strConn;

        public MachineDAC()
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
        public List<MachineVO> GetMachineInfo()
        {
            string sql = @"select m_id, m_name
            from TBL_MACHINE";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<MachineVO> list = Helper.DataReaderMapToList<MachineVO>(reader);
                return list;
            }
        }
    }
}
