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

namespace Team6_UMB.Forms.CHH
{
    public partial class frmCheckHistory : Team6_UMB.frmBaseList
    {
        CheckHistoryService service = new CheckHistoryService();
        List<CheckHistoryVO> allList;
        List<GetCheckTypeVO> check;
        string checkType;

        public frmCheckHistory()
        {
            InitializeComponent();
            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();

            newBtns1.btnBarCode.Visible = newBtns1.btnCreate.Visible = newBtns1.btnDelete.Visible = newBtns1.btnDocument.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnUpdate.Visible = newBtns1.btnWait.Visible = false;
        }

        private void frmCheckHistory_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvCheckHistory);
            CommonUtil.AddGridTextColumn(dgvCheckHistory, "이력번호", "ch_id", 160);
            CommonUtil.AddGridTextColumn(dgvCheckHistory, "검사항목", "ch_item", 250);
            CommonUtil.AddGridTextColumn(dgvCheckHistory, "품목코드", "product_id", 160);
            CommonUtil.AddGridTextColumn(dgvCheckHistory, "검사일", "ch_date", 160);
            CommonUtil.AddGridTextColumn(dgvCheckHistory, "검사구분", "ch_type", 160);
            CommonUtil.AddGridTextColumn(dgvCheckHistory, "비고", "ch_comment", 470);
            CommonUtil.AddGridTextColumn(dgvCheckHistory, "제품검사ID", "cl_ship_id", 150);
            CommonUtil.AddGridTextColumn(dgvCheckHistory, "수입검사ID", "cl_inc_id", 150);
            DGVBinding();

            check = service.GetCheckTypeComboBox();
            CommonUtil.CheckHis_CheckTypeBinding(cbCheckType, check);
        }

        private void DGVBinding()
        {
            allList = service.GetCheckHisInfo();
            dgvCheckHistory.DataSource = allList;
        }

        private void periodSearchControl_ChangedPeriod(object sender, EventArgs e)
        {
            if (dgvCheckHistory.DataSource != null)
            {
                if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                {
                    string FromDate = periodSearchControl.dtFrom;
                    string ToDate = periodSearchControl.dtTo;

                    List<CheckHistoryVO> periodList = (from period in allList
                                                     where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(period.ch_date) && Convert.ToDateTime(period.ch_date) <= Convert.ToDateTime(ToDate)
                                                     select period).ToList();
                    dgvCheckHistory.DataSource = periodList;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            checkType = cbCheckType.Text.ToString();
            allList = service.GetCheckHisInfoWhere(checkType);
            dgvCheckHistory.DataSource = allList;

        }

        private void newBtns1_btnExcel_Event(object sender, EventArgs e)
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
                string sResult = ExcelExportImport.ExportToDataGridView<CheckHistoryVO>((List<CheckHistoryVO>)dgvCheckHistory.DataSource, "");
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

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }
    }
}
