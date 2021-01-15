using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UMB_WEBAPI.DAC
{
    public class SampleDAC
    {
        SqlConnection conn;
        public SampleDAC()
        {
            conn = new SqlConnection(Connection.strConn);
            conn.Open();
        }
    }
}