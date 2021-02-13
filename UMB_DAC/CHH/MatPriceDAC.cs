using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.CHH;

namespace UMB_DAC.CHH
{
    public class MatPriceDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        #region 생성자
        public MatPriceDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        #endregion

        #region 원자재 조회
        /// <summary>
        /// 자재단가 폼에서의 원자재를 조회해온다.
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<MatPriceVO> GetMatInfo()
        {
            try
            {
                string sql = @"select price_id, P.product_id, P.product_name, C.company_id, C.company_name, price_present, price_past, 
	   price_sdate, price_edate, price_yn, price_comment
from TBL_P_PRICE as PP inner join TBL_PRODUCT as P on PP.product_id = P.product_id 
					   inner join TBL_COMPANY as C on PP.company_id = C.company_id
where P.product_type = '원자재'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<MatPriceVO> list = Helper.DataReaderMapToList<MatPriceVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 사용여부 Y인 원자재 조회
        /// <summary>
        /// 사용여부가 Y인 원자재를 조회한다.
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<MatPriceVO> GetMatNInfo()
        {
            try
            {
                string sql = @"select price_id, P.product_id, P.product_name, C.company_id, C.company_name, price_present, price_past, 
	   price_sdate, price_edate, price_yn, price_comment
from TBL_P_PRICE as PP inner join TBL_PRODUCT as P on PP.product_id = P.product_id 
					   inner join TBL_COMPANY as C on PP.company_id = C.company_id
where P.product_type = '원자재' and price_yn = 'Y'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<MatPriceVO> list = Helper.DataReaderMapToList<MatPriceVO>(reader);
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
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public bool Insert(MatPriceVO vo)
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
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public bool Update(MatPriceVO vo)
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
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="priceID"></param>
        /// <returns></returns>
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

        #region 품목명 콤보박스 바인딩
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<Mat_ProdCBOBindingVO> GetProdName()
        {
            try
            {
                string sql = @"select product_id, product_name from TBL_PRODUCT where product_type = '원자재'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Mat_ProdCBOBindingVO> list = Helper.DataReaderMapToList<Mat_ProdCBOBindingVO>(reader);
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
        public List<Mat_CompanyCBOBindingVO> GetCompanyNameName()
        {
            try
            {
                string sql = @"select company_id, company_name from TBL_COMPANY where company_type = '발품'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Mat_CompanyCBOBindingVO> list = Helper.DataReaderMapToList<Mat_CompanyCBOBindingVO>(reader);
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
        public List<MatPriceVO> GetWhereInfo(string prodName, string companyName)
        {
            try
            {
                string sql = @"select price_id, P.product_id, P.product_name, C.company_id, C.company_name, price_present, price_past, price_sdate, price_edate, price_yn, price_comment
from TBL_P_PRICE as PP inner join TBL_PRODUCT as P on PP.product_id = P.product_id inner join TBL_COMPANY as C on PP.company_id = C.company_id
where product_name = @product_name and company_name = @company_name and P.product_type = '원자재'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@product_name", prodName);
                    cmd.Parameters.AddWithValue("@company_name", companyName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<MatPriceVO> list = Helper.DataReaderMapToList<MatPriceVO>(reader);
                    return list;
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
            conn.Close();
        }
    }
}
