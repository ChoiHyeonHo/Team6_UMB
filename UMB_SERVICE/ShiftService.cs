using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using UMB_DAC;

namespace UMB_SERVICE
{
    public partial class ShiftService : ServiceBase
    {
        private Timer timer;
        string sql = @"update TBL_MACHINE_SHIFT set shift_yn = 'N'
                       where concat(shift_edate, ' ', shift_etime) = format(getdate(), 'yyyy-MM-dd HH:mm') and shift_yn = 'Y'";

        string strConn;
        SqlConnection conn;

        public ShiftService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string currentPath = System.IO.Directory.GetCurrentDirectory();
            XmlDocument configXml = new XmlDocument();
            string path = currentPath + "/DBConnection.xml";
            configXml.Load(path);

            XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add");

            foreach (XmlNode node in addNodes)
            {
                if (node.Attributes["key"].InnerText == "Team6")
                {
                    EncrytLibrary.AES aes = new EncrytLibrary.AES();
                    strConn = aes.AESDecrypt256((node.ChildNodes[0]).InnerText);
                    break;
                }
            }

            conn = new SqlConnection(strConn);
            conn.Open();

            timer = new Timer();
            timer.Interval = 60000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        protected override void OnStop()
        {
            timer.Stop();
            conn.Close();
        }
    }
}
