using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.CHH;

namespace UMB_DAC.CHH
{
    public class BOMDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public BOMDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public List<BOMVO> GetBOMInfo()
        {
            string sql = @"select bom_id, product_name, product_type, product_unit, bom_use_count, bom_level 
from TBL_BOM B join TBL_PRODUCT P on B.product_id = P.product_id where bom_level = 0";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(reader);
                return list;
            }
        }
        public List<BOMVO> GetBOMInfoLv(int bomID)
        {
            string sql = @"select bom_id, product_name, product_type, product_unit, bom_use_count, bom_level 
from TBL_BOM B join TBL_PRODUCT P on B.product_id = P.product_id where bom_parent_id = @bom_parent_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bom_parent_id", bomID);
                SqlDataReader reader = cmd.ExecuteReader();
                List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(reader);
                return list;
            }
        }
        public List<BOMVO> GetBOMPreView(int bomPreView)
        {
            string sql = @"EXEC SP_BOM @bom_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bom_id", bomPreView);
                SqlDataReader reader = cmd.ExecuteReader();
                List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(reader);
                return list;
            }
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
