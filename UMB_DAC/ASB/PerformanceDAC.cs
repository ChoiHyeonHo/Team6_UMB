using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.ASB;

namespace UMB_DAC.ASB
{
    public class PerformanceDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public PerformanceDAC()
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

        public List<PerformanceVO> SearchPerList(string pid, string process)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select performance_id, PER.production_id, PER.product_id, product_name, process_name, performance_qty_ok, performance_qty_ng, performance_qtyimport,
                        production_state,  CONVERT(CHAR(10), production_sdate, 23) production_sdate
                        from TBL_performance PER inner join TBL_Production P
                        on PER.production_id = P.production_id
                        inner join TBL_PRODUCT pro
                        on PER.product_id = pro.product_id
                        where 1=1 ");
            if (pid.Trim().Length > 0)
                sb.Append("and PER.production_id = @pid ");
            if (process.Trim().Length > 0)
                sb.Append("and process_name = @process ");
            string sql = sb.ToString();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@process", process);

                SqlDataReader reader = cmd.ExecuteReader();

                List<PerformanceVO> list = Helper.DataReaderMapToList<PerformanceVO>(reader);
                Dispose();

                return list;
            }
        }

        public List<PerformanceVO> GetPerList()
        {
            string sql = @"select performance_id, PER.production_id, PER.product_id, product_name, process_name, performance_qty_ok, performance_qty_ng, performance_qtyimport,
                        production_state,  CONVERT(CHAR(10), production_sdate, 23) production_sdate
                        from TBL_performance PER inner join TBL_Production P
                        on PER.production_id = P.production_id
                        inner join TBL_PRODUCT pro
                        on PER.product_id = pro.product_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                List<PerformanceVO> list = Helper.DataReaderMapToList<PerformanceVO>(reader);
                Dispose();
                return list;
            }
        }
    }
}
