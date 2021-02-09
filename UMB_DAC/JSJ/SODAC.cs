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
    public class SODAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public SODAC()
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

        public List<SOListVO> SOList()
        {
            string sql = "select so_id, company_name, product_name, so_edate, so_ocount, so_rep from SOList where so_deleted = 'N'";

            using(SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<SOListVO> list = Helper.DataReaderMapToList<SOListVO>(reader);
                return list;
            }
        }

        public List<SOCompanyVO> CompanyList()
        {
            string sql = "select company_name from TBL_COMPANY where company_type = '매입거래처'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<SOCompanyVO> list = Helper.DataReaderMapToList<SOCompanyVO>(reader);
                return list;
            }
        }

        public List<SOPListVO> OrderPList()
        {
            string sql = "select company_id, product_id, product_name, company_name from OrderPList where product_type = '완제품'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<SOPListVO> list = Helper.DataReaderMapToList<SOPListVO>(reader);
                return list;
            }
        }

        public int RegistSO(List<SOVO> list)
        {
            using (SqlCommand cmd = new SqlCommand())
            {                
                cmd.Connection = conn;

                SqlTransaction trans = conn.BeginTransaction();

                cmd.Transaction = trans;

                try
                {
                    cmd.Parameters.Add("@product_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@so_ocount", SqlDbType.Int);
                    cmd.Parameters.AddWithValue("@so_rep", list[0].so_rep);
                    cmd.Parameters.AddWithValue("@company_id", list[0].company_id);
                    cmd.Parameters.AddWithValue("@so_edate", list[0].so_edate);
                    cmd.Parameters.AddWithValue("@so_comment", list[0].so_comment);
                    foreach (SOVO SO in list)
                    {
                        cmd.CommandText = "insert into TBL_SO_MASTER (product_id, so_ocount, company_id, so_rep, so_edate, so_comment) values(@product_id, @so_ocount, @company_id, @so_rep, @so_edate, @so_comment)";
                        cmd.Parameters["@product_id"].Value = SO.product_id;
                        cmd.Parameters["@so_ocount"].Value = SO.so_ocount;

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "select IDENT_CURRENT('TBL_SO_MASTER')";
                        int so_id = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.CommandText = "EXEC SP_InsertWO @so_id, @product_id, @so_ocount";

                        if (cmd.Parameters.Contains("@so_id") == false)
                        {
                            cmd.Parameters.Add("@so_id", SqlDbType.Int);
                        }
                        cmd.Parameters["@so_id"].Value = so_id;
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

        //public int UpdateSO(List<SOVO> list)
        //{
        //    string sql = "update "
        //}

        public int DeleteSO(int so_id)
        {
            string sql = "update TBL_SO_MASTER set so_deleted = 'Y' where so_id = @so_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@so_id", so_id);
                    int iRow = cmd.ExecuteNonQuery();
                    return iRow;
                }               
                catch(Exception err)
                {
                    string smg = err.Message;
                    return 0;
                }
            }
        }
    }
}
