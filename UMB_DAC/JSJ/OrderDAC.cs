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
    public class OrderDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public OrderDAC()
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

        public List<OrderListVO> OrderList()
        {
            using (SqlCommand cmd = new SqlCommand("SP_OrderList", conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<OrderListVO> list = Helper.DataReaderMapToList<OrderListVO>(reader);
                return list;
            }
        }

        public int DeleteOrder(int order_id)
        {
            string sql = "UPDATE TBL_ORDER SET order_deleted = 'Y' WHERE order_id = @order_id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", order_id);

                    int iRow = cmd.ExecuteNonQuery();
                    return iRow;
                }
            }
            catch(Exception err)
            {
                string msg = err.Message;
                return 0;
            }
        }

        public List<OrderPlistVO> OrderPList()
        {
            string sql = "select company_id, company_name, product_id, product_name from OrderPList where product_type = '원자재'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<OrderPlistVO> list = Helper.DataReaderMapToList<OrderPlistVO>(reader);
                return list;
            }
        }
        
        public List<OrderCompanyVO> CompanyList()
        {
            string sql = "select company_name from TBL_COMPANY where company_type = '매출거래처'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<OrderCompanyVO> list = Helper.DataReaderMapToList<OrderCompanyVO>(reader);
                return list;
            }
        }

        public int RegistOrder(List<OrderVO> list)
        {
            string sql = "insert into TBL_ORDER (product_id, order_count, company_id, user_id, order_date, order_edate) values(@product_id, @order_count, @company_id, @user_id, replace(convert(varchar(10), getdate(), 120), '-', '-'), @order_edate)";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlTransaction trans = conn.BeginTransaction();

                cmd.Transaction = trans;

                try
                {
                    cmd.Parameters.Add("@product_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@order_count", SqlDbType.Int);
                    cmd.Parameters.AddWithValue("@user_id", LoginVO.user.ID);
                    cmd.Parameters.AddWithValue("@company_id", list[0].company_id);
                    cmd.Parameters.AddWithValue("@order_edate", list[0].order_edate);
                    foreach(OrderVO order in list)
                    {
                        cmd.Parameters["@product_id"].Value = order.product_id;
                        cmd.Parameters["@order_count"].Value = order.order_count;

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    conn.Close();
                    return 1;
                }
                catch(Exception err)
                {
                    string msg = err.Message;
                    trans.Rollback();
                    conn.Close();
                    return 0;
                }
            }
        }     
    }
}
