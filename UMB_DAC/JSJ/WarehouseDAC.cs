using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_DAC
{
    class WarehouseDAC : ConnectionAccess, IDisposable
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
    }
}
