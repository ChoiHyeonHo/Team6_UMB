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
            string sql = @"select bom_id, 
		                    isnull(bom_parent_id, '최상위품목') as bom_parent_id, 
		                    isnull(prod_parent_id, '최상위품목') as prod_parent_id, 
		                    isnull(prod_parent_name, '최상위품목') as prod_parent_name, 
	                       P.product_id, product_name, product_type, product_unit, bom_use_count, bom_level, bom_comment
                    from TBL_BOM B join TBL_PRODUCT P on B.product_id = P.product_id where bom_level = 0 and bom_deleted = 'N'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(reader);
                return list;
            }
        }
        public List<BOMVO> GetBOMComboBoxCall(int lv)
        {
            string sql = @"select bom_id, 
		                    isnull(bom_parent_id, '최상위품목') as bom_parent_id, 
		                    isnull(prod_parent_id, '최상위품목') as prod_parent_id, 
		                    isnull(prod_parent_name, '최상위품목') as prod_parent_name, 
	                       P.product_id, product_name, product_type, product_unit, bom_use_count, bom_level, bom_comment
                    from TBL_BOM B join TBL_PRODUCT P on B.product_id = P.product_id where bom_deleted = 'N' and bom_level = @bom_level";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bom_level", lv);
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
            sb.Append(@"select bom_id,
                        isnull(bom_parent_id, '최상위품목') as bom_parent_id, 
                        isnull(prod_parent_id, '최상위품목') as prod_parent_id, 
                        isnull(prod_parent_name, '최상위품목') as prod_parent_name,
                        P.product_id, product_name, product_type, product_unit, bom_use_count, bom_level, bom_comment 
                        from TBL_BOM B join TBL_PRODUCT P on B.product_id = P.product_id where bom_deleted = 'N' and 1 = 1 ");

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
        public bool Insert(BOMVO vo)
        {
            string sql = @"EXEC SP_InsertBOM @prod_parent_name, @product_name, @bom_use_count, @bom_level, @bom_comment";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@prod_parent_name", vo.prod_parent_name);
                cmd.Parameters.AddWithValue("@product_name", vo.product_name);
                cmd.Parameters.AddWithValue("@bom_use_count", vo.bom_use_count);
                cmd.Parameters.AddWithValue("@bom_level", vo.bom_level);
                cmd.Parameters.AddWithValue("@bom_comment", vo.bom_comment);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool Update(BOMVO vo)
        {
            string sql = @"EXEC SP_UpdateBOM @bom_id, @prod_parent_name, @product_name, @bom_use_count, @bom_level, @bom_comment";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bom_id", vo.bom_id);
                cmd.Parameters.AddWithValue("@prod_parent_name", vo.prod_parent_name);
                cmd.Parameters.AddWithValue("@product_name", vo.product_name);
                cmd.Parameters.AddWithValue("@bom_use_count", vo.bom_use_count);
                cmd.Parameters.AddWithValue("@bom_level", vo.bom_level);
                cmd.Parameters.AddWithValue("@bom_comment", vo.bom_comment);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool Delete(int BOMID)
        {
            string sql = @"update TBL_BOM set bom_deleted = 'Y' where bom_id = @bom_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bom_id", BOMID);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
