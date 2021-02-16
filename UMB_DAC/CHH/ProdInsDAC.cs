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
    public class ProdInsDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        #region 생성자
        public ProdInsDAC()
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

        #region 검사대기상태의 제품검사항목을 바인딩
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <returns></returns>
        public List<ProdInsVO> GetProdInsInfo()
        {
            try
            {
                string sql = @"select * from ProdCheck where production_state = '작업종료'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProdInsVO> list = Helper.DataReaderMapToList<ProdInsVO>(reader);
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
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public List<ProdInsPopUpVO> GetProdInsPopUpInfo(string temp)
        {
            try
            {
                string sql = $@"select cl_ship_id, S.ship_id, P.product_name, cl_ship_Components, cl_ship_Packing, etc, production_state
                        from TBL_SHIP_CHECKLIST S join ProdCheck P on S.ship_id = P.ship_id
                        where S.ship_id in ({temp}) and production_state = '작업종료' 
                        and (cl_ship_Components = '미실시' or cl_ship_Components = '불량')
                        or (cl_ship_Packing = '미실시' or cl_ship_Packing = '불량')";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProdInsPopUpVO> list = Helper.DataReaderMapToList<ProdInsPopUpVO>(reader);
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 헤더 체크박스 선택된 항목 모두 업데이트
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="ctemp"></param>
        /// <param name="stemp"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateAll(string ctemp, string stemp, string userName)
        {
            string checkSql = $@"update TBL_SHIP_CHECKLIST 
                                set cl_ship_Components = '양호', cl_ship_Packing = '양호', etc = '특이사항 없음'
                                where cl_ship_id in ({ctemp})";

            string shipSql = $@"update TBL_SHIPMENT
                                set ship_state = '검사완료', ship_uadmin = @ship_uadmin, ship_udate = convert(char(10), getdate(), 23)
                                where ship_id in ({stemp})";

            SqlTransaction tran = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.Transaction = tran;

            try
            {
                cmd.CommandText = checkSql;
                cmd.ExecuteNonQuery();

                cmd.Parameters.AddWithValue("@ship_uadmin", userName);
                cmd.CommandText = shipSql;
                cmd.ExecuteNonQuery();

                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="state"></param>
        /// <param name="componentTemp"></param>
        /// <param name="clPK"></param>
        /// <returns></returns>
        public bool Update(string state, string componentTemp, int clPK)
        {
            try
            {
                string sql = $@"update TBL_SHIP_CHECKLIST set {componentTemp} = @temp where cl_ship_id = @cl_ship_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@temp", state);
                    cmd.Parameters.AddWithValue("@cl_ship_id", clPK);
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

        #region 검사 이후 검사 이력에 새로 등록
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="ctemp"></param>
        /// <returns></returns>
        public bool InsertCheckHistory(string ctemp)
        {
            try
            {
                string sql = $@"EXEC SP_InsertCheckHistory_Ship @temp";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@temp", ctemp);
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

        #region 헤더 체크박스 선택된 항목 => DEV 출력
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210212
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public DataTable GetProdCheckInfoDEV(string temp)
        {
            try
            {
                string sql = $@"select cl_ship_id, 
		                        S.ship_id, 
		                        P.product_name, 
		                        REPLACE(cl_ship_Components, '미실시', ' ') as cl_ship_Components,
		                        REPLACE(cl_ship_Packing, '미실시', ' ') as cl_ship_Packing,
		                        REPLACE(etc,  '없음', ' ') as etc,
		                        production_state
                        from TBL_SHIP_CHECKLIST S join ProdCheck P on S.ship_id = P.ship_id
                        where S.ship_id in ({temp}) and production_state = '작업종료' 
                        and (cl_ship_Components = '미실시' or cl_ship_Components = '불량')
                        or (cl_ship_Packing = '미실시' or cl_ship_Packing = '불량')";

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

        #region 컨텍스트 메뉴스트립 => 비고버튼
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
                string sql = $@"update TBL_SHIP_CHECKLIST set {pEtc} = @temp where cl_ship_id = @cl_ship_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@temp", comment);
                    cmd.Parameters.AddWithValue("@cl_ship_id", pID);
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
