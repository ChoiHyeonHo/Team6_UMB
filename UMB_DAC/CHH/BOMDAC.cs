using System;
using System.Collections.Generic;
using System.Data;
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
            string sql = @"	select bom_id, product_name, product_type, product_unit, bom_use_count, bom_level, bom_comment, isnull (bom_parent_id, '최상위품목') as bom_parent_id
	from TBL_BOM B join TBL_PRODUCT P on B.product_id = P.product_id where bom_level = 0";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(reader);
                return list;
            }
        }
        public List<BOMVO> GetBOMComboBoxCall(int lv)
        {
            string sql = @"select bom_id, product_name, product_type, product_unit, bom_use_count, bom_level, bom_comment, isnull (bom_parent_id, '최상위품목') as bom_parent_id 
from TBL_BOM B join TBL_PRODUCT P on B.product_id = P.product_id where bom_level = @bom_level";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bom_level", lv);
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
        public List<BOMVO> GetBOMPreView(int bomID)
        {
            string sql = $@"EXEC SP_BOM @bom_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bom_id", bomID);
                SqlDataReader reader = cmd.ExecuteReader();
                List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(reader);
                return list;
            }
        }
        public List<BOMVO> GetBOMCBProdName()
        {
            string sql = $@"select product_id, product_name from TBL_PRODUCT";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(reader);
                return list;
            }
        }

        public List<BOMVO> GetBOMWhereInfo(int level, string prodName, string prodType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select bom_id, product_name, product_type, product_unit, bom_use_count, bom_level 
from TBL_BOM B join TBL_PRODUCT P on B.product_id = P.product_id where 1 = 1 ");

            if (level > -1)
                sb.Append("and bom_level = @bom_level ");
            if (prodName.Trim().Length > 0)
                sb.Append("and product_name = @product_name ");
            if (prodType.Trim().Length > 0)
                sb.Append("and product_type = @product_type ");

            string sql = sb.ToString();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bom_level", level);
                cmd.Parameters.AddWithValue("@product_name", prodName);
                cmd.Parameters.AddWithValue("@product_type", prodType);


                SqlDataReader reader = cmd.ExecuteReader();

                List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(reader);
                Dispose();

                return list;
            }
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
