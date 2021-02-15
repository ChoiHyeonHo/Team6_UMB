using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.ASB;

namespace UMB_DAC.ASB
{
    public class DefetiveDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public DefetiveDAC()
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

        public List<DefectiveVO> GetDefStatus()
        {
            string sql = @"select defective_ID, defective_stime, d.performance_id performance_id, per.product_id product_id, product_name, process_name , common_name, defective_count
                            from TBL_DEFECTIVE d inner join  TBL_COMMON_CODE c
                            on d.common_id = c.common_id
                            inner join TBL_performance per
                            on d.performance_id = per.performance_id
                            inner join TBL_PRODUCT p
                            on per.product_id = p.product_id
                            inner join TBL_Production pro
                            on per.production_id = pro.production_id
                            ";

            
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DefectiveVO> list = Helper.DataReaderMapToList<DefectiveVO>(reader);
                    Dispose();

                    return list;
                }
        }

        public List<DefectiveVO> SearchDefList(string pid, string pname)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select defective_ID, defective_stime, d.performance_id, per.product_id, product_name, process_name , common_name, defective_count
                            from TBL_DEFECTIVE d inner join  TBL_COMMON_CODE c
                            on d.common_id = c.common_id
                            inner join TBL_performance per
                            on d.performance_id = per.performance_id
                            inner join TBL_PRODUCT p
                            on per.product_id = p.product_id
                            inner join TBL_Production pro
                            on per.production_id = pro.production_id
                            where 1=1 ");
            if (pid.Trim().Length > 0)
                sb.Append("and per.product_id = @product_id ");            
            if (pname.Trim().Length > 0)
                sb.Append("and process_name = @process_name ");
            string sql = sb.ToString();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@product_id", pid);                
                cmd.Parameters.AddWithValue("@process_name", pname);


                SqlDataReader reader = cmd.ExecuteReader();

                List<DefectiveVO> list = Helper.DataReaderMapToList<DefectiveVO>(reader);
                Dispose();

                return list;
            }
        }
    }
}
