using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms.JSJ
{
    public partial class frmIncommingStatus : Team6_UMB.BaseForm.frmList
    {
        List<IncommingStatusVO> list = new List<IncommingStatusVO>();
        string product_name = null;

        public frmIncommingStatus()
        {
            InitializeComponent();
        }

        private void frmIncommingStatus_Load(object sender, EventArgs e)
        {
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnCreate.Visible = false;
            newBtns1.btnDelete.Visible = false;
            newBtns1.btnExcel.Visible = false;
            newBtns1.btnPrint.Visible = false;
            newBtns1.btnUpdate.Visible = false;
            newBtns1.btnWait.Visible = false;

            CommonUtil.SetInitGridView(dgvIncomming);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고번호", "incomming_ID", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고상태", "incomming_state", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고일", "incomming_date", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "담당자", "incomming_rep", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "업체명", "company_name", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "품목명", "product_name", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고수량", "incomming_count", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "검사결과", "orderexam_result", 200);

            Incomming();
        }

        public void Incomming()
        {
            IncommingService service = new IncommingService();
            list = service.IncommingStatus();
            dgvIncomming.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvIncomming.DataSource = SearchIncomming();
        }

        public List<IncommingStatusVO> SearchIncomming()
        {
            var SearchList = (from item in list
                        where item.company_name.Contains(txtCompany.Text) && item.product_name.Contains(txtProduct.Text)
                        && Convert.ToDateTime(periodSearchControl.dtFrom) <= Convert.ToDateTime(item.incomming_date) && Convert.ToDateTime(periodSearchControl.dtTo) >= Convert.ToDateTime(item.incomming_date)
                        select item).ToList();
            return SearchList;
        }

        private void newBtns1_btnSearch_Event(object sender, EventArgs e)
        {
            if (product_name == null)
            {
                MessageBox.Show("항목을 선택해주십시오.");
            }
            else
            {
                frmIncommingHistory frm = new frmIncommingHistory(product_name);
                frm.Show();
            }
        }

        private void dgvIncomming_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            product_name = dgvIncomming[5, e.RowIndex].Value.ToString();
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            Incomming();
        }
    }
}
