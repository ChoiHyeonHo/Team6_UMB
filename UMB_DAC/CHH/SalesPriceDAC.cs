using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.CHH;

namespace UMB_DAC.CHH
{
    public class SalesPriceDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public SalesPriceDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public List<SalesPriceVO> GetSalesPriceInfo()
        {
            string sql = @"select price_id, product_name, company_name, price_present, price_past, price_sdate, price_edate, price_yn
from TBL_P_PRICE as PP inner join TBL_PRODUCT as P on PP.product_id = P.product_id 
inner join TBL_COMPANY as C on C.company_id = PP.company_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<SalesPriceVO> list = Helper.DataReaderMapToList<SalesPriceVO>(reader);
                return list;
            }
        }

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
