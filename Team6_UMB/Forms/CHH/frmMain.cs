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
using Team6_UMB.Forms.CHH;
using Team6_UMB.Forms.ASB;
using Team6_UMB.Forms.JSJ;
using Team6_UMB.Forms.BMN;
using Team6_UMB.Service;
using System.Diagnostics;

namespace Team6_UMB
{
    public partial class frmMain : Form
    {
        #region 싱글톤 - 스태틱 선언
        public static frmFirstPage frmFirstPage;
        public static frmSalesPriceManage frmSalesPriceManage;
        public static frmMatPriceManage frmMatPriceManage;
        public static frmProductManage frmProductManage;
        public static frmBOM frmBOM;
        public static frmImportInspection frmImportInspection;
        public static frmProdInspection frmProdInspection;
        public static frmCheckHistory frmCheckHistory;
        public static frmPDStock frmPDStock;
        public static frmShift frmShift;
        public static frmBOR frmBOR;
        public static frmCheckList frmCheckList;
        public static frmCompany frmCompany;
        public static frmDepartment frmDepartment;
        public static frmMachine frmMachine;
        public static frmUser frmUser;
        public static frmWarehouse frmWarehouse;
        public static frmIncommingStatus frmIcStatus;
        public static frmIncommingWait frmIcWait;
        public static frmOrderStatus frmOStatus;
        public static frmSalesStatus frmSales;
        public static frmShipment frmShipment;
        public static frmSO frmSO;
        public static frmperformanceStatus frmPS; //생산실적 현황
        
        public static frmWorkOrderRegi frmWOR; //작업지시 등록
        
        public static frmdefectiveRegi frmDR; //불량관리 등록/수정
        public static frmdefectiveStatus frmDS; //불량처리현황
        public static frmAuthority frmAuthority; //권한관리
        #endregion
        public frmMain()
        {
            InitializeComponent();
            pnlMain1.Dock = pnlMain2.Dock = pnlMain3.Dock = pnlMain4.Dock = pnlMain5.Dock = pnlMain6.Dock = pnlMain7.Dock = DockStyle.Fill;
            pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = pnlMain7.Visible = false;
        }

        #region 싱글톤 - 메서드를 통한 폼 유무 체크
        #region CHH 싱글톤
        public static frmFirstPage CreateFirstPage()
        {
            if (frmFirstPage == null)
                frmFirstPage = new frmFirstPage();
            return frmFirstPage;
        }

        public static frmSalesPriceManage CreateSalesPriceManage()
        {
            if (frmSalesPriceManage == null)
                frmSalesPriceManage = new frmSalesPriceManage();
            return frmSalesPriceManage;
        }
        public static frmMatPriceManage CreateMatPriceManage()
        {
            if (frmMatPriceManage == null)
                frmMatPriceManage = new frmMatPriceManage();
            return frmMatPriceManage;
        }
        public static frmProductManage CreateProductManage()
        {
            if (frmProductManage == null)
                frmProductManage = new frmProductManage();
            return frmProductManage;
        }
        public static frmBOM CreateBOM()
        {
            if (frmBOM == null)
                frmBOM = new frmBOM();
            return frmBOM;
        }
        public static frmImportInspection CreateImpIns()
        {
            if (frmImportInspection == null)
                frmImportInspection = new frmImportInspection();
            return frmImportInspection;
        }
        public static frmProdInspection CreateProdIns()
        {
            if (frmProdInspection == null)
                frmProdInspection = new frmProdInspection();
            return frmProdInspection;
        }
        public static frmCheckHistory CreateCkHis()
        {
            if (frmCheckHistory == null)
                frmCheckHistory = new frmCheckHistory();
            return frmCheckHistory;
        }
        public static frmPDStock CreatePDS()
        {
            if (frmPDStock == null)
                frmPDStock = new frmPDStock();
            return frmPDStock;
        }
        #endregion

        #region ASB 싱글톤
        public static frmShift CreateShift()
        {
            if (frmShift == null)
                frmShift = new frmShift();
            return frmShift;
        }
        public static frmMachine CreateMachine()
        {
            if (frmMachine == null)
                frmMachine = new frmMachine();
            return frmMachine;
        }
        public static frmCompany CreateCompany()
        {
            if (frmCompany == null)
                frmCompany = new frmCompany();
            return frmCompany;
        }
        public static frmBOR CreateBOR()
        {
            if (frmBOR == null)
                frmBOR = new frmBOR();
            return frmBOR;
        }
        public static frmUser CreateUser()
        {
            if (frmUser == null)
                frmUser = new frmUser();
            return frmUser;
        }
        public static frmDepartment CreateDepartment()
        {
            if (frmDepartment == null)
                frmDepartment = new frmDepartment();
            return frmDepartment;
        }
        public static frmWarehouse CreateWarehouse()
        {
            if (frmWarehouse == null)
                frmWarehouse = new frmWarehouse();
            return frmWarehouse;
        }
        public static frmCheckList CreateCheckList()
        {
            if (frmCheckList == null)
                frmCheckList = new frmCheckList();
            return frmCheckList;
        }
        #endregion

        #region JSJ 싱글톤
        public static frmOrderStatus CreateOrderStatus()
        {
            if (frmOStatus == null)
                frmOStatus = new frmOrderStatus();
            return frmOStatus;
        }
        public static frmShipment CreateShipment()
        {
            if (frmShipment == null)
                frmShipment = new frmShipment();
            return frmShipment;
        }
        public static frmSO CreateSO()
        {
            if (frmSO == null)
                frmSO = new frmSO();
            return frmSO;
        }
        public static frmIncommingStatus CreateIcStatus()
        {
            if (frmIcStatus == null)
                frmIcStatus = new frmIncommingStatus();
            return frmIcStatus;
        }
        public static frmIncommingWait CreateIcWait()
        {
            if (frmIcWait == null)
                frmIcWait = new frmIncommingWait();
            return frmIcWait;
        }
        public static frmSalesStatus CreateSales()
        {
            if (frmSales == null)
                frmSales = new frmSalesStatus();
            return frmSales;
        }
        public static frmAuthority CreateAuthority()
        {
            if (frmAuthority == null)
                frmAuthority = new frmAuthority();
            return frmAuthority;
        }
        #endregion

        #region BMN 싱글톤
        public static frmperformanceStatus CreatePS()
        {
            if (frmPS == null)
                frmPS = new frmperformanceStatus();
            return frmPS;
        }
        
        public static frmWorkOrderRegi CreateWOR()
        {
            if (frmWOR == null)
                frmWOR = new frmWorkOrderRegi();
            return frmWOR;
        }
        
        public static frmdefectiveRegi CreateDR()
        {
            if (frmDR == null)
                frmDR = new frmdefectiveRegi();
            return frmDR;
        }
        public static frmdefectiveStatus CreateDS()
        {
            if (frmDS == null)
                frmDS = new frmdefectiveStatus();
            return frmDS;
        }
        #endregion

        #endregion

        #region 상단 메뉴 클릭
        private void btnMain1_Click(object sender, EventArgs e)
        {
            PanelControl(1);
            btn1_1.PerformClick();
        }

        private void btnMain2_Click(object sender, EventArgs e)
        {
            PanelControl(2);
            btn2_1.PerformClick();
        }

        private void btnMain3_Click(object sender, EventArgs e)
        {
            PanelControl(3);
            btn3_1.PerformClick();
        }

        private void btnMain4_Click(object sender, EventArgs e)
        {
            PanelControl(4);
            btn4_1.PerformClick();
        }

        private void btnMain5_Click(object sender, EventArgs e)
        {
            PanelControl(5);
            btn5_2.PerformClick();
        }

        private void btnMain6_Click(object sender, EventArgs e)
        {
            PanelControl(6);
            btn6_1.PerformClick();
        }
        private void btnMain7_Click(object sender, EventArgs e)
        {
            PanelControl(7);
            btn7_1.PerformClick();
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

        #region ASB 폼
        private void btn1_1_Click(object sender, EventArgs e)
        {
            this.btn1_1.BackColor = Color.White;
            this.btn1_1.ForeColor = Color.Black;
            this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = this.btn1_8.BackColor = Color.Transparent;
            this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = this.btn1_8.ForeColor = Color.White;
            CreateShift();
            frmShift.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmShift);
            frmShift.Dock = DockStyle.Fill;
            frmShift.Show();
        }
        private void btn1_2_Click(object sender, EventArgs e)
        {
            this.btn1_2.BackColor = Color.White;
            this.btn1_2.ForeColor = Color.Black;
            this.btn1_1.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = this.btn1_8.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = this.btn1_8.ForeColor = Color.White;
            CreateMachine();
            frmMachine.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmMachine);
            frmMachine.Dock = DockStyle.Fill;
            frmMachine.Show();
        }
        private void btn1_3_Click(object sender, EventArgs e)
        {
            this.btn1_3.BackColor = Color.White;
            this.btn1_3.ForeColor = Color.Black;
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = this.btn1_8.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = this.btn1_8.ForeColor = Color.White;
            CreateCompany();
            frmCompany.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmCompany);
            frmCompany.Dock = DockStyle.Fill;
            frmCompany.Show();
        }
        private void btn1_4_Click(object sender, EventArgs e)
        {
            this.btn1_4.BackColor = Color.White;
            this.btn1_4.ForeColor = Color.Black;
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = this.btn1_8.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = this.btn1_8.ForeColor = Color.White;
            CreateBOR();
            frmBOR.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmBOR);
            frmBOR.Dock = DockStyle.Fill;
            frmBOR.Show();
        }
        private void btn1_5_Click(object sender, EventArgs e)
        {
            this.btn1_5.BackColor = Color.White;
            this.btn1_5.ForeColor = Color.Black;
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = this.btn1_8.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = this.btn1_8.ForeColor = Color.White;
            CreateUser();
            frmUser.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmUser);
            frmUser.Dock = DockStyle.Fill;
            frmUser.Show();
        }
        private void btn1_6_Click(object sender, EventArgs e)
        {
            this.btn1_6.BackColor = Color.White;
            this.btn1_6.ForeColor = Color.Black;
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_7.BackColor = this.btn1_8.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_7.ForeColor = this.btn1_8.ForeColor = Color.White;
            CreateDepartment();
            frmDepartment.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmDepartment);
            frmDepartment.Dock = DockStyle.Fill;
            frmDepartment.Show();
        }
        private void btn1_7_Click(object sender, EventArgs e)
        {
            this.btn1_7.BackColor = Color.White;
            this.btn1_7.ForeColor = Color.Black;
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_8.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_8.ForeColor = Color.White;
            CreateWarehouse();
            frmWarehouse.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmWarehouse);
            frmWarehouse.Dock = DockStyle.Fill;
            frmWarehouse.Show();
        }
        private void btn1_8_Click(object sender, EventArgs e)
        {
            this.btn1_8.BackColor = Color.White;
            this.btn1_8.ForeColor = Color.Black;
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = Color.White;
            CreateCheckList();
            frmCheckList.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmCheckList);
            frmCheckList.Dock = DockStyle.Fill;
            frmCheckList.Show();
        }
        #endregion

        #region CHH폼
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CreateFirstPage();
            frmFirstPage.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmFirstPage);
            frmFirstPage.Dock = DockStyle.Fill;
            frmFirstPage.Show();
        }

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
        private void btn3_3_Click(object sender, EventArgs e)
        {
            this.btn3_3.BackColor = Color.White;
            this.btn3_1.BackColor = this.btn3_2.BackColor = Color.Transparent;
            this.btn3_3.ForeColor = Color.Black;
            this.btn3_1.ForeColor = this.btn3_2.ForeColor = Color.White;
            CreatePDS();
            frmPDStock.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmPDStock);
            frmPDStock.Dock = DockStyle.Fill;
            frmPDStock.Show();
        }
        private void btn4_1_Click(object sender, EventArgs e)
        {
            this.btn4_1.BackColor = Color.White;
            this.btn4_2.BackColor = this.btn4_3.BackColor = Color.Transparent;
            this.btn4_1.ForeColor = Color.Black;
            this.btn4_2.ForeColor = this.btn4_3.ForeColor = Color.White;
            CreateImpIns();
            frmImportInspection.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmImportInspection);
            frmImportInspection.Dock = DockStyle.Fill;
            frmImportInspection.Show();
        }
        private void btn4_2_Click(object sender, EventArgs e)
        {
            this.btn4_2.BackColor = Color.White;
            this.btn4_1.BackColor = this.btn4_3.BackColor = Color.Transparent;
            this.btn4_2.ForeColor = Color.Black;
            this.btn4_1.ForeColor = this.btn4_3.ForeColor = Color.White;
            CreateProdIns();
            frmProdInspection.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmProdInspection);
            frmProdInspection.Dock = DockStyle.Fill;
            frmProdInspection.Show();
        }
        private void btn4_3_Click(object sender, EventArgs e)
        {
            this.btn4_3.BackColor = Color.White;
            this.btn4_1.BackColor = this.btn4_2.BackColor = Color.Transparent;
            this.btn4_3.ForeColor = Color.Black;
            this.btn4_1.ForeColor = this.btn4_2.ForeColor = Color.White;
            CreateCkHis();
            frmCheckHistory.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmCheckHistory);
            frmCheckHistory.Dock = DockStyle.Fill;
            frmCheckHistory.Show();
        }
        #endregion

        #region JSJ 폼
        private void btn5_2_Click(object sender, EventArgs e)
        {
            this.btn5_2.BackColor = Color.White;
            this.btn5_2.ForeColor = Color.Black;
            this.btn5_3.BackColor = this.btn5_4.BackColor = this.btn5_5.BackColor = this.btn5_6.BackColor = this.btn5_7.BackColor = Color.Transparent;
            this.btn5_3.ForeColor = this.btn5_4.ForeColor = this.btn5_5.ForeColor = this.btn5_6.ForeColor = this.btn5_7.ForeColor = Color.White;
            CreateOrderStatus();
            frmOStatus.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmOStatus);
            frmOStatus.Dock = DockStyle.Fill;
            frmOStatus.Show();
        }
        private void btn5_3_Click(object sender, EventArgs e)
        {
            this.btn5_3.BackColor = Color.White;
            this.btn5_3.ForeColor = Color.Black;
            this.btn5_2.BackColor = this.btn5_4.BackColor = this.btn5_5.BackColor = this.btn5_6.BackColor = this.btn5_7.BackColor = Color.Transparent;
            this.btn5_2.ForeColor = this.btn5_4.ForeColor = this.btn5_5.ForeColor = this.btn5_6.ForeColor = this.btn5_7.ForeColor = Color.White;
            CreateShipment();
            frmShipment.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmShipment);
            frmShipment.Dock = DockStyle.Fill;
            frmShipment.Show();
        }
        private void btn5_4_Click(object sender, EventArgs e)
        {
            this.btn5_4.BackColor = Color.White;
            this.btn5_4.ForeColor = Color.Black;
            this.btn5_2.BackColor = this.btn5_3.BackColor = this.btn5_5.BackColor = this.btn5_6.BackColor = this.btn5_7.BackColor = Color.Transparent;
            this.btn5_2.ForeColor = this.btn5_3.ForeColor = this.btn5_5.ForeColor = this.btn5_6.ForeColor = this.btn5_7.ForeColor = Color.White;
            CreateSO();
            frmSO.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmSO);
            frmSO.Dock = DockStyle.Fill;
            frmSO.Show();
        }
        private void btn5_5_Click(object sender, EventArgs e)
        {
            this.btn5_5.BackColor = Color.White;
            this.btn5_5.ForeColor = Color.Black;
            this.btn5_2.BackColor = this.btn5_3.BackColor = this.btn5_4.BackColor = this.btn5_6.BackColor = this.btn5_7.BackColor = Color.Transparent;
            this.btn5_2.ForeColor = this.btn5_3.ForeColor = this.btn5_4.ForeColor = this.btn5_6.ForeColor = this.btn5_7.ForeColor = Color.White;
            CreateIcStatus();
            frmIcStatus.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmIcStatus);
            frmIcStatus.Dock = DockStyle.Fill;
            frmIcStatus.Show();
        }
        private void btn5_6_Click(object sender, EventArgs e)
        {
            this.btn5_6.BackColor = Color.White;
            this.btn5_6.ForeColor = Color.Black;
            this.btn5_2.BackColor = this.btn5_3.BackColor = this.btn5_4.BackColor = this.btn5_5.BackColor = this.btn5_7.BackColor = Color.Transparent;
            this.btn5_2.ForeColor = this.btn5_3.ForeColor = this.btn5_4.ForeColor = this.btn5_5.ForeColor = this.btn5_7.ForeColor = Color.White;
            CreateIcWait();
            frmIcWait.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmIcWait);
            frmIcWait.Dock = DockStyle.Fill;
            frmIcWait.Show();
        }
        private void btn5_7_Click(object sender, EventArgs e)
        {
            this.btn5_7.BackColor = Color.White;
            this.btn5_7.ForeColor = Color.Black;
            this.btn5_2.BackColor = this.btn5_3.BackColor = this.btn5_4.BackColor = this.btn5_5.BackColor = this.btn5_6.BackColor = Color.Transparent;
            this.btn5_2.ForeColor = this.btn5_3.ForeColor = this.btn5_4.ForeColor = this.btn5_5.ForeColor = this.btn5_6.ForeColor = Color.White;
            CreateSales();
            frmSales.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmSales);
            frmSales.Dock = DockStyle.Fill;
            frmSales.Show();
        }
        private void btn7_1_Click(object sender, EventArgs e)
        {
            this.btn7_1.BackColor = Color.White;
            this.btn7_1.ForeColor = Color.Black;
            CreateAuthority();
            frmAuthority.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmAuthority);
            frmAuthority.Dock = DockStyle.Fill;
            frmAuthority.Show();
        }
        #endregion

        #region BMN 폼
        private void btn6_1_Click(object sender, EventArgs e)
        {
            this.btn6_1.BackColor = Color.White;
            this.btn6_1.ForeColor = Color.Black;
            this.btn6_3.BackColor = this.btn6_5.BackColor = this.btn6_6.BackColor = Color.Transparent;
            this.btn6_3.ForeColor = this.btn6_5.ForeColor = this.btn6_6.ForeColor = Color.White;
            CreatePS();
            frmPS.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmPS);
            frmPS.Dock = DockStyle.Fill;
            frmPS.Show();
        }
        
        private void btn6_3_Click(object sender, EventArgs e)
        {
            this.btn6_3.BackColor = Color.White;
            this.btn6_3.ForeColor = Color.Black;
            this.btn6_1.BackColor = this.btn6_5.BackColor = this.btn6_6.BackColor = Color.Transparent;
            this.btn6_1.ForeColor = this.btn6_5.ForeColor = this.btn6_6.ForeColor = Color.White;
            CreateWOR();
            frmWOR.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmWOR);
            frmWOR.Dock = DockStyle.Fill;
            frmWOR.Show();
        }
        private void btn6_5_Click(object sender, EventArgs e)
        {
            this.btn6_5.BackColor = Color.White;
            this.btn6_5.ForeColor = Color.Black;
            this.btn6_1.BackColor = this.btn6_3.BackColor = this.btn6_6.BackColor = Color.Transparent;
            this.btn6_1.ForeColor = this.btn6_3.ForeColor = this.btn6_6.ForeColor = Color.White;
            CreateDR();
            frmDR.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmDR);
            frmDR.Dock = DockStyle.Fill;
            frmDR.Show();
        }
        private void btn6_6_Click(object sender, EventArgs e)
        {
            this.btn6_6.BackColor = Color.White;
            this.btn6_6.ForeColor = Color.Black;
            this.btn6_1.BackColor = this.btn6_3.BackColor = this.btn6_5.BackColor = Color.Transparent;
            this.btn6_1.ForeColor = this.btn6_3.ForeColor = this.btn6_5.ForeColor = Color.White;
            CreateDS();
            frmDS.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmDS);
            frmDS.Dock = DockStyle.Fill;
            frmDS.Show();
        }
        #endregion

        #endregion

        #region 네비게이션 패널
        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (btnOpenClose.Text == "<<")
            {
                pnlMenu.Size = new Size(40, 789);
                pnlButtons.Visible = false;
                btnUserChange.Location = new Point(0, 75);
                btnHome.Location = new Point(0, 30);
                btnOpenClose.Text = ">>";
            }
            else if(btnOpenClose.Text == ">>")
            {
                pnlMenu.Size = new Size(145, 789);
                pnlButtons.Visible = true;
                btnUserChange.Location = new Point(49, 121);
                btnHome.Location = new Point(95, 121);
                btnOpenClose.Text = "<<";
            }
        }

        private void btnUserChange_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User Change...");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.naver.com/");
        }


        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            CreateFirstPage();
            frmFirstPage.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmFirstPage);
            frmFirstPage.Dock = DockStyle.Fill;
            frmFirstPage.Show();
        }
    }
}
