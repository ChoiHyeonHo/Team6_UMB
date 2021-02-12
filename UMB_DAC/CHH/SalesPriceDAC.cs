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

        #region 생성자
        public SalesPriceDAC()
        {
            try
            {
                strConn = this.ConnectionString;
                conn = new SqlConnection(strConn);
                conn.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 품목단가 바인딩
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<SalesPriceVO> GetSalesPriceNInfo()
        {
            try
            {
                string sql = @"select price_id, P.product_id, P.product_name, C.company_id, C.company_name, price_present, price_past, 
	   price_sdate, price_edate, price_yn, price_comment
from TBL_P_PRICE as PP inner join TBL_PRODUCT as P on PP.product_id = P.product_id 
					   inner join TBL_COMPANY as C on PP.company_id = C.company_id
where P.product_type = '완제품'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<SalesPriceVO> list = Helper.DataReaderMapToList<SalesPriceVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 검색버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="prodName"></param>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public List<SalesPriceVO> GetWhereInfo(string prodName, string companyName)
        {
            try
            {
                string sql = @"select price_id, P.product_id, P.product_name, C.company_id, C.company_name, price_present, price_past, price_sdate, price_edate, price_yn, price_comment
from TBL_P_PRICE as PP inner join TBL_PRODUCT as P on PP.product_id = P.product_id inner join TBL_COMPANY as C on PP.company_id = C.company_id
where product_name = @product_name and company_name = @company_name and P.product_type = '완제품'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@product_name", prodName);
                    cmd.Parameters.AddWithValue("@company_name", companyName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<SalesPriceVO> list = Helper.DataReaderMapToList<SalesPriceVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 사용중인 완제품 바인딩
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<SalesPriceVO> GetSalesPriceYInfo()
        {
            try
            {
                string sql = @"select price_id, P.product_id, P.product_name, C.company_id, C.company_name, price_present, price_past, price_sdate, price_edate, price_yn, price_comment
from TBL_P_PRICE as PP inner join TBL_PRODUCT as P on PP.product_id = P.product_id inner join TBL_COMPANY as C on PP.company_id = C.company_id where price_yn = 'Y' and P.product_type = '완제품'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<SalesPriceVO> list = Helper.DataReaderMapToList<SalesPriceVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 품목명 콤보박스 바인딩
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<ProdCBOBindingVO> GetProdName()
        {
            try
            {
                string sql = @"select product_id, product_name from TBL_PRODUCT where product_type = '완제품'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProdCBOBindingVO> list = Helper.DataReaderMapToList<ProdCBOBindingVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 거래처명 콤보박스 바인딩
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<CompanyCBOBindingVO> GetCompanyName()
        {
            try
            {
                string sql = @"select company_id, company_name from TBL_COMPANY where company_type = '납품'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<CompanyCBOBindingVO> list = Helper.DataReaderMapToList<CompanyCBOBindingVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Insert
        public bool Insert(SalesPriceVO vo)
        {
            try
            {
                string sql = @"EXEC InsertOrUpdate @product_name, @company_name, @price_present, @price_sdate, @price_edate, @price_yn, @price_comment";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@product_name", vo.product_name);
                    cmd.Parameters.AddWithValue("@company_name", vo.company_name);
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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public bool Update(SalesPriceVO vo)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public bool Delete(int priceID)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
