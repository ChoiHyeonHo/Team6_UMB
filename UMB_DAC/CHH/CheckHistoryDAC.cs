using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.CHH;

namespace UMB_DAC.CHH
{
    public class CheckHistoryDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        #region 생성자
        public CheckHistoryDAC()
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

        #region 검사 이력을 모두 조회
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<CheckHistoryVO> GetCheckHisInfo()
        {
            try
            {
                string sql = @"select * from TBL_CHECK_HISTORY";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<CheckHistoryVO> list = Helper.DataReaderMapToList<CheckHistoryVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 검색조건(수입검사 or 제품검사)을 통해데이터를 조회
        /// <summary>
        /// 검색조건(수입검사 or 제품검사)을 통해데이터를 조회
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="checkType"></param>
        /// <returns></returns>
        public List<CheckHistoryVO> GetCheckHisInfoWhere(string checkType)
        {
            try
            {
                string sql = @"select * from TBL_CHECK_HISTORY where ch_type = @checkType";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@checkType", checkType);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<CheckHistoryVO> list = Helper.DataReaderMapToList<CheckHistoryVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 검사 유형을 콤보박스에 바인딩
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<GetCheckTypeVO> GetCheckTypeComboBox()
        {
            try
            {
                string sql = @"select common_id, common_name from TBL_COMMON_CODE where common_type = '검사유형'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<GetCheckTypeVO> list = Helper.DataReaderMapToList<GetCheckTypeVO>(reader);
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
