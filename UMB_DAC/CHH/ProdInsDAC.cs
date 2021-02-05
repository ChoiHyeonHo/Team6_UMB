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
        public ProdInsDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public List<ProdInsVO> GetProdInsInfo()
        {
            string sql = @"select * from ProdCheck where ship_state = '검사대기'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProdInsVO> list = Helper.DataReaderMapToList<ProdInsVO>(reader);
                return list;
            }
        }

        public List<ProdInsPopUpVO> GetProdInsPopUpInfo(string temp)
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
            catch (Exception err)
            {
                tran.Rollback();
                throw err;
                return false;
            }
        }
        public bool Update(string state, string componentTemp, int clPK)
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
        public DataTable GetProdCheckInfoDEV(string temp)
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

        public void Dispose()
        {
            conn.Close();
        }
    }
}
