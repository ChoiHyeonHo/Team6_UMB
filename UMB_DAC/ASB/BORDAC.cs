using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO;

namespace UMB_DAC
{
    public class BORDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;

        public BORDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        

        public List<BORVO> GetBORList()
        {
            string sql = @"select bor_id, bor.product_id product_id, product_name, process_name, bor.m_id m_id, m_name, bor_tacttime, bor_yn, bor_comment, bor_uadmin, bor_udate 
                            from TBL_BOR bor 
                            inner join TBL_PRODUCT pro
                            on bor.product_id = pro.product_id
                            inner join TBL_MACHINE mac
                            on bor.m_id = mac.m_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                
                List<BORVO> list = Helper.DataReaderMapToList<BORVO>(reader);
                Dispose();
                return list;
            }
        }

        public bool BORDelete(int BOR_id)
        {
            string sql = @"DELETE FROM TBL_BOR where bor_id = @bor_id";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bor_id", BOR_id);

                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool BORUpdate(BORVO bor)
        {
            string sql = @"UPDATE TBL_BOR 
                        SET product_id = @product_id, process_name = @process_name, m_id = @m_id, 
                        bor_tacttime = @bor_tacttime, bor_yn = @bor_yn, bor_comment = @bor_comment
                        , bor_uadmin = @bor_comment, bor_udate = @bor_udate
                        WHERE bor_id = @bor_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bor_id", bor.BOR_id);
                cmd.Parameters.AddWithValue("@product_id", bor.product_id);
                cmd.Parameters.AddWithValue("@process_name", bor.process_name);
                cmd.Parameters.AddWithValue("@m_id", bor.m_id);
                cmd.Parameters.AddWithValue("@bor_tacttime", bor.bor_tacttime);
                cmd.Parameters.AddWithValue("@bor_yn", bor.bor_yn);
                cmd.Parameters.AddWithValue("@bor_comment", bor.bor_comment);
                cmd.Parameters.AddWithValue("@bor_uadmin", bor.bor_uadmin);
                cmd.Parameters.AddWithValue("@bor_udate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                int iRowAffect = cmd.ExecuteNonQuery();
                conn.Close();

                return iRowAffect > 0;
            }
        }

        public bool BORInsert(BORVO bor)
        {
            string sql = @"insert into TBL_BOR(product_id, process_name, m_id, bor_tacttime, bor_yn, bor_comment, bor_uadmin, bor_udate)
                            values(@product_id, @process_name, @m_id, @bor_tacttime, @bor_yn, @bor_comment, @bor_uadmin, @bor_udate)";
            int iRowAffect = 0;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@product_id", bor.product_id);
                cmd.Parameters.AddWithValue("@process_name", bor.process_name);
                cmd.Parameters.AddWithValue("@m_id", bor.m_id);
                cmd.Parameters.AddWithValue("@bor_tacttime", bor.bor_tacttime);
                cmd.Parameters.AddWithValue("@bor_yn", bor.bor_yn);
                cmd.Parameters.AddWithValue("@bor_comment", bor.bor_comment);
                cmd.Parameters.AddWithValue("@bor_uadmin", bor.bor_uadmin);
                cmd.Parameters.AddWithValue("@bor_udate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                iRowAffect = cmd.ExecuteNonQuery();
                Dispose();
            }
            return (iRowAffect > 0);
        }

        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="product_id"></param>
        /// <param name="m_id"></param>
        /// <param name="process_name"></param>
        /// <returns></returns>
        public List<BORVO> SearchBorList(string product_id, int m_id, string process_name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select bor_id, bor.product_id product_id, product_name, process_name, bor.m_id m_id, m_name, bor_tacttime, bor_yn, bor_comment, bor_uadmin, bor_udate 
                            from TBL_BOR bor 
                            inner join TBL_PRODUCT pro
                            on bor.product_id = pro.product_id
                            inner join TBL_MACHINE mac
                            on bor.m_id = mac.m_id 
                            where 1=1 ");
            if (product_id.Trim().Length > 0)
                sb.Append("and bor.product_id = @product_id ");
            if (m_id > 0)
                sb.Append("and bor.m_id = @m_id ");
            if (process_name.Trim().Length > 0)
                sb.Append("and process_name = @process_name ");
            string sql = sb.ToString();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@product_id", product_id);
                cmd.Parameters.AddWithValue("@m_id", m_id);
                cmd.Parameters.AddWithValue("@process_name", process_name);


                SqlDataReader reader = cmd.ExecuteReader();

                List<BORVO> list = Helper.DataReaderMapToList<BORVO>(reader);
                Dispose();
                
                return list;
            }
        }

        public void Dispose()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }


        #region EXAMPLE CRUD        
        //public List<VO> SELECT()
        //{
        //    string sql = @"SELECT COLUMNS from Table";
        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
        //    {
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        List<VO> list = Helper.DataReaderMapToList<VO>(reader);
        //        return list;
        //    }
        //}

        //public bool INSERT(VO vo)
        //{
        //    string sql = @"INSERT INTO TABLE (A, B, C) 
        //                    values (@A, @B, @C)";
        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@A", vo.A);
        //        cmd.Parameters.AddWithValue("@B", vo.B);
        //        cmd.Parameters.AddWithValue("@C", vo.C);

        //        int iRowAffect = cmd.ExecuteNonQuery();
        //        conn.Close();

        //        return iRowAffect > 0;
        //    }
        //}

        //public bool UPDATE(VO vo)
        //{
        //    string sql = @"UPDATE TABLE SET A = @A, B = @B, C = @C WHERE D = @D
        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@A", vo.A);
        //        cmd.Parameters.AddWithValue("@B", vo.B);
        //        cmd.Parameters.AddWithValue("@C", vo.C);
        //        cmd.Parameters.AddWithValue("@D", vo.D);

        //        int iRowAffect = cmd.ExecuteNonQuery();
        //        conn.Close();

        //        return iRowAffect > 0;
        //    }
        //}

        //public bool DELETE(VO vo)
        //{
        //    string sql = @"DELETE FROM TABLE where A = @A";

        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@A", vo.A);

        //        int iRowAffect = cmd.ExecuteNonQuery();
        //        conn.Close();

        //        return iRowAffect > 0;
        //    }
        //}
        #endregion
    }
}
