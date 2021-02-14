using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;
using UMB_VO.ASB;

namespace UMB_DAC.ASB
{
    public class WorkOrderDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public WorkOrderDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        /// <summary>
        /// 불량유형 
        /// </summary>
        /// <returns></returns>
        public List<ComboItemVO> GetDefList()
        {
            string sql = @"select common_name, common_value
                        from TBL_COMMON_CODE
                        where common_type = '불량유형'";
                        
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                List<ComboItemVO> list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                Dispose();
                return list;
            }
        }

        public bool DefDelete(int common_id)
        {
            string sql = @"delete from TBL_COMMON_CODE
                            where common_id = @common_id";
            int iRowAffect = 0;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@common_id", common_id);
                


                iRowAffect = cmd.ExecuteNonQuery();
                Dispose();
            }
            return (iRowAffect > 0);
        }

        public bool DefUpdate(ComboItemVO def)
        {
            string sql = @"update TBL_COMMON_CODE 
                        set common_name = @common_name, common_value = @common_value
                        where common_id = @common_id";
            int iRowAffect = 0;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@common_id", def.common_id);
                cmd.Parameters.AddWithValue("@common_name", def.common_name);
                cmd.Parameters.AddWithValue("@common_value", def.common_value);


                iRowAffect = cmd.ExecuteNonQuery();
                Dispose();
            }
            return (iRowAffect > 0);
        }

        public int GetDefID(string common_name)
        {
            int common_id;
            string sql = @"select common_id
                            from TBL_COMMON_CODE
                            where common_name = @common_name";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@common_name", common_name);

                common_id = Convert.ToInt32(cmd.ExecuteScalar());
                Dispose();
            }
            return common_id;
        }

        public bool DefInsert(ComboItemVO def)
        {
            
            string sql = @"insert into TBL_COMMON_CODE(common_type, common_name, common_value)
                            values('불량유형', @common_name, @common_value)";
            int iRowAffect = 0;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@common_name", def.common_name);
                cmd.Parameters.AddWithValue("@common_value", def.common_value);
                             

                iRowAffect = cmd.ExecuteNonQuery();
                Dispose();
            }
            return (iRowAffect > 0);
        }

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public List<WorkOrderVO> SearchWOList(string pid, string state)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select wo_id, so_id, wo.product_id, product_name, wo.m_id, m_name, wo_pcount, wo_count,  CONVERT(CHAR(10), wo_date, 23) wo_date,CONVERT(CHAR(10), wo_sdate, 23) wo_sdate, wo_state, wo_uadmin, wo_udate
                        from TBL_WORK_ORDER wo inner join TBL_PRODUCT p on wo.product_id = p.product_id
                        inner join TBL_MACHINE m on wo.m_id = m.m_id
                        where 1=1 ");
            if (pid.Trim().Length > 0)
                sb.Append("and wo.product_id = @pid ");
            if (state.Trim().Length > 0 && state != "전체")
                sb.Append("and wo_state = @state ");
            string sql = sb.ToString();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@state", state);

                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkOrderVO> list = Helper.DataReaderMapToList<WorkOrderVO>(reader);
                Dispose();

                return list;
            }
        }

        /// <summary>
        /// 작업지시확정
        /// </summary>
        /// <param name="chkWOList"></param>
        /// <returns></returns>
        public bool updateWOState(List<int> chkWOList)
        {
            string temp = string.Join(",", chkWOList);            
            int iRowAffect = 0;
            int check = 0;

            
            //작업지시확정 > 생산 > 생산실적
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;

                    cmd.Connection = conn;
                    cmd.CommandText = @"update TBL_WORK_ORDER set wo_state = '작업대기'
                        where wo_id in (" + temp + ")";
                    iRowAffect = cmd.ExecuteNonQuery();



                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_ConfirmationWO";
                    foreach (int woid in chkWOList)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@wo_id", woid);
                        check += cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    Dispose();                    
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
                
            }
            

            
        }

        public List<WorkOrderVO> GetWoList()
        {
            string sql = @"select wo_id, so_id, wo.product_id, product_name, wo.m_id, m_name, wo_pcount, wo_count,  CONVERT(CHAR(10), wo_date, 23) wo_date,CONVERT(CHAR(10), wo_sdate, 23) wo_sdate, wo_state, wo_uadmin, wo_udate
from TBL_WORK_ORDER wo inner join TBL_PRODUCT p on wo.product_id = p.product_id
inner join TBL_MACHINE m on wo.m_id = m.m_id
";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {                
                SqlDataReader reader = cmd.ExecuteReader();

                List<WorkOrderVO> list = Helper.DataReaderMapToList<WorkOrderVO>(reader);
                Dispose();
                return list;
            }
        }
    }
}
