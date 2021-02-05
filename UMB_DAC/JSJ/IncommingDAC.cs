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

        public int IncommingWait(List<IncommingVO> list)
        {
            //string sql = @"insert into TBL_INCOMMING (incomming_date, incomming_rep, incomming_count, order_id) values(replace(convert(varchar(10), getdate(), 120), '-', '-'), @incomming_rep, @incomming_count, @order_id);
            //                update TBL_ORDER set order_deleted = 'Y' where order_id = @order_id";

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                SqlTransaction trans = conn.BeginTransaction();

                cmd.Transaction = trans;

                try
                {
                    cmd.Parameters.Add("@incomming_rep", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@incomming_count", SqlDbType.Int);
                    cmd.Parameters.Add("@order_id", SqlDbType.Int);
                    foreach (IncommingVO vo in list)
                    {
                        cmd.CommandText = @"insert into TBL_INCOMMING (incomming_date, incomming_rep, incomming_count, order_id, orderexam_result) values(replace(convert(varchar(10), getdate(), 120), '-', '-'), @incomming_rep, @incomming_count, @order_id, '미실시');
                                            update TBL_ORDER set order_deleted = 'Y' where order_id = @order_id";

                        cmd.Parameters["@incomming_rep"].Value = vo.incomming_rep;
                        cmd.Parameters["@incomming_count"].Value = vo.incomming_count;
                        cmd.Parameters["@order_id"].Value = vo.order_id;

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"insert into TBL_INC_CHECKLIST (incomming_ID) select IDENT_CURRENT('TBL_INCOMMING')";
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

        public List<IncommingStatusVO> IncommingStatus()
        {
            string sql = "select incomming_ID, incomming_state, incomming_date, incomming_rep, incomming_count, product_name, orderexam_result, company_name from IncommingStatus";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<IncommingStatusVO> list = Helper.DataReaderMapToList<IncommingStatusVO>(reader);
                return list;
            }
        }

        public List<IncommingHistoryVO> IncommingHistory(string product_name)
        {
            string sql = "select product_name, incomming_count, incomming_date, orderexam_result from IncommingStatus where product_name = @product_name";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@product_name", product_name);

                SqlDataReader reader = cmd.ExecuteReader();
                List<IncommingHistoryVO> list = Helper.DataReaderMapToList<IncommingHistoryVO>(reader);
                return list;
            }
        }
    }
}
