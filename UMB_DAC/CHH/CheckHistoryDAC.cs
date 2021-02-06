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
        public CheckHistoryDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        
        public List<CheckHistoryVO> GetCheckHisInfo()
        {
            string sql = @"select * from TBL_CHECK_HISTORY";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<CheckHistoryVO> list = Helper.DataReaderMapToList<CheckHistoryVO>(reader);
                return list;
            }
        }
        public List<CheckHistoryVO> GetCheckHisInfoWhere(string checkType)
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

        public List<GetCheckTypeVO> GetCheckTypeComboBox()
        {
            string sql = @"select common_id, common_name from TBL_COMMON_CODE where common_type = '검사유형'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<GetCheckTypeVO> list = Helper.DataReaderMapToList<GetCheckTypeVO>(reader);
                return list;
            }
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}
