using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class ShipmentDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public ShipmentDAC()
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

        public List<ShipmentVO> ShipmentList()
        {
            string sql = "select ship_id, product_name, company_name, ship_state, ship_count, ship_edate from shipmentList";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShipmentVO> list = Helper.DataReaderMapToList<ShipmentVO>(reader);
                return list;
            }
        }

        public List<ShipSOVO> ShipmentSOList()
        {
            string sql = @"select so_id, company_name, product_name, so_edate, so_ocount, so_rep, so_state from ShipSOList where so_deleted = 'N'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShipSOVO> list = Helper.DataReaderMapToList<ShipSOVO>(reader);
                return list;
            }
        }

        public int ShipWait(ShipWaitVO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                SqlTransaction trans = conn.BeginTransaction();

                cmd.Transaction = trans;

                try
                {
                    cmd.CommandText = @"insert into TBL_SHIPMENT (so_id, ship_count, ship_uadmin, ship_udate, ship_state) values(@so_id, @ship_count, @ship_uadmin, replace(convert(varchar(10), getdate(), 120), '-', '-'), '검사대기');
                                        update TBL_SO_MASTER set so_deleted = 'Y' where so_id = @so_id";
                    cmd.Parameters.AddWithValue("@so_id", vo.so_id);
                    cmd.Parameters.AddWithValue("@ship_count", vo.ship_count);
                    cmd.Parameters.AddWithValue("@ship_uadmin", LoginVO.user.Name);
                    cmd.ExecuteNonQuery();


                    cmd.CommandText = "insert into TBL_PRODUCT_STOCK (product_id, ps_odate, ps_stock) values (@product_id, replace(convert(varchar(10), getdate(), 120), '-', '-'), @ship_count)";
                    cmd.Parameters.AddWithValue("@product_id", vo.product_id);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "insert into TBL_SHIP_CHECKLIST (ship_id) select IDENT_CURRENT('TBL_SHIPMENT')";
                    cmd.ExecuteNonQuery();

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

        public int Shipment(ShipmentVO vo)
        {
            //using (SqlCommand cmd = new SqlCommand())
            //{
            //    cmd.Connection = conn;

            //    try
            //    {
            //        cmd.CommandText = @"insert into TBL_SHIPMENT (so_id, ship_count, ship_uadmin, ship_udate, ship_state, ship_edate) values(@so_id, @ship_count, @ship_uadmin, replace(convert(varchar(10), getdate(), 120), '-', '-'), '출하완료', replace(convert(varchar(10), getdate(), 120), '-', '-'));
            //                            update TBL_SO_MASTER set so_deleted = 'Y' where so_id = @so_id";
            //        cmd.Parameters.AddWithValue("@so_id", vo.so_id);
            //        cmd.Parameters.AddWithValue("@ship_count", vo.ship_count);
            //        cmd.Parameters.AddWithValue("@ship_uadmin", LoginVO.user.Name);

            //        cmd.ExecuteNonQuery();
            //    }
            //    catch (Exception err)
            //    {
            //        string msg = err.Message;
            //        return 0;
            //    }
            //}

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                SqlTransaction trans = conn.BeginTransaction();

                cmd.Transaction = trans;

                try
                {
                    cmd.CommandText = "update TBL_SHIPMENT set ship_uadmin = @ship_uadmin, ship_state = '출하완료', ship_edate = replace(convert(varchar(10), getdate(), 120), '-', '-'), ship_udate = replace(convert(varchar(10), getdate(), 120), '-', '-') where ship_id = @ship_id";
                    cmd.Parameters.AddWithValue("@ship_id", vo.ship_id);
                    cmd.Parameters.AddWithValue("@ship_count", vo.ship_count);
                    cmd.Parameters.AddWithValue("@ship_uadmin", LoginVO.user.Name);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update TBL_SO_MASTER set so_deleted = 'Y' where so_id = @so_id";

                    //cmd.CommandText = "select IDENT_CURRENT('TBL_SHIPMENT')";
                    //int ship_id = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.CommandText = "select price_present from TBL_P_PRICE where product_id = @product_id and price_yn = 'Y'";
                    cmd.Parameters.AddWithValue("@product_id", vo.product_id);
                    int price = (Convert.ToInt32(cmd.ExecuteScalar()) * vo.ship_count);

                    cmd.CommandText = "insert into TBL_SALES (ship_id, sales_date, sales_price) values(@ship_id, replace(convert(varchar(10), getdate(), 120), '-', '-'), @sales_price)";
                    cmd.Parameters.AddWithValue("@sales_price", price);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    return 1;
                }
                catch (Exception err)
                {
                    string msg = err.Message;
                    trans.Rollback();
                    return 0;
                }
            }
        }
    }
}
