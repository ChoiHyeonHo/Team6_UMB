using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_VO.CHH;

namespace UMB_DAC.CHH
{
    public class ProdStatusDAC : ConnectionAccess, IDisposable
    {
        string strConn;
        SqlConnection conn;
        public ProdStatusDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public List<ProdStatusVO> GetProdInfo()
        {
            string sql = @"select * from ProductStatus";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProdStatusVO> list = Helper.DataReaderMapToList<ProdStatusVO>(reader);
                return list;
            }
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
