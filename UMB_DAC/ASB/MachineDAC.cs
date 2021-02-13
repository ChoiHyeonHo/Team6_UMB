using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC.ASB
{
    public class MachineDAC : ConnectionAccess, IDisposable
    {
        SqlConnection conn;
        string strConn;

        public MachineDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }        

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
        public List<MachineVO> GetMachineInfo()
        {
            string sql = @"select m_id, m_name
            from TBL_MACHINE";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<MachineVO> list = Helper.DataReaderMapToList<MachineVO>(reader);
                return list;
            }
        }
        public List<MachineVO> CHH_GetMachineInfo()
        {
            string sql = @"select * from TBL_MACHINE where m_yn = 'Y'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<MachineVO> list = Helper.DataReaderMapToList<MachineVO>(reader);
                return list;
            }
        }
        public bool CHH_MachineInsert(MachineVO vo)
        {
            string sql = @"insert into TBL_MACHINE(m_info, m_name, m_comment, m_yn)
                            values (@m_info, @m_name, @m_comment, @m_yn)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@m_info", vo.m_info);
                cmd.Parameters.AddWithValue("@m_name", vo.m_name);
                cmd.Parameters.AddWithValue("@m_comment", vo.m_comment);
                cmd.Parameters.AddWithValue("@m_yn", vo.m_yn);
                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }
        public bool CHH_MachineUpdate(MachineVO vo)
        {
            string sql = @"update TBL_MACHINE 
                           set m_info = @m_info, m_name = @m_name, m_comment = @m_comment, 
	                                m_yn = @m_yn, m_uadmin = @m_uadmin, m_udate = @m_udate
                           where m_id = @m_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@m_info", vo.m_info);
                cmd.Parameters.AddWithValue("@m_name", vo.m_name);
                cmd.Parameters.AddWithValue("@m_comment", vo.m_comment);
                cmd.Parameters.AddWithValue("@m_yn", vo.m_yn);
                cmd.Parameters.AddWithValue("@m_uadmin", vo.m_uadmin);
                cmd.Parameters.AddWithValue("@m_udate", vo.m_udate);
                cmd.Parameters.AddWithValue("@m_id", vo.m_id);
                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }
        public bool CHH_MachineDelete(int m_id)
        {
            string sql = @"update TBL_MACHINE set m_yn = 'N' where m_id = @m_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@m_id", m_id);
                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }
        public List<MachineVO> CHH_MachineWhere(string m_name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from TBL_MACHINE where m_yn = 'Y' and 1 =1 ");
            if (m_name.Trim().Length > 0)
                sb.Append("and m_name = @m_name");
            string sql = sb.ToString();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@m_name", m_name);

                SqlDataReader reader = cmd.ExecuteReader();

                List<MachineVO> list = Helper.DataReaderMapToList<MachineVO>(reader);
                Dispose();

                return list;
            }
        }
    }
}
