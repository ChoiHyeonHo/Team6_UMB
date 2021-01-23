﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_DAC
{
    public class BOMDAC : ConnectionAccess, IDisposable
    {
        SqlConnection conn;

        //public BOMDAC()
        //{
        //    conn = new SqlConnection(strConn);
        //    conn.Open();
        //}

        //public string enc()
        //{
        //    return strConn;
        //}

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
