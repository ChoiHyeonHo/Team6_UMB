using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class WarehouseDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public WarehouseDAC()
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

        public List<WarehouseVO> WarehouseList()
        {
            string sql = "select w_id, w_name, w_address, w_type, w_deleted, w_uadmin, w_udate from TBL_WAREHOUSE";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<WarehouseVO> list = Helper.DataReaderMapToList<WarehouseVO>(reader);
                return list;
            }
        }
    }
}
