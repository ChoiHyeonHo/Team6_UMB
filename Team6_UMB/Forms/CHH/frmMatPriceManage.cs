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
    public partial class frmMatPriceManage : Team6_UMB.frmBaseList
    {
        List<MatPriceVO> allList;
        MatPriceService service;
        string productID, productName, companyName, sDate, eDate, yn, comment;
        int priceID, companyID, Present;

        public frmMatPriceManage()
        {
            InitializeComponent();
            newBtns.btnBarCode.Visible = newBtns.btnDocument.Visible = newBtns.btnShipment.Visible = newBtns.btnWait.Visible = newBtns.btnSearch.Visible = false;
            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();
            cheView.Checked = true;
        }

        private void periodSearchControl_ChangedPeriod(object sender, EventArgs e)
        {
            if (dgvMatPrice.DataSource != null)
            {
                if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                {
                    string FromDate = periodSearchControl.dtFrom;
                    string ToDate = periodSearchControl.dtTo;

                    List<MatPriceVO> periodList = (from period in allList
                                                     where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(period.price_sdate) && Convert.ToDateTime(period.price_edate) <= Convert.ToDateTime(ToDate)
                                                     select period).ToList();
                    dgvMatPrice.DataSource = periodList;
                }
            }
        }

        private void newBtns_btnDelete_Event(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.msgDelete, "삭제확인 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                service = new MatPriceService();
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

        private void cheView_Click(object sender, EventArgs e)
        {
            if (cheView.Checked)
            {
                service = new MatPriceService();
                allList = service.GetMatInfo();
                dgvMatPrice.DataSource = allList;
            }
            else if (!cheView.Checked)
            {
                service = new MatPriceService();
                allList = service.GetMatNInfo();
                dgvMatPrice.DataSource = allList;
            }
        }

        private void btnWhere_Click(object sender, EventArgs e)
        {
            service = new MatPriceService();
            allList = service.GetWhereInfo(txtProdName.Text, txtCompanyName.Text);
            dgvMatPrice.DataSource = allList;
        }

        private void frmMatPriceManage_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvMatPrice);
            CommonUtil.AddGridTextColumn(dgvMatPrice, "번호", "price_id", 60);                 //0
            CommonUtil.AddGridTextColumn(dgvMatPrice, "품목id", "product_id", 10, false);      //1
            CommonUtil.AddGridTextColumn(dgvMatPrice, "품목명", "product_name", 260);          //2
            CommonUtil.AddGridTextColumn(dgvMatPrice, "거래처id", "company_id", 10, false);    //3
            CommonUtil.AddGridTextColumn(dgvMatPrice, "거래처명", "company_name", 260);        //4
            CommonUtil.AddGridTextColumn(dgvMatPrice, "현재단가", "price_present", 180);       //5
            CommonUtil.AddGridTextColumn(dgvMatPrice, "이전단가", "price_past", 180);          //6
            CommonUtil.AddGridTextColumn(dgvMatPrice, "시작일", "price_sdate", 200);           //7
            CommonUtil.AddGridTextColumn(dgvMatPrice, "종료일", "price_edate", 200);           //8
            CommonUtil.AddGridTextColumn(dgvMatPrice, "사용유무", "price_yn", 120);            //9
            CommonUtil.AddGridTextColumn(dgvMatPrice, "비고", "price_comment", 10, false);     //10

            DGV_Binding();
        }

        private void DGV_Binding()
        {
            service = new MatPriceService();
            allList = service.GetMatInfo();
            dgvMatPrice.DataSource = allList;
        }

        private void dgvMatPrice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            priceID = int.Parse(dgvMatPrice.Rows[e.RowIndex].Cells[0].Value.ToString());
            productID = dgvMatPrice.Rows[e.RowIndex].Cells[1].Value.ToString();
            productName = dgvMatPrice.Rows[e.RowIndex].Cells[2].Value.ToString();
            companyID = int.Parse(dgvMatPrice.Rows[e.RowIndex].Cells[3].Value.ToString());
            companyName = dgvMatPrice.Rows[e.RowIndex].Cells[4].Value.ToString();
            Present = int.Parse(dgvMatPrice.Rows[e.RowIndex].Cells[5].Value.ToString());
            sDate = dgvMatPrice.Rows[e.RowIndex].Cells[7].Value.ToString();
            eDate = dgvMatPrice.Rows[e.RowIndex].Cells[8].Value.ToString();
            yn = dgvMatPrice.Rows[e.RowIndex].Cells[9].Value.ToString();
            comment = dgvMatPrice.Rows[e.RowIndex].Cells[10].Value.ToString();
        }
        private void newBtns_btnCreate_Event(object sender, EventArgs e)
        {
            string headerName = "자재단가관리 등록";
            frmSalesPricePopUp pop = new frmSalesPricePopUp(headerName);
            pop.ShowDialog();
        }
        private void newBtns_btnUpdate_Event(object sender, EventArgs e)
        {
            string headerName = "자재단가관리 수정";
            frmSalesPricePopUp pop = new frmSalesPricePopUp(headerName, priceID, productID, productName, companyID, companyName, Present, sDate, eDate, yn, comment);
            pop.ShowDialog();
        }
        private void newBtns_btnRefresh_Event(object sender, EventArgs e)
        {
            DGV_Binding();
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
                string sResult = ExcelExportImport.ExportToDataGridView<MatPriceVO>((List<MatPriceVO>)dgvMatPrice.DataSource, "");
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
