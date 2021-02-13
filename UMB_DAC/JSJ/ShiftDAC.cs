using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class ShiftDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public ShiftDAC()
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

        public List<ShiftVO> ShiftList()
        {
            string sql = "select shift_id, m_id, shift_stime, shift_etime, shift_sdate, shift_edate, shift_yn, shift_comment, shift_uadmin, shift_udate, shift_personnel, shift_weekend, shift_dns from TBL_MACHINE_SHIFT";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ShiftVO> list = Helper.DataReaderMapToList<ShiftVO>(reader);
                return list;
            }
        }

        public List<cboMachineVO> cboMachine()
        {
            string sql = "select m_id, m_name from TBL_MACHINE";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<cboMachineVO> list = Helper.DataReaderMapToList<cboMachineVO>(reader);
                return list;
            }
        }

        public int InsertShift(ShiftVO vo)
        {
            string sql = "insert into TBL_MACHINE_SHIFT (m_id, shift_stime, shift_etime, shift_sdate, shift_edate, shift_comment, shift_uadmin, shift_udate, shift_personnel, shift_weekend, shift_dns) values (@m_id, @shift_stime, @shift_etime, @shift_sdate, @shift_edate, @shift_comment, @shift_uadmin, replace(convert(varchar(10), getdate(), 120), '-', '-'), @shift_personnel, @shift_weekend, @shift_dns)";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@m_id", vo.m_id);
                    cmd.Parameters.AddWithValue("@shift_stime", vo.shift_stime);
                    cmd.Parameters.AddWithValue("@shift_etime", vo.shift_etime);
                    cmd.Parameters.AddWithValue("@shift_sdate", vo.shift_sdate);
                    cmd.Parameters.AddWithValue("@shift_edate", vo.shift_edate);
                    cmd.Parameters.AddWithValue("@shift_comment", vo.shift_comment);
                    cmd.Parameters.AddWithValue("@shift_uadmin", LoginVO.user.Name);
                    cmd.Parameters.AddWithValue("@shift_personnel", vo.shift_personnel);
                    cmd.Parameters.AddWithValue("@shift_weekend", vo.shift_weekend);
                    cmd.Parameters.AddWithValue("@shift_dns", vo.shift_dns);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception err)
                {
                    string msg = err.Message;
                    return 0;
                }
            }
        }

        public int UpdateShift(ShiftVO vo)
        {
            string sql = "update TBL_MACHINE_SHIFT set m_id = @m_id, shift_stime = @shift_stime, shift_etime = @shift_etime, shift_sdate = @shift_sdate, shift_edate = @shift_edate, shift_comment = @shift_comment, shift_uadmin = @shift_uadmin, shift_udate = replace(convert(varchar(10), getdate(), 120), '-', '-'), shift_personnel = @shift_personnel, shift_weekend = @shift_weekend, shift_dns = @shift_dns where shift_id = @shift_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@shift_id", vo.shift_id);
                    cmd.Parameters.AddWithValue("@m_id", vo.m_id);
                    cmd.Parameters.AddWithValue("@shift_stime", vo.shift_stime);
                    cmd.Parameters.AddWithValue("@shift_etime", vo.shift_etime);
                    cmd.Parameters.AddWithValue("@shift_sdate", vo.shift_sdate);
                    cmd.Parameters.AddWithValue("@shift_edate", vo.shift_edate);
                    cmd.Parameters.AddWithValue("@shift_comment", vo.shift_comment);
                    cmd.Parameters.AddWithValue("@shift_uadmin", LoginVO.user.Name);
                    cmd.Parameters.AddWithValue("@shift_personnel", vo.shift_personnel);
                    cmd.Parameters.AddWithValue("@shift_weekend", vo.shift_weekend);
                    cmd.Parameters.AddWithValue("@shift_dns", vo.shift_dns);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception err)
                {
                    string msg = err.Message;
                    return 0;
                }
            }
        }

        public int DeleteShift(int shift_id)
        {
            string sql = "update TBL_MACHINE_SHIFT set shift_yn = 'N' where shift_id = @shift_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@shift_id", shift_id);

                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception err)
                {
                    string msg = err.Message;
                    return 0;
                }
            }
        }
    }
}
