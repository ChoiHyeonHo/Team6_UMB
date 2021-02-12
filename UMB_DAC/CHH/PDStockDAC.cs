using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.CHH;

namespace UMB_DAC.CHH
{
    public class PDStockDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        #region 생성자
        public PDStockDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        #endregion

        #region 재고수량 조회
        /// <summary>
        /// 재고수량은 집계함수를 통해 하나로 묶는다
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<PDStockVO> GetPDStockInfo()
        {
            try
            {
                string sql = @"select PD.product_id, P.product_name, product_type, sum(ps_stock) as ps_stock, w_name, company_name
from TBL_PRODUCT_STOCK PD join TBL_PRODUCT P on PD.product_id = P.product_id
join TBL_COMPANY C on P.company_id = C.company_id
join TBL_WAREHOUSE W on P.w_id = W.w_id group by PD.product_id, P.product_name, product_type, w_name, company_name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<PDStockVO> list = Helper.DataReaderMapToList<PDStockVO>(reader);
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
        /// <param name="strProdName"></param>
        /// <param name="strProdType"></param>
        /// <param name="strWHName"></param>
        /// <returns></returns>
        public List<PDStockVO> GetPDStockWhereInfo(string strProdName, string strProdType, string strWHName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select PD.product_id, P.product_name, product_type, sum(ps_stock) as ps_stock, w_name, company_name
from TBL_PRODUCT_STOCK PD join TBL_PRODUCT P on PD.product_id = P.product_id
join TBL_COMPANY C on P.company_id = C.company_id
join TBL_WAREHOUSE W on P.w_id = W.w_id group by PD.product_id, P.product_name, product_type, w_name, company_name  where 1 = 1 ");

                if (strProdName.Trim().Length > 0)
                    sb.Append("and product_name = @product_name ");
                if (strProdType.Trim().Length > 0)
                    sb.Append("and product_type = @product_type ");
                if (strWHName.Trim().Length > 0)
                    sb.Append("and w_name = @w_name ");

                string sql = sb.ToString();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@product_name", strProdName);
                    cmd.Parameters.AddWithValue("@product_type", strProdType);
                    cmd.Parameters.AddWithValue("@w_name", strWHName);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<PDStockVO> list = Helper.DataReaderMapToList<PDStockVO>(reader);
                    Dispose();

                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 팝업폼 그리드뷰 바인딩
        /// <summary>
        /// 부모폼에서의 ID값을 바탕으로 해당 품목의 세부 내용을 팝업폼의 그리드뷰에 바인딩
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public List<PDStockVO> GetPDStockPopUpInfo(string product_id)
        {
            try
            {
                string sql = @"select ps_id, PD.product_id, P.product_name, product_type, ps_stock, w_name, company_name, ps_idate, ps_odate
                          from TBL_PRODUCT_STOCK PD join TBL_PRODUCT P on PD.product_id = P.product_id
						  join TBL_COMPANY C on P.company_id = C.company_id
						  join TBL_WAREHOUSE W on P.w_id = W.w_id where P.product_id = @product_id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@product_id", product_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<PDStockVO> list = Helper.DataReaderMapToList<PDStockVO>(reader);
                    return list;
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
        public bool Update(PDStockVO vo)
        {
            try
            {
                string sql = @"update TBL_PRODUCT_STOCK
                            set ps_stock = @ps_stock, ps_idate = @ps_idate, ps_odate = @ps_odate
                            where ps_id = @ps_id and product_id = @product_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ps_stock", vo.ps_stock);
                    cmd.Parameters.AddWithValue("@ps_idate", vo.ps_idate);
                    cmd.Parameters.AddWithValue("@ps_odate", vo.ps_odate);
                    cmd.Parameters.AddWithValue("@ps_id", vo.ps_id);
                    cmd.Parameters.AddWithValue("@product_id", vo.product_id);

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
        /// <param name="vo"></param>
        /// <returns></returns>
        public bool Delete(PDStockVO vo)
        {
            try
            {
                string sql = @"delete from TBL_PRODUCT_STOCK where ps_id = @ps_id and product_id = @product_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ps_id", vo.ps_id);
                    cmd.Parameters.AddWithValue("@product_id", vo.product_id);

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
            conn.Close();
        }
    }
}
