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
            pnlMain1.Dock = pnlMain2.Dock = pnlMain3.Dock = pnlMain4.Dock = pnlMain5.Dock = pnlMain6.Dock = DockStyle.Fill;
            pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            btnArrow.Text = "≪";
        }

        private void btnMain1_Click(object sender, EventArgs e)
        {
            PanelControl(1);
        }

        private void btnMain2_Click(object sender, EventArgs e)
        {
            PanelControl(2);
        }

        private void btnMain3_Click(object sender, EventArgs e)
        {
            PanelControl(3);
        }

        private void btnMain4_Click(object sender, EventArgs e)
        {
            PanelControl(4);
        }

        private void btnMain5_Click(object sender, EventArgs e)
        {
            PanelControl(5);
        }

        private void btnMain6_Click(object sender, EventArgs e)
        {
            PanelControl(6);
        }

        #region 패널 컨트롤
        /// <summary>
        /// 작성자 : 최현호
        /// 작성일 : 21-01-16
        /// </summary>
        /// <param name="value"></param>
        private void PanelControl(int value)
        {
            switch (value)
            {
                case 1:
                    pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = false;
                    if (pnlMain1.Visible == false)
                        pnlMain1.Visible = true;
                    break;

                case 2:
                    pnlMain1.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = false;
                    if (pnlMain2.Visible == false)
                        pnlMain2.Visible = true;
                    break;

                case 3:
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = false;
                    if (pnlMain3.Visible == false)
                        pnlMain3.Visible = true;
                    break;

                case 4:
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain5.Visible = pnlMain6.Visible = false;
                    if (pnlMain4.Visible == false)
                        pnlMain4.Visible = true;
                    break;

                case 5:
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain6.Visible = false;
                    if (pnlMain5.Visible == false)
                        pnlMain5.Visible = true;
                    break;

                case 6:
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = false;
                    if (pnlMain6.Visible == false)
                        pnlMain6.Visible = true;
                    break;
            }
        }
        #endregion

        private void btn1_1_Click(object sender, EventArgs e)
        {
            this.btn1_1.BackColor = System.Drawing.Color.White;
            this.btn1_1.ForeColor = System.Drawing.Color.Black;
        }

        private void btnArrow_Click(object sender, EventArgs e)
        {
            if (btnArrow.Text == "≪")
            {
                pnlButtons.Visible = false;
                pnlNavigation.Dock = DockStyle.Fill;
                pnlMenu.Size = new Size(49, 789);
                btnArrow.Text = "≫";
                pbChangeUser.Location = new Point(0, 49);
                pbSetting.Location = new Point(0, 98);
                pbExcel.Location = new Point(0, 147);
                pbPrint.Location = new Point(0, 196);
                
            }
            else if(btnArrow.Text == "≫")
            {
                pnlButtons.Visible = true;
                pnlNavigation.Dock = DockStyle.Top;
                pnlMenu.Size = new Size(151, 789);
                btnArrow.Text = "≪";
                pbChangeUser.Location = new Point(49, 0);
                pbSetting.Location = new Point(98, 0);
                pbExcel.Location = new Point(3, 49);
                pbPrint.Location = new Point(49, 49);

            }
        }

        private void pbChangeUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User Change");
        }

        private void pbSetting_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings....");
        }

        private void pnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
