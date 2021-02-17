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

        public bool updatePOP(int wo_id, int production_id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlTransaction tran = conn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.Connection = conn;
                try
                {
                    cmd.CommandText = @"update TBL_WORK_ORDER set wo_state = '작업중'
                            where wo_id = @wo_id";
                    cmd.Parameters.AddWithValue("@wo_id", wo_id);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"update TBL_Production set production_state = '작업중'
                            where production_id = @product_id ";
                    cmd.Parameters.AddWithValue("@product_id", production_id);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    Dispose();
                    return true;
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    return false;
                }                
            }
        }

        public void CompleteProduction(int pid)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlTransaction tran = conn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.Connection = conn;
                try
                {
                    cmd.CommandText = @"update TBL_performance set performance_qty_ok = performance_qtyimport
                            where production_id = @pid";
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"update TBL_Production set production_QtyReleased = production_QtyRequested
                                where production_id = @pid2";
                    cmd.Parameters.AddWithValue("@pid2", pid);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    Dispose();
                    
                }
                catch (Exception ex)
                {
                    tran.Rollback();                    
                }
            }
        }

        public bool ChangeWPState(int pid, int woid)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlTransaction tran = conn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.Connection = conn;
                try
                {
                    cmd.CommandText = @"update TBL_WORK_ORDER set wo_state = '작업종료'
                            where wo_id = @wo_id";
                    cmd.Parameters.AddWithValue("@wo_id", woid);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"update TBL_Production set production_state = '작업종료'
                             where production_id = @product_id ";
                    cmd.Parameters.AddWithValue("@product_id", pid);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;
                }

            }
        }
    }
}
