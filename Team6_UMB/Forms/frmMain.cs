using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team6_UMB.Service;

namespace Team6_UMB
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            pnlSub1.Visible = pnlSub2.Visible = pnlSub3.Visible = pnlSub4.Visible = pnlSub5.Visible = pnlSub6.Visible = false;
        }


        #region 패널 제어
        private void btn_Main1_Click(object sender, EventArgs e)
        {
            if (pnlSub1.Visible == true)
                pnlSub1.Visible = false;
            else
                pnlSub1.Visible = true;
        }

        private void btn_Main2_Click(object sender, EventArgs e)
        {
            if (pnlSub2.Visible == true)
                pnlSub2.Visible = false;
            else
                pnlSub2.Visible = true;
        }

        private void btn_Main3_Click(object sender, EventArgs e)
        {
            if (pnlSub3.Visible == true)
                pnlSub3.Visible = false;
            else
                pnlSub3.Visible = true;
        }

        private void btn_Main4_Click(object sender, EventArgs e)
        {
            if (pnlSub4.Visible == true)
                pnlSub4.Visible = false;
            else
                pnlSub4.Visible = true;
        }

        private void btn_Main5_Click(object sender, EventArgs e)
        {
            if (pnlSub5.Visible == true)
                pnlSub5.Visible = false;
            else
                pnlSub5.Visible = true;
        }

        private void btn_Main6_Click(object sender, EventArgs e)
        {
            if (pnlSub6.Visible == true)
                pnlSub6.Visible = false;
            else
                pnlSub6.Visible = true;
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            //textBox1.Text = "Server=whyfi8888.ddns.net,11433;Database=team6;Uid=team6;Pwd=team6";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BOMService service = new BOMService();
            textBox1.Text = service.enc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BOMService service = new BOMService();
                string strConn = service.enc();

                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();

                MessageBox.Show("DB연결 성공");

                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
