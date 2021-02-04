﻿using System;
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
        public ProdImpInsDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public List<ProdImpInsVO> GetIncomminInfo()
        {
            string sql = @"select incomming_ID, incomming_state, incomming_date, incomming_rep, incomming_count, 
	                                concat(O.order_id, ' / ' , P.product_id, P.product_name) as order_id, 
	                                orderexam_result, incomming_uadmin, incomming_udate
                                from TBL_INCOMMING I join TBL_ORDER O on I.order_id = O.order_id
					                                 join TBL_PRODUCT P on O.product_id = P.product_id
                                where incomming_state = '대기'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProdImpInsVO> list = Helper.DataReaderMapToList<ProdImpInsVO>(reader);
                return list;
            }
        }
        public List<InsCheckVO> GetInsCheckInfo(string temp)
        {
            string sql = $@"select cl_inc_id, incomming_ID, 
		                        isnull(cl_inc_Color, '미실시') as cl_inc_Color,
		                        isnull(cl_inc_Torn, '미실시') as  cl_inc_Torn, 
		                        isnull(cl_inc_Length, '미실시') as cl_inc_Length,
		                        isnull(cl_inc_Crack, '미실시') as cl_inc_Crack,
		                        isnull(etc, '없음') as etc
                        from TBL_INC_CHECKLIST where incomming_ID in ({temp})";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<InsCheckVO> list = Helper.DataReaderMapToList<InsCheckVO>(reader);
                return list;
            }
        }

        public DataTable GetInsCheckInfoDEV(string temp)
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

        public bool Update(string pTemp, string cl_inc_Color, int cl_inc_id)
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
        public bool Comment(string pEtc, string comment, int pID)
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

        public void Dispose()
        {
            conn.Close();
        }
    }
}