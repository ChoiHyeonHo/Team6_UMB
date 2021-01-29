using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;
using UMB_VO.ASB;

namespace UMB_DAC.ASB
{
    public class CheckListDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public CheckListDAC()
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

        public List<ComboItemVO> GetCheckTypeInfoByCodeTypes(string[] gubun)
        {
            string type = string.Join("','", gubun);
            string sql = @"select common_id, common_type, common_name
    from TBL_COMMON_CODE
    where common_type in ('" + type + "')";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ComboItemVO> list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                return list;
            }
        }

        public bool ChkUpdate(CheckListVO chk)
        {
            string sql = @"update TBL_CHECKLIST
                            set cl_name = @cl_name, product_id= @product_id, cl_stnd = @cl_stnd, 
                            cl_comment = @cl_comment, cl_uadmin = @cl_uadmin, cl_udate = @cl_udate, cl_type = @cl_type
                            where cl_id = @cl_id";
                                        using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@cl_id", chk.cl_id);
                cmd.Parameters.AddWithValue("@cl_name", chk.cl_name);
                cmd.Parameters.AddWithValue("@product_id", chk.product_id);
                cmd.Parameters.AddWithValue("@cl_stnd", chk.cl_stnd);
                cmd.Parameters.AddWithValue("@cl_comment", chk.cl_comment);
                cmd.Parameters.AddWithValue("@cl_uadmin", chk.cl_uadmin);
                cmd.Parameters.AddWithValue("@cl_type", chk.cl_type);                
                cmd.Parameters.AddWithValue("@cl_udate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool ChkDelete(int cl_id)
        {
            string sql = @"DELETE FROM TBL_CHECKLIST where cl_id = @cl_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@cl_id", cl_id);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool ChkInsert(CheckListVO chk)
        {
            string sql = @"insert into TBL_CHECKLIST (cl_name, product_id, cl_stnd, cl_comment, cl_uadmin, cl_udate, cl_type)
                            values (cl_name, product_id, cl_stnd, cl_comment, cl_uadmin, cl_udate, cl_type)";
            int iRowAffect = 0;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@cl_name", chk.cl_name);
                cmd.Parameters.AddWithValue("@product_id", chk.product_id);
                cmd.Parameters.AddWithValue("@cl_stnd", chk.cl_stnd);
                cmd.Parameters.AddWithValue("@cl_comment", chk.cl_comment);
                cmd.Parameters.AddWithValue("@cl_uadmin", chk.cl_uadmin);                
                cmd.Parameters.AddWithValue("@cl_type", chk.cl_type);
                cmd.Parameters.AddWithValue("@cl_udate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                iRowAffect = cmd.ExecuteNonQuery();
                Dispose();
            }
            return (iRowAffect > 0);
        }

        public List<CheckListVO> SearchChkList(string checkType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select cl_id, cl_name, CHK.product_id, product_name, cl_stnd, cl_comment, cl_uadmin, cl_udate, cl_type
                            from TBL_CHECKLIST CHK inner join TBL_PRODUCT P
                            on CHK.product_id = P.product_id
                            where 1=1 ");

            if(checkType.Trim().Length > 0)
            {
                sb.Append("and cl_type = @cl_type ");
            }
            string sql = sb.ToString();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@cl_type", checkType);

                SqlDataReader reader = cmd.ExecuteReader();

                List<CheckListVO> list = Helper.DataReaderMapToList<CheckListVO>(reader);
                Dispose();
                return list;
            }
        }

        public List<CheckListVO> GetChkList()
        {
            string sql = @"select cl_id, cl_name, CHK.product_id, product_name, cl_stnd, cl_comment, cl_uadmin, cl_udate, cl_type
                            from TBL_CHECKLIST CHK inner join TBL_PRODUCT P
                            on CHK.product_id = P.product_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                List<CheckListVO> list = Helper.DataReaderMapToList<CheckListVO>(reader);
                Dispose();
                return list;
            }
        }
    }
}
