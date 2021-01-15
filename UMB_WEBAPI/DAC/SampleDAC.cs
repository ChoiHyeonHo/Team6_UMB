using log4net;
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
        ILog log = null;

        public SampleDAC(ILog log)
        {
            this.log = log;
            conn = new SqlConnection(Connection.strConn);
            conn.Open();
        }

        public string logsample()
        {
            try
            {
                return null;
            }
            catch(Exception err)
            {
                log.Error("오류 : " + err.Message);
                return null;
            }
        }
    }
}