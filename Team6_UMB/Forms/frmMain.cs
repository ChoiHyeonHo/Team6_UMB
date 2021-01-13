using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
