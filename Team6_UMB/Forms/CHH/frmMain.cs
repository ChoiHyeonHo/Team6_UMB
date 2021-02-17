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
using UMB_VO;

namespace Team6_UMB
{
    public partial class frmMain : Form
    {
        //권한 부여된 메뉴 목록
        List<string> MenuList = new List<string>();

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

        public static frmSalesPriceManage CreateSalesPriceManage(bool Authority)
        {
            if (frmSalesPriceManage == null)
                frmSalesPriceManage = new frmSalesPriceManage(Authority);
            return frmSalesPriceManage;
        }
        public static frmMatPriceManage CreateMatPriceManage(bool Authority)
        {
            if (frmMatPriceManage == null)
                frmMatPriceManage = new frmMatPriceManage(Authority);
            return frmMatPriceManage;
        }
        public static frmProductManage CreateProductManage(bool Authority)
        {
            if (frmProductManage == null)
                frmProductManage = new frmProductManage(Authority);
            return frmProductManage;
        }
        public static frmBOM CreateBOM(bool Authority)
        {
            if (frmBOM == null)
                frmBOM = new frmBOM(Authority);
            return frmBOM;
        }
        public static frmImportInspection CreateImpIns(bool Authority)
        {
            if (frmImportInspection == null)
                frmImportInspection = new frmImportInspection(Authority);
            return frmImportInspection;
        }
        public static frmProdInspection CreateProdIns(bool Authority)
        {
            if (frmProdInspection == null)
                frmProdInspection = new frmProdInspection(Authority);
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
        public static frmShift CreateShift(bool Authority)
        {
            if (frmShift == null)
            {
                frmShift = new frmShift(Authority);
            }
            return frmShift;
        }
        public static frmMachine CreateMachine(bool Authority)
        {
            if (frmMachine == null)
                frmMachine = new frmMachine(Authority);
            return frmMachine;
        }
        public static frmCompany CreateCompany(bool Authority)
        {
            if (frmCompany == null)
                frmCompany = new frmCompany(Authority);
            return frmCompany;
        }
        public static frmBOR CreateBOR(bool Authority)
        {
            if (frmBOR == null)
                frmBOR = new frmBOR(Authority);
            return frmBOR;
        }
        public static frmUser CreateUser()
        {
            if (frmUser == null)
                frmUser = new frmUser();
            return frmUser;
        }
        public static frmDepartment CreateDepartment(bool Authority)
        {
            if (frmDepartment == null)
                frmDepartment = new frmDepartment(Authority);
            return frmDepartment;
        }
        public static frmWarehouse CreateWarehouse(bool Authority)
        {
            if (frmWarehouse == null)
                frmWarehouse = new frmWarehouse(Authority);
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
        public static frmOrderStatus CreateOrderStatus(bool Authority)
        {
            if (frmOStatus == null)
                frmOStatus = new frmOrderStatus(Authority);
            return frmOStatus;
        }
        public static frmShipment CreateShipment(bool Authority)
        {
            if (frmShipment == null)
                frmShipment = new frmShipment(Authority);
            return frmShipment;
        }
        public static frmSO CreateSO(bool Authority)
        {
            if (frmSO == null)
                frmSO = new frmSO(Authority);
            return frmSO;
        }
        public static frmIncommingStatus CreateIcStatus()
        {
            if (frmIcStatus == null)
                frmIcStatus = new frmIncommingStatus();
            return frmIcStatus;
        }
        public static frmIncommingWait CreateIcWait(bool Authority)
        {
            if (frmIcWait == null)
                frmIcWait = new frmIncommingWait(Authority);
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
                    pnlMain1.Visible = pnlMain2.Visible = pnlMain3.Visible = pnlMain4.Visible = pnlMain5.Visible = pnlMain6.Visible = false;
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
            //this.btn1_1.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            this.btn1_1.BackColor = Color.White;
            this.btn1_1.ForeColor = Color.Black;
            this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = Color.Transparent;
            this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = Color.White;
            if (MenuList.Contains("Shift 기준정보"))
            {
                CreateShift(true);
            }
            else
            {
                CreateShift(false);
            }
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
            this.btn1_1.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = Color.White;
            if (MenuList.Contains("설비관리"))
            {
                CreateMachine(true);
            }
            else
            {
                CreateMachine(false);
            }
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
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = Color.White;
            if (MenuList.Contains("업체관리"))
            {
                CreateCompany(true);
            }
            else
            {
                CreateCompany(false);
            }
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
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = Color.White;
            if (MenuList.Contains("BOR"))
            {
                CreateBOR(true);
            }
            else
            {
                CreateBOR(false);
            }
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
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_6.BackColor = this.btn1_7.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_6.ForeColor = this.btn1_7.ForeColor = Color.White;
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
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_7.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_7.ForeColor = Color.White;
            if (MenuList.Contains("부서관리"))
            {
                CreateDepartment(true);
            }
            else
            {
                CreateDepartment(false);
            }
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
            this.btn1_1.BackColor = this.btn1_2.BackColor = this.btn1_3.BackColor = this.btn1_4.BackColor = this.btn1_5.BackColor = this.btn1_6.BackColor = Color.Transparent;
            this.btn1_1.ForeColor = this.btn1_2.ForeColor = this.btn1_3.ForeColor = this.btn1_4.ForeColor = this.btn1_5.ForeColor = this.btn1_6.ForeColor = Color.White;
            if (MenuList.Contains("창고관리"))
            {
                CreateWarehouse(true);
            }
            else
            {
                CreateWarehouse(false);
            }
            frmWarehouse.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmWarehouse);
            frmWarehouse.Dock = DockStyle.Fill;
            frmWarehouse.Show();
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
            if (MenuList.Contains("영업단가관리"))
            {
                CreateSalesPriceManage(true);
            }
            else
            {
                CreateSalesPriceManage(false);
            }
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
            if (MenuList.Contains("자재단가관리"))
            {
                CreateMatPriceManage(true);
            }
            else
            {
                CreateMatPriceManage(false);
            }
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
            if (MenuList.Contains("품목관리"))
            {
                CreateProductManage(true);
            }
            else
            {
                CreateProductManage(false);
            }
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
            if (MenuList.Contains("BOM"))
            {
                CreateBOM(true);
            }
            else
            {
                CreateBOM(false);
            }
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
            if (MenuList.Contains("수입검사"))
            {
                CreateImpIns(true);
            }
            else
            {
                CreateImpIns(false);
            }
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
            if (MenuList.Contains("제품검사"))
            {
                CreateProdIns(true);
            }
            else
            {
                CreateProdIns(false);
            }
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
            this.btn5_3.BackColor = this.btn5_4.BackColor = this.btn5_5.BackColor = this.btn5_7.BackColor = Color.Transparent;
            this.btn5_3.ForeColor = this.btn5_4.ForeColor = this.btn5_5.ForeColor = this.btn5_7.ForeColor = Color.White;
            if (MenuList.Contains("발주현황"))
            {
                CreateOrderStatus(true);
            }
            else
            {
                CreateOrderStatus(false);
            }
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
            this.btn5_2.BackColor = this.btn5_4.BackColor = this.btn5_5.BackColor = this.btn5_7.BackColor = Color.Transparent;
            this.btn5_2.ForeColor = this.btn5_4.ForeColor = this.btn5_5.ForeColor = this.btn5_7.ForeColor = Color.White;
            if (MenuList.Contains("출하관리"))
            {
                CreateShipment(true);
            }
            else
            {
                CreateShipment(false);
            }
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
            this.btn5_2.BackColor = this.btn5_3.BackColor = this.btn5_5.BackColor = this.btn5_7.BackColor = Color.Transparent;
            this.btn5_2.ForeColor = this.btn5_3.ForeColor = this.btn5_5.ForeColor = this.btn5_7.ForeColor = Color.White;
            if (MenuList.Contains("수주현황"))
            {
                CreateSO(true);
            }
            else
            {
                CreateSO(false);
            }
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
            this.btn5_2.BackColor = this.btn5_3.BackColor = this.btn5_4.BackColor = this.btn5_7.BackColor = Color.Transparent;
            this.btn5_2.ForeColor = this.btn5_3.ForeColor = this.btn5_4.ForeColor = this.btn5_7.ForeColor = Color.White;
            CreateIcStatus();
            frmIcStatus.TopLevel = false;
            pnlBackPage.Controls.Clear();
            pnlBackPage.Controls.Add(frmIcStatus);
            frmIcStatus.Dock = DockStyle.Fill;
            frmIcStatus.Show();
        }
        private void btn5_7_Click(object sender, EventArgs e)
        {
            this.btn5_7.BackColor = Color.White;
            this.btn5_7.ForeColor = Color.Black;
            this.btn5_2.BackColor = this.btn5_3.BackColor = this.btn5_4.BackColor = this.btn5_5.BackColor = Color.Transparent;
            this.btn5_2.ForeColor = this.btn5_3.ForeColor = this.btn5_4.ForeColor = this.btn5_5.ForeColor = Color.White;
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
            else if (btnOpenClose.Text == ">>")
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
            frmFirstPage = null;
            frmSalesPriceManage = null;
            frmMatPriceManage = null;
            frmProductManage = null;
            frmBOM = null;
            frmImportInspection = null;
            frmProdInspection = null;
            frmCheckHistory = null;
            frmPDStock = null;
            frmShift = null;
            frmBOR = null;
            frmCheckList = null;
            frmCompany = null;
            frmDepartment = null;
            frmMachine = null;
            frmUser = null;
            frmWarehouse = null;
            frmIcStatus = null;
            frmIcWait = null;
            frmOStatus = null;
            frmSales = null;
            frmShipment = null;
            frmSO = null;
            frmPS = null; //생산실적 현황
            frmWOR = null; //작업지시 등록
            frmDR = null; //불량관리 등록/수정
            frmDS = null; //불량처리현황
            frmAuthority = null; //권한관리

            this.Close();
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
            //관리자가 아닌경우 시스템, 사원관리 visible = false;
            if (LoginVO.user.Department != 1)
            {
                btnMain7.Visible = false;
                btn1_5.Visible = false;
            }
            AuthorityService service = new AuthorityService();
            MenuList = service.MenuCheck(LoginVO.user.Department);
        }

        private void btnMain1_MouseUp(object sender, MouseEventArgs e)
        {
        }
    }
}
