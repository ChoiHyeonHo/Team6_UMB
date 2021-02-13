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

        #region 생성자
        /// <summary>
        /// BOMDAC 생성자
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        public BOMDAC()
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

        #region 초기 BOM 0레벨 바인딩
        /// <summary>
        /// BOM폼 좌측에 초기 0레벨 품목을 바인딩한다
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<BOMVO> GetBOMInfo()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ??
        public List<BOMVO> GetBOMComboBoxCall(int lv)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region PreView버튼
        /// <summary>
        /// 해당하는 BOMID의 하위 품목들을 조회한다
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="bomID"></param>
        /// <returns></returns>
        public List<BOMVO> GetBOMPreView(int bomID)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 품목명 콤보박스 바인딩
        /// <summary>
        /// 폼 검색조건의 콤보박스에 품목명을 바인딩한다.
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<BOMVO> GetBOMCBProdName()
        {
            try
            {
                string sql = $@"select product_id, product_name from TBL_PRODUCT";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(reader);
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
        /// 1. 레벨 선택했을 경우(-1 보다 큰경우) StringBuilder의 Append를 사용해 덧붙인다
        /// 2. 품목명을 선택했을 경우 (문자열의 길이가 0보다 클 경우) StringBuilder의 Append를 사용해 덧붙인다
        /// 3. 품목분류를 선택했을 경우 (문자열의 길이가 0보다 클 경우) StringBuilder의 Append를 사용해 덧붙인다
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="level"></param>
        /// <param name="prodName"></param>
        /// <param name="prodType"></param>
        /// <returns></returns>
        public List<BOMVO> GetBOMWhereInfo(int level, string prodName, string prodType)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Insert
        /// <summary>
        /// 상위품목명, 등록할 품목명, 소요량, 레벨, 비고를 vo 에 입력받아서 등록한다.
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public bool Insert(BOMVO vo)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// BOMID, 상위품목명, 품목명, 소요량, 레벨, 비고를 vo에 입력받아 DB의 내용을 수정한다.
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public bool Update(BOMVO vo)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// 해당 BOMID를 가진 항목의 삭제여부를 Y로 변경하되 실 삭제는 하지 않음
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="BOMID"></param>
        /// <returns></returns>
        public bool Delete(int BOMID)
        {
            try
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
