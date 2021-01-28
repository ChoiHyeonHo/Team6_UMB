using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.CHH;

namespace UMB_DAC.CHH
{
    public class ProdStatusDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;
        public ProdStatusDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public List<ProdStatusVO> GetProdInfo()
        {
            string sql = @"select * from ProductStatus";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProdStatusVO> list = Helper.DataReaderMapToList<ProdStatusVO>(reader);
                return list;
            }
        }

        public List<GetProdNameVO> GetProdName()
        {
            string sql = @"select product_id, product_name from TBL_PRODUCT";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<GetProdNameVO> list = Helper.DataReaderMapToList<GetProdNameVO>(reader);
                return list;
            }
        }

        public List<GetCompanyNameVO> GetCompanyName()
        {
            string sql = @"select company_id, company_name from TBL_COMPANY";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<GetCompanyNameVO> list = Helper.DataReaderMapToList<GetCompanyNameVO>(reader);
                return list;
            }
        }

        public List<GetWHNameVO> GetWHName()
        {
            string sql = @"select w_id, w_name from TBL_WAREHOUSE";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<GetWHNameVO> list = Helper.DataReaderMapToList<GetWHNameVO>(reader);
                return list;
            }
        }
        public bool Insert(ProdStatusVO vo)
        {
            string sql = @"EXEC SP_ProductStatus @product_id, @product_name, @product_unit, @product_type, @product_lorder_count, @product_safety_count,
@company_id, @product_exam, @product_stnd, @product_comment, @w_id, @product_deleted";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@product_id", vo.product_id);
                cmd.Parameters.AddWithValue("@product_name", vo.product_name);
                cmd.Parameters.AddWithValue("@product_unit", vo.product_unit);
                cmd.Parameters.AddWithValue("@product_type", vo.product_type);
                cmd.Parameters.AddWithValue("@product_lorder_count", vo.product_lorder_count);
                cmd.Parameters.AddWithValue("@product_safety_count", vo.product_safety_count);
                cmd.Parameters.AddWithValue("@company_id", vo.company_name);
                cmd.Parameters.AddWithValue("@product_exam", vo.product_exam);
                cmd.Parameters.AddWithValue("@product_stnd", vo.product_stnd);
                cmd.Parameters.AddWithValue("@product_comment", vo.product_comment);
                cmd.Parameters.AddWithValue("@w_id", vo.w_name);
                cmd.Parameters.AddWithValue("@product_deleted", vo.product_deleted);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }
        public bool Update(ProdStatusVO vo)
        {
            string sql = @"EXEC SP_UpdateProductStatus @product_id, @product_name, @product_unit, @product_type, @product_lorder_count, @product_safety_count, @company_id, @product_exam, @product_stnd, @product_comment, @w_id, @product_deleted";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@product_id", vo.product_id);
                cmd.Parameters.AddWithValue("@product_name", vo.product_name);
                cmd.Parameters.AddWithValue("@product_unit", vo.product_unit);
                cmd.Parameters.AddWithValue("@product_type", vo.product_type);
                cmd.Parameters.AddWithValue("@product_lorder_count", vo.product_lorder_count);
                cmd.Parameters.AddWithValue("@product_safety_count", vo.product_safety_count);
                cmd.Parameters.AddWithValue("@company_id", vo.company_name);
                cmd.Parameters.AddWithValue("@product_exam", vo.product_exam);
                cmd.Parameters.AddWithValue("@product_stnd", vo.product_stnd);
                cmd.Parameters.AddWithValue("@product_comment", vo.product_comment);
                cmd.Parameters.AddWithValue("@w_id", vo.w_name);
                cmd.Parameters.AddWithValue("@product_deleted", vo.product_deleted);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool Delete (string product_id)
        {
            string sql = @"update TBL_PRODUCT set product_deleted = 'Y' where product_id = @product_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@product_id", product_id);

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
