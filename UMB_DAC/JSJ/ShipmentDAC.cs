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
            string sql = @"select so_id, company_name, S.product_name, so_edate, so_ocount, so_rep, case when so_ocount > PS.ps_stock then '재고부족' else '출하대기 가능' end as so_state
                          from SOList S
                          inner
                          join TBL_PRODUCT P on S.product_name = P.product_name
                          inner
                          join TBL_PRODUCT_STOCK PS on P.product_id = PS.product_id ";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShipSOVO> list = Helper.DataReaderMapToList<ShipSOVO>(reader);
                return list;
            }
        }
    }
}
