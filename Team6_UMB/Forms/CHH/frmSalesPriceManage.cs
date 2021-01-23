using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmSalesPriceManage : frmBaseList
    {
        List<SalesPriceVO> allList;
        public frmSalesPriceManage()
        {
            InitializeComponent();
            newBtns.btnBarCode.Visible = newBtns.btnDocument.Visible = newBtns.btnShipment.Visible = newBtns.btnWait.Visible = newBtns.btnSearch.Visible = false;
            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();
        }

        private void frmSalesPriceManage_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvPrice);
            CommonUtil.AddGridTextColumn(dgvPrice, "번호", "price_id", 60);
            CommonUtil.AddGridTextColumn(dgvPrice, "품목명", "product_name", 260);
            CommonUtil.AddGridTextColumn(dgvPrice, "거래처명", "company_name", 260);
            CommonUtil.AddGridTextColumn(dgvPrice, "현재단가", "price_present", 180);
            CommonUtil.AddGridTextColumn(dgvPrice, "이전단가", "price_past", 180);
            CommonUtil.AddGridTextColumn(dgvPrice, "시작일", "price_sdate", 200);
            CommonUtil.AddGridTextColumn(dgvPrice, "종료일", "price_edate", 200);
            CommonUtil.AddGridTextColumn(dgvPrice, "사용유무", "price_yn", 120);

            DGV_Binding();
        }

        public void DGV_Binding()
        {
            SalesPriceService service = new SalesPriceService();
            allList = service.GetRegistOrderInfo();
            dgvPrice.DataSource = allList;
        }

        private void newBtns_btnRefresh_Event(object sender, EventArgs e)
        {
            DGV_Binding();
        }

        private void newBtns_btnCreate_Event(object sender, EventArgs e)
        {
            string headerName = "단가관리 등록";
            frmSalesPricePopUp pop = new frmSalesPricePopUp(headerName);
            pop.ShowDialog();
        }

        private void newBtns_btnUpdate_Event(object sender, EventArgs e)
        {
            string headerName = "단가관리 수정";
            frmSalesPricePopUp pop = new frmSalesPricePopUp(headerName);
            pop.ShowDialog();
        }
    }
}
