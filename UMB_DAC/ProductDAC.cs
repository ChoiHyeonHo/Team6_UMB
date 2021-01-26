using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;
using UMB_VO.CHH;

namespace UMB_DAC
{
    public class ProductDAC : ConnectionAccess, IDisposable
    {
        SqlConnection conn;
        string strConn;

        public ProductDAC()
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

        public List<ProdCBOBindingVO> GetProductInfo()
        {
            string sql = @"select product_id, product_name
from TBL_PRODUCT";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProdCBOBindingVO> list = Helper.DataReaderMapToList<ProdCBOBindingVO>(reader);
                return list;
            }
        }
    }
}
