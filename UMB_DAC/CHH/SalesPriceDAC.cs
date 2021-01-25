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

        public List<SalesPriceVO> GetSalesPriceNInfo()
        {
            string sql = @"select price_id, P.product_id, P.product_name, C.company_id, C.company_name, price_present, price_past, price_sdate, price_edate, price_yn, price_comment
from TBL_P_PRICE as PP inner join TBL_PRODUCT as P on PP.product_id = P.product_id inner join TBL_COMPANY as C on PP.company_id = C.company_id";
//where price_yn = 'Y'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<SalesPriceVO> list = Helper.DataReaderMapToList<SalesPriceVO>(reader);
                return list;
            }
        }
        public List<SalesPriceVO> GetSalesPriceYInfo()
        {
            string sql = @"select price_id, P.product_id, P.product_name, C.company_id, C.company_name, price_present, price_past, price_sdate, price_edate, price_yn, price_comment
from TBL_P_PRICE as PP inner join TBL_PRODUCT as P on PP.product_id = P.product_id inner join TBL_COMPANY as C on PP.company_id = C.company_id where price_yn = 'Y'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<SalesPriceVO> list = Helper.DataReaderMapToList<SalesPriceVO>(reader);
                return list;
            }
        }

        public List<ProdCBOBindingVO> GetProdName()
        {
            string sql = @"select product_id, product_name from TBL_PRODUCT";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProdCBOBindingVO> list = Helper.DataReaderMapToList<ProdCBOBindingVO>(reader);
                return list;
            }
        }

        public List<CompanyCBOBindingVO> GetCompanyName()
        {
            string sql = @"select company_id, company_name from TBL_COMPANY";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<CompanyCBOBindingVO> list = Helper.DataReaderMapToList<CompanyCBOBindingVO>(reader);
                return list;
            }
        }

        public bool Insert(SalesPriceVO vo)
        {
            string sql = @"EXEC InsertOrUpdate @product_id, @company_id, @price_present, @price_past, @price_sdate, @price_edate, @price_yn, @price_comment";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@product_id", vo.product_name);
                cmd.Parameters.AddWithValue("@company_id", vo.company_name);
                cmd.Parameters.AddWithValue("@price_present", vo.price_present);
                cmd.Parameters.AddWithValue("@price_past", vo.price_past);
                cmd.Parameters.AddWithValue("@price_sdate", vo.price_sdate);
                cmd.Parameters.AddWithValue("@price_edate", vo.price_edate);
                cmd.Parameters.AddWithValue("@price_yn", vo.price_yn);
                cmd.Parameters.AddWithValue("@price_comment", vo.price_comment);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool Update(SalesPriceVO vo)
        {
            string sql = @"EXEC SP_sPriceUpdate @price_id, @product_id, @company_id, @price_present, @price_sdate, @price_edate, @price_yn, @price_comment";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@price_id", vo.price_id);
                cmd.Parameters.AddWithValue("@product_id", vo.product_name);
                cmd.Parameters.AddWithValue("@company_id", vo.company_name);
                cmd.Parameters.AddWithValue("@price_present", vo.price_present);
                cmd.Parameters.AddWithValue("@price_sdate", vo.price_sdate);
                cmd.Parameters.AddWithValue("@price_edate", vo.price_edate);
                cmd.Parameters.AddWithValue("@price_yn", vo.price_yn);
                cmd.Parameters.AddWithValue("@price_comment", vo.price_comment);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool Delete(int priceID)
        {
            string sql = @"update TBL_P_PRICE set price_yn = 'N' where price_id = @price_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@price_id", priceID);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
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
