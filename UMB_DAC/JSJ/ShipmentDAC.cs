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
    }
}
