using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class WarehouseDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public WarehouseDAC()
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

        public List<WarehouseVO> WarehouseList()
        {
            string sql = "select w_id, w_name, w_address, w_type, w_deleted, w_uadmin, w_udate from TBL_WAREHOUSE";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<WarehouseVO> list = Helper.DataReaderMapToList<WarehouseVO>(reader);
                return list;
            }
        }

        public int InsertWH(WarehouseVO vo)
        {
            string sql = "insert into TBL_WAREHOUSE (w_name, w_address, w_type, w_uadmin, w_udate) values (@w_name, @w_address, @w_type, @w_uadmin, replace(convert(varchar(10), getdate(), 120), '-', '-'))";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@w_name", vo.w_name);
                    cmd.Parameters.AddWithValue("@w_address", vo.w_address);
                    cmd.Parameters.AddWithValue("@w_type", vo.w_type);
                    cmd.Parameters.AddWithValue("@w_uadmin", LoginVO.user.Name);

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

        public int UpdateWH(WarehouseVO vo)
        {
            string sql = "update TBL_WAREHOUSE set w_name = @w_name, w_address = @w_address, w_type = @w_type, w_uadmin = @w_uadmin, w_udate = replace(convert(varchar(10), getdate(), 120), '-', '-') where w_id = @w_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@w_id", vo.w_id);
                    cmd.Parameters.AddWithValue("@w_name", vo.w_name);
                    cmd.Parameters.AddWithValue("@w_address", vo.w_address);
                    cmd.Parameters.AddWithValue("@w_type", vo.w_type);
                    cmd.Parameters.AddWithValue("@w_uadmin", LoginVO.user.Name);

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

        public int DeleteWH(int w_id)
        {
            string sql = "update TBL_WAREHOUSE set w_deleted = 'Y' where w_id = @w_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@w_id", w_id);

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

        public List<ComboItemVO> WType()
        {
            string sql = "select common_name, common_type from TBL_COMMON_CODE where common_type = '창고구분'";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ComboItemVO> list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                return list;
            }
        }
    }
}
