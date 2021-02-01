using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class IncommingDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public IncommingDAC()
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

        public int IncommingWait(IncommingVO vo)
        {
            string sql = "insert into TBL_INCOMMING (incomming_date, incomming_rep, incomming_count, order_id) values(replace(convert(varchar(10), getdate(), 120), '-', '-'), @incomming_rep, @incomming_count, @order_id)";

            using (SqlCommand cmd = new SqlCommand("sql", conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@incomming_rep", vo.incomming_rep);
                    cmd.Parameters.AddWithValue("@incomming_count", vo.incomming_count);
                    cmd.Parameters.AddWithValue("@order_id", vo.order_id);

                    int iRow = cmd.ExecuteNonQuery();
                    return iRow;
                }
                catch(Exception err)
                {
                    string msg = err.Message;
                    return 0;
                }
            }
        }
    }
}
