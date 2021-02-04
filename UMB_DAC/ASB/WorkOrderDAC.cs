using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.ASB;

namespace UMB_DAC.ASB
{
    public class WorkOrderDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public WorkOrderDAC()
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

        public List<WorkOrderVO> GetWoList()
        {
            string sql = @"select wo_id, so_id, wo.product_id, product_name, wo.m_id, m_name, wo_pcount, wo_count,  CONVERT(CHAR(10), wo_date, 23) wo_date,CONVERT(CHAR(10), wo_sdate, 23) wo_sdate, wo_state, wo_uadmin, wo_udate
from TBL_WORK_ORDER wo inner join TBL_PRODUCT p on wo.product_id = p.product_id
inner join TBL_MACHINE m on wo.m_id = m.m_id
";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkOrderVO> list = Helper.DataReaderMapToList<WorkOrderVO>(reader);
                Dispose();
                return list;
            }
        }
    }
}
