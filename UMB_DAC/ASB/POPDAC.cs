using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_DAC.ASB
{
    public class POPDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public POPDAC()
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

        public int setTacttime(string product_id)
        {
            int time;
            string sql = @"select bor_tacttime 
                        from TBL_BOR
                        where product_id = @product_id";
            
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                
                cmd.Parameters.AddWithValue("@product_id", product_id);

                time = Convert.ToInt32(cmd.ExecuteScalar());
                Dispose();
            }
            return time;
        }

        public bool updatePOP(int wo_id)
        {
            int result;
            string sql = @"update TBL_WORK_ORDER set wo_state = '작업중'
                            where = @wo_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {

                cmd.Parameters.AddWithValue("@wo_id", wo_id);

                result = cmd.ExecuteNonQuery();
                Dispose();

                return result > 0;
            }
        }
    }
}
