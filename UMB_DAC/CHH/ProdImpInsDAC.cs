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
    public class ProdImpInsDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        #region 생성자
        public ProdImpInsDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        #endregion

        #region 입고상태가 대기, 검사상태가 미실시 또는 불량인 데이터 조회
        /// <summary>
        /// 입고상태가 대기, 검사상태가 미실시 또는 불량인 데이터 조회
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<ProdImpInsVO> GetIncomminInfo()
        {
            try
            {
                string sql = @"select incomming_ID, O.order_id, P.product_id,  P.product_name, incomming_state, incomming_date, incomming_rep, incomming_count, 
    orderexam_result, incomming_uadmin, incomming_udate
from TBL_INCOMMING I join TBL_ORDER O on I.order_id = O.order_id
                     join TBL_PRODUCT P on O.product_id = P.product_id
where incomming_state = '대기' and (orderexam_result = '미실시' or orderexam_result = '불량')";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProdImpInsVO> list = Helper.DataReaderMapToList<ProdImpInsVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 수입검사 항목에서 조회
        /// <summary>
        /// 쿼리문 where in()절에 들어갈 문자열 temp를 파라미터로 전달받아서 수입검사항목 테이블에서 데이터 조회
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public List<InsCheckVO> GetInsCheckInfo(string temp)
        {
            try
            {
                string sql = $@"select cl_inc_id, IC.incomming_ID,
		                        isnull(cl_inc_Color, '미실시') as cl_inc_Color,
		                        isnull(cl_inc_Torn, '미실시') as  cl_inc_Torn, 
		                        isnull(cl_inc_Length, '미실시') as cl_inc_Length,
		                        isnull(cl_inc_Crack, '미실시') as cl_inc_Crack,
		                        isnull(etc, '없음') as etc
                        from TBL_INC_CHECKLIST IC join TBL_INCOMMING I on IC.incomming_ID = I.incomming_ID 
                        where IC.incomming_ID in ({temp}) and orderexam_result = '미실시'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<InsCheckVO> list = Helper.DataReaderMapToList<InsCheckVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 수입검사테이블 => DEV 출력
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public DataTable GetInsCheckInfoDEV(string temp)
        {
            try
            {
                string sql = $@"select cl_inc_id, incomming_ID, 
		                        isnull(cl_inc_Color, ' ') as cl_inc_Color,
		                        isnull(cl_inc_Torn, ' ') as  cl_inc_Torn, 
		                        isnull(cl_inc_Length, ' ') as cl_inc_Length,
		                        isnull(cl_inc_Crack, ' ') as cl_inc_Crack,
		                        isnull(etc, ' ') as etc
                        from TBL_INC_CHECKLIST where incomming_ID in ({temp})";

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

        #region Update
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="pTemp"></param>
        /// <param name="cl_inc_Color"></param>
        /// <param name="cl_inc_id"></param>
        /// <returns></returns>
        public bool Update(string pTemp, string cl_inc_Color, int cl_inc_id)
        {
            try
            {
                string sql = $@"update TBL_INC_CHECKLIST set {pTemp} = @temp where cl_inc_id = @cl_inc_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@temp", cl_inc_Color);
                    cmd.Parameters.AddWithValue("@cl_inc_id", cl_inc_id);
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

        #region 컨텍스트 메뉴 스트립 => 비고버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="pEtc"></param>
        /// <param name="comment"></param>
        /// <param name="pID"></param>
        /// <returns></returns>
        public bool Comment(string pEtc, string comment, int pID)
        {
            try
            {
                string sql = $@"update TBL_INC_CHECKLIST set {pEtc} = @temp where cl_inc_id = @cl_inc_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@temp", comment);
                    cmd.Parameters.AddWithValue("@cl_inc_id", pID);
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

        #region 헤더 체크박스 선택된 항목 모두 양호상태로 변경
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="incTemp"></param>
        /// <param name="userName"></param>
        /// <param name="alphaTemp"></param>
        /// <returns></returns>
        public bool UpdateAll(string temp, string incTemp, string userName, string alphaTemp)
        {
            string incToProd = $@"EXEC SP_IncToProd @alphaTemp";

            string insert_Check_History = $@"EXEC SP_InsertCheckHistory @alphaTemp";

            string checkSql = $@"update TBL_INC_CHECKLIST 
                                set cl_inc_Color = '양호', 
                                 cl_inc_Torn = '양호', 
                                 cl_inc_Length = '양호', 
                                 cl_inc_Crack = '양호'
                                where cl_inc_id in({temp})";

            string IncSql = $@"update TBL_INCOMMING
	                        set incomming_state = '입고완료',
		                        incomming_date = convert(char(10), getdate(), 23),
		                        incomming_rep = '{userName}',
		                        orderexam_result = '합격'
	                        where incomming_ID in ({incTemp})";

            SqlTransaction tran = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.Transaction = tran;

            try
            {
                //cmd.CommandText = insert_Check_History;
                //cmd.Parameters.AddWithValue("@alphaTemp", alphaTemp);
                //cmd.ExecuteNonQuery();

                cmd.CommandText = incToProd;
                cmd.Parameters.AddWithValue("@alphaTemp", alphaTemp);
                cmd.ExecuteNonQuery();

                cmd.CommandText = checkSql;
                cmd.ExecuteNonQuery();

                cmd.CommandText = IncSql;
                cmd.ExecuteNonQuery();

                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
        }
        #endregion

        #region 검사 후 검사 이력 테이블에 새로 등록
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="alphaTemp"></param>
        /// <returns></returns>
        public bool InsertCheckHistory(string alphaTemp)
        {
            try
            {
                string sql = $@"EXEC SP_InsertCheckHistory @temp";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@temp", alphaTemp);
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
