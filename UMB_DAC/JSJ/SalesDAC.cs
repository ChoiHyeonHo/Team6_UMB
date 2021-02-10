using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class SalesDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public SalesDAC()
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

        public List<SalesVO> SalesList()
        {
            string sql = "select company_name, product_name, ship_count, format (sales_price, '#,0') sales_price, sales_date from SalesList";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<SalesVO> list = Helper.DataReaderMapToList<SalesVO>(reader);
                return list;
            }
        }
    }
}
