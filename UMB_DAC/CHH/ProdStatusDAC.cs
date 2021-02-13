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
    public class ProdStatusDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        #region 생성자
        public ProdStatusDAC()
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

        #region 삭제여부가 N인 모든 품목을 조회
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<ProdStatusVO> GetProdInfo()
        {
            try
            {
                string sql = @"select * from ProductStatus where product_deleted = 'N'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProdStatusVO> list = Helper.DataReaderMapToList<ProdStatusVO>(reader);
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
        public List<GetProdNameVO> GetProdName()
        {
            try
            {
                string sql = @"select product_id, product_name from TBL_PRODUCT where product_deleted = 'N'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<GetProdNameVO> list = Helper.DataReaderMapToList<GetProdNameVO>(reader);
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
        public List<GetCompanyNameVO> GetCompanyName()
        {
            try
            {
                string sql = @"select company_id, company_name from TBL_COMPANY";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<GetCompanyNameVO> list = Helper.DataReaderMapToList<GetCompanyNameVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 창고명 콤보박스 바인딩
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<GetWHNameVO> GetWHName()
        {
            try
            {
                string sql = @"select w_id, w_name from TBL_WAREHOUSE";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<GetWHNameVO> list = Helper.DataReaderMapToList<GetWHNameVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 품목분류 콤보박스 바인딩
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<GetProdTypeVO> GetProdType()
        {
            try
            {
                string sql = @"select common_id, common_name from TBL_COMMON_CODE where common_type = '제품분류'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<GetProdTypeVO> list = Helper.DataReaderMapToList<GetProdTypeVO>(reader);
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
        public bool Insert(ProdStatusVO vo)
        {
            try
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
        public bool Update(ProdStatusVO vo)
        {
            try
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
        /// <param name="product_id"></param>
        /// <returns></returns>
        public bool Delete (string product_id)
        {
            try
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
        /// <param name="cbpName"></param>
        /// <param name="cbpType"></param>
        /// <param name="cbpCompany"></param>
        /// <param name="cbpWH"></param>
        /// <param name="cbpExam"></param>
        /// <returns></returns>
        public List<ProdStatusVO> GetWhereInfo(string cbpName, string cbpType, string cbpCompany, string cbpWH, string cbpExam)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select * from ProductStatus where product_deleted = 'N' and 1=1 ");
                if (cbpName.Trim().Length > 0)
                    sb.Append("and product_name = @product_name ");
                if (cbpType.Trim().Length > 0)
                    sb.Append("and product_type = @product_type ");
                if (cbpCompany.Trim().Length > 0)
                    sb.Append("and company_name = @company_name ");
                if (cbpWH.Trim().Length > 0)
                    sb.Append("and w_name = @w_name ");
                if (cbpExam.Trim().Length > 0)
                    sb.Append("and product_exam = @product_exam ");

                string sql = sb.ToString();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@product_name", cbpName);
                    cmd.Parameters.AddWithValue("@product_type", cbpType);
                    cmd.Parameters.AddWithValue("@company_name", cbpCompany);
                    cmd.Parameters.AddWithValue("@w_name", cbpWH);
                    cmd.Parameters.AddWithValue("@product_exam", cbpExam);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ProdStatusVO> list = Helper.DataReaderMapToList<ProdStatusVO>(reader);
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

        #region 바코드버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public DataTable GetBarCode(string temp)
        {
            try
            {
                string sql = $@"select product_id, product_name, company_name, product_exam
from TBL_PRODUCT P join TBL_COMPANY C on P.company_id = C.company_id
                                where product_id in ('" + temp + "')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
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
