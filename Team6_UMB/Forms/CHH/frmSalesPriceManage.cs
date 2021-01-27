using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using Team6_UMB.Util;
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmSalesPriceManage : frmBaseList
    {
        List<SalesPriceVO> allList;
        string productID, productName, companyName, sDate, eDate, yn, comment;
        int priceID, companyID, Present, Past;

        SalesPriceService service;

        public frmSalesPriceManage()
        {
            InitializeComponent();
            newBtns.btnBarCode.Visible = newBtns.btnDocument.Visible = newBtns.btnShipment.Visible = newBtns.btnWait.Visible = newBtns.btnSearch.Visible = false;
            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();
            cheView.Checked = true;
        }
        private void periodSearchControl_ChangedPeriod(object sender, EventArgs e)
        {
            if (dgvPrice.DataSource != null)
            {
                if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                {
                    string FromDate = periodSearchControl.dtFrom;
                    string ToDate = periodSearchControl.dtTo;

                    List<SalesPriceVO> periodList = (from period in allList
                                                     where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(period.price_sdate) && Convert.ToDateTime(period.price_edate) <= Convert.ToDateTime(ToDate)
                                                     select period).ToList();
                    dgvPrice.DataSource = periodList;
                }
            }
        }

        private void frmSalesPriceManage_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvPrice);
            CommonUtil.AddGridTextColumn(dgvPrice, "번호", "price_id", 60);                 //0
            CommonUtil.AddGridTextColumn(dgvPrice, "품목id", "product_id", 10, false);      //1
            CommonUtil.AddGridTextColumn(dgvPrice, "품목명", "product_name", 260);          //2
            CommonUtil.AddGridTextColumn(dgvPrice, "거래처id", "company_id", 10, false);    //3
            CommonUtil.AddGridTextColumn(dgvPrice, "거래처명", "company_name", 260);        //4
            CommonUtil.AddGridTextColumn(dgvPrice, "현재단가", "price_present", 180);       //5
            CommonUtil.AddGridTextColumn(dgvPrice, "이전단가", "price_past", 180);          //6
            CommonUtil.AddGridTextColumn(dgvPrice, "시작일", "price_sdate", 200);           //7
            CommonUtil.AddGridTextColumn(dgvPrice, "종료일", "price_edate", 200);           //8
            CommonUtil.AddGridTextColumn(dgvPrice, "사용유무", "price_yn", 120);            //9
            CommonUtil.AddGridTextColumn(dgvPrice, "비고", "price_comment", 10, false);     //10

            DGV_Binding();
        }

        public void DGV_Binding()
        {
            service = new SalesPriceService();
            allList = service.GetSalesPriceNInfo();
            dgvPrice.DataSource = allList;
        }

        private void cheView_Click(object sender, EventArgs e)
        {
            if (cheView.Checked)
            {
                service = new SalesPriceService();
                allList = service.GetSalesPriceNInfo();
                dgvPrice.DataSource = allList;
            }
            else if (!cheView.Checked)
            {
                service = new SalesPriceService();
                allList = service.GetSalesPriceYInfo();
                dgvPrice.DataSource = allList;
            }
        }

        private void btnWhere_Click(object sender, EventArgs e)
        {
            service = new SalesPriceService();
            allList = service.GetWhereInfo(txtProdName.Text, txtCompanyName.Text);
            dgvPrice.DataSource = allList;
        }

        private void newBtns_btnRefresh_Event(object sender, EventArgs e)
        {
            DGV_Binding();
        }

        private void dgvPrice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            priceID = int.Parse(dgvPrice.Rows[e.RowIndex].Cells[0].Value.ToString());
            productID = dgvPrice.Rows[e.RowIndex].Cells[1].Value.ToString();
            productName = dgvPrice.Rows[e.RowIndex].Cells[2].Value.ToString();
            companyID = int.Parse(dgvPrice.Rows[e.RowIndex].Cells[3].Value.ToString());
            companyName = dgvPrice.Rows[e.RowIndex].Cells[4].Value.ToString();
            Present = int.Parse(dgvPrice.Rows[e.RowIndex].Cells[5].Value.ToString());
            Past = int.Parse(dgvPrice.Rows[e.RowIndex].Cells[6].Value.ToString());
            sDate = dgvPrice.Rows[e.RowIndex].Cells[7].Value.ToString();
            eDate = dgvPrice.Rows[e.RowIndex].Cells[8].Value.ToString();
            yn = dgvPrice.Rows[e.RowIndex].Cells[9].Value.ToString();
            comment = dgvPrice.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void newBtns_btnCreate_Event(object sender, EventArgs e)
        {
            string headerName = "영업단가관리 등록";
            frmSalesPricePopUp pop = new frmSalesPricePopUp(headerName);
            pop.ShowDialog();
        }

        private void newBtns_btnUpdate_Event(object sender, EventArgs e)
        {

            string headerName = "영업단가관리 수정";
            frmSalesPricePopUp pop = new frmSalesPricePopUp(headerName, priceID, productID, productName, companyID, companyName, Present, sDate, eDate, yn, comment);
            pop.ShowDialog();
        }
        private void newBtns_btnDelete_Event(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.msgDelete, "삭제확인 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                service = new SalesPriceService();
                bool result = service.Delete(priceID);

                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGV_Binding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);

            }
        }
        private void newBtns_btnExcel_Event(object sender, EventArgs e)
        {
            try
            {
                frmLoading frm = new frmLoading(ExportCustomerList);
                frm.ShowDialog(this);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void ExportCustomerList()
        {
            try
            {
                string sResult = ExcelExportImport.ExportToDataGridView<SalesPriceVO>((List<SalesPriceVO>)dgvPrice.DataSource, "");
                if (sResult.Length > 0)
                {
                    MessageBox.Show(sResult);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
