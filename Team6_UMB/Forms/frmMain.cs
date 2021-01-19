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
using Team6_UMB.Forms;
using Team6_UMB.Service;

namespace Team6_UMB
{
    public partial class frmMain : Form
    {
        #region 싱글톤 - 스태틱 선언
        public static frmSalesPriceManage frmSalesPriceManage;
        public static frmMatPriceManage frmMatPriceManage;
        public static frmProductManage frmProductManage;
        public static frmBOM frmBOM;
        #endregion

        public frmMain()
        {
            InitializeComponent();
            pnlMain1.Dock = pnlMain2.Dock = pnlMain3.Dock = pnlMain4.Dock = pnlMain5.Dock = pnlMain6.Dock = pnlMain7.Dock = DockStyle.Fill;
            pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = pnlMain7.Visible = false;
        }

        #region 싱글톤 - 메서드를 통한 폼 유무 체크
        public static frmSalesPriceManage CreateSalesPriceManage()
        {
            if (frmSalesPriceManage == null)
            {
                frmSalesPriceManage = new frmSalesPriceManage();
            }
            return frmSalesPriceManage;
        }
        
        public static frmMatPriceManage CreateMatPriceManage()
        {
            if (frmMatPriceManage == null)
            {
                frmMatPriceManage = new frmMatPriceManage();
            }
            return frmMatPriceManage;
        }

        public static frmProductManage CreateProductManage()
        {
            if (frmProductManage == null)
            {
                frmProductManage = new frmProductManage();
            }
            return frmProductManage;
        }

        public static frmBOM CreateBOM()
        {
            if (frmBOM == null)
            {
                frmBOM = new frmBOM();
            }
            return frmBOM;
        }
        #endregion

        #region 상단 메뉴 클릭
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
        private void btnMain7_Click(object sender, EventArgs e)
        {
            PanelControl(7);
        }
        #endregion

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
                    #region Visible제어
                    pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = pnlMain7.Visible = false;
                    #endregion

                    #region 버튼1의 BackColor, ForeColor 제어
                    btnMain1.BackColor = Color.White;
                    btnMain1.ForeColor = Color.Black;
                    #endregion

                    #region 선택되지 않은 버튼의 BackColor, ForeColor 제어
                    btnMain2.BackColor = btnMain3.BackColor = btnMain4.BackColor = btnMain5.BackColor = btnMain6.BackColor = btnMain7.BackColor = Color.Transparent;
                    btnMain2.ForeColor = btnMain3.ForeColor = btnMain4.ForeColor = btnMain5.ForeColor = btnMain6.ForeColor = btnMain7.ForeColor = Color.White;
                    #endregion

                    if (pnlMain1.Visible == false)
                        pnlMain1.Visible = true;
                    break;

                case 2:
                    #region Visible제어
                    pnlMain1.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = pnlMain7.Visible = false;
                    #endregion

                    #region 버튼2의 BackColor, ForeColor 제어
                    btnMain2.BackColor = Color.White;
                    btnMain2.ForeColor = Color.Black;
                    #endregion

                    #region 선택되지 않은 버튼의 BackColor, ForeColor 제어
                    btnMain1.BackColor = btnMain3.BackColor = btnMain4.BackColor = btnMain5.BackColor = btnMain6.BackColor = btnMain7.BackColor = Color.Transparent;
                    btnMain1.ForeColor = btnMain3.ForeColor = btnMain4.ForeColor = btnMain5.ForeColor = btnMain6.ForeColor = btnMain7.ForeColor = Color.White;
                    #endregion

                    if (pnlMain2.Visible == false)
                        pnlMain2.Visible = true;
                    break;

                case 3:
                    #region Visible 제어
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = pnlMain7.Visible = false;
                    #endregion

                    #region 버튼3의 BackColor, ForeColor 제어
                    btnMain3.BackColor = Color.White;
                    btnMain3.ForeColor = Color.Black;
                    #endregion

                    #region 선택되지 않은 버튼의 BackColor, ForeColor 제어
                    btnMain1.BackColor = btnMain2.BackColor = btnMain4.BackColor = btnMain5.BackColor = btnMain6.BackColor = btnMain7.BackColor = Color.Transparent;
                    btnMain1.ForeColor = btnMain2.ForeColor = btnMain4.ForeColor = btnMain5.ForeColor = btnMain6.ForeColor = btnMain7.ForeColor = Color.White;
                    #endregion

                    if (pnlMain3.Visible == false)
                        pnlMain3.Visible = true;
                    break;

                case 4:
                    #region Visible 제어
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain5.Visible = pnlMain6.Visible = pnlMain7.Visible = false;
                    #endregion

                    #region 버튼4의 BackColor, ForeColor 제어
                    btnMain4.BackColor = Color.White;
                    btnMain4.ForeColor = Color.Black;
                    #endregion

                    #region 선택되지 않은 버튼의 BackColor, ForeColor 제어
                    btnMain1.BackColor = btnMain2.BackColor = btnMain3.BackColor = btnMain5.BackColor = btnMain6.BackColor = btnMain7.BackColor = Color.Transparent;
                    btnMain1.ForeColor = btnMain2.ForeColor = btnMain3.ForeColor = btnMain5.ForeColor = btnMain6.ForeColor = btnMain7.ForeColor = Color.White;
                    #endregion

                    if (pnlMain4.Visible == false)
                        pnlMain4.Visible = true;
                    break;

                case 5:
                    #region Visible 제어
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain6.Visible = pnlMain7.Visible = false;
                    #endregion

                    #region 버튼5의 BackColor, ForeColor 제어
                    btnMain5.BackColor = Color.White;
                    btnMain5.ForeColor = Color.Black;
                    #endregion

                    #region 선택되지 않은 버튼의 BackColor, ForeColor 제어
                    btnMain1.BackColor = btnMain2.BackColor = btnMain3.BackColor = btnMain4.BackColor = btnMain6.BackColor = btnMain7.BackColor = Color.Transparent;
                    btnMain1.ForeColor = btnMain2.ForeColor = btnMain3.ForeColor = btnMain4.ForeColor = btnMain6.ForeColor = btnMain7.ForeColor = Color.White;
                    #endregion

                    if (pnlMain5.Visible == false)
                        pnlMain5.Visible = true;
                    break;

                case 6:
                    #region Visible 제어
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain7.Visible = false;
                    #endregion

                    #region 버튼6의 BackColor, ForeColor 제어
                    btnMain6.BackColor = Color.White;
                    btnMain6.ForeColor = Color.Black;
                    #endregion

                    #region 선택되지 않은 버튼의 BackColor, ForeColor 제어
                    btnMain1.BackColor = btnMain2.BackColor = btnMain3.BackColor = btnMain4.BackColor = btnMain5.BackColor = btnMain7.BackColor = Color.Transparent;
                    btnMain1.ForeColor = btnMain2.ForeColor = btnMain3.ForeColor = btnMain4.ForeColor = btnMain5.ForeColor = btnMain7.ForeColor = Color.White;
                    #endregion

                    if (pnlMain6.Visible == false)
                        pnlMain6.Visible = true;
                    break;

                case 7:
                    #region Visible 제어
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible= pnlMain6.Visible = false;
                    #endregion

                    #region 버튼7의 BackColor, ForeColor 제어
                    btnMain7.BackColor = Color.White;
                    btnMain7.ForeColor = Color.Black;
                    #endregion

                    #region 선택되지 않은 버튼의 BackColor, ForeColor 제어
                    btnMain1.BackColor = btnMain2.BackColor = btnMain3.BackColor = btnMain4.BackColor = btnMain5.BackColor = btnMain6.BackColor = Color.Transparent;
                    btnMain1.ForeColor = btnMain2.ForeColor = btnMain3.ForeColor = btnMain4.ForeColor = btnMain5.ForeColor = btnMain6.ForeColor = Color.White;
                    #endregion

                    if (pnlMain7.Visible == false)
                        pnlMain7.Visible = true;
                    break;
            }
        }
        #endregion

        private void btn1_1_Click(object sender, EventArgs e)
        {
            this.btn1_1.BackColor = System.Drawing.Color.White;
            this.btn1_1.ForeColor = System.Drawing.Color.Black;
        }

        #region 최소, 최대, 닫기
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
        #endregion

        #region 폼 생성 및 Docking
        private void btn2_1_Click(object sender, EventArgs e)
        {
            this.btn2_1.BackColor = Color.White;
            this.btn2_2.BackColor = Color.Transparent;
            this.btn2_1.ForeColor = Color.Black;
            this.btn2_2.ForeColor = Color.White;
            CreateSalesPriceManage();
            frmSalesPriceManage.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmSalesPriceManage);
            frmSalesPriceManage.Dock = DockStyle.Fill;
            frmSalesPriceManage.Show();
        }

        private void btn2_2_Click(object sender, EventArgs e)
        {
            this.btn2_1.BackColor = Color.Transparent;
            this.btn2_2.BackColor = Color.White;
            this.btn2_1.ForeColor = Color.White;
            this.btn2_2.ForeColor = Color.Black;
            CreateMatPriceManage();
            frmMatPriceManage.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmMatPriceManage);
            frmMatPriceManage.Dock = DockStyle.Fill;
            frmMatPriceManage.Show();
        }

        private void btn3_1_Click(object sender, EventArgs e)
        {
            this.btn3_1.BackColor = Color.White;
            this.btn3_2.BackColor = this.btn3_3.BackColor = Color.Transparent;
            this.btn3_1.ForeColor = Color.Black;
            this.btn3_2.ForeColor = this.btn3_3.ForeColor = Color.White;
            CreateProductManage();
            frmProductManage.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmProductManage);
            frmProductManage.Dock = DockStyle.Fill;
            frmProductManage.Show();
        }

        private void btn3_2_Click(object sender, EventArgs e)
        {
            this.btn3_2.BackColor = Color.White;
            this.btn3_1.BackColor = this.btn3_3.BackColor = Color.Transparent;
            this.btn3_2.ForeColor = Color.Black;
            this.btn3_1.ForeColor = this.btn3_3.ForeColor = Color.White;
            CreateBOM();
            frmBOM.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmBOM);
            frmBOM.Dock = DockStyle.Fill;
            frmBOM.Show();
        }
        #endregion
    }
}
