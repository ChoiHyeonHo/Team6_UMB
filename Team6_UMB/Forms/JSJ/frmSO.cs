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
    public partial class frmSO : Team6_UMB.BaseForm.frmList
    {
        List<SOListVO> list;
        int so_id;

        public frmSO()
        {
            InitializeComponent();
        }

        private void frmSO_Load(object sender, EventArgs e)
        {
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnSearch.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnWait.Visible = false;

            CommonUtil.SetInitGridView(dgvSO);
            CommonUtil.AddGridTextColumn(dgvSO, "수주번호", "so_id", 200);
            CommonUtil.AddGridTextColumn(dgvSO, "업체명", "company_name", 300);
            CommonUtil.AddGridTextColumn(dgvSO, "품목명", "product_name", 300);
            CommonUtil.AddGridTextColumn(dgvSO, "납기일", "so_edate", 250);
            CommonUtil.AddGridTextColumn(dgvSO, "주문수량", "so_ocount", 250);
            CommonUtil.AddGridTextColumn(dgvSO, "담당자", "so_rep", 250);

            SOList();
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            frmSOPopUP frm = new frmSOPopUP();
            frm.ShowDialog();
            SOList();
        }

        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {
            string msg = Properties.Resources.msgDelete;
            SOService service = new SOService();            
            if(MessageBox.Show(msg, "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(service.DeleteSO(so_id) != 0)
                {
                    MessageBox.Show("삭제완료");
                    SOList();
                }
            }
        }

        private void newBtns1_btnExcel_Event(object sender, EventArgs e)
        {

        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            SOList();
        }

        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            frmSOPopUP frm = new frmSOPopUP();
            frm.ShowDialog();
            SOList();            
        }

        public void SOList()
        {
            SOService service = new SOService();
            list = service.SOList();
            dgvSO.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSO(list, txtCompany.Text);
        }

        public List<SOListVO> SearchSO(List<SOListVO> SearchList, string company_name)
        {
            var list = (from item in SearchList
                        where item.company_name.Contains(company_name)
                        && Convert.ToDateTime(periodSearchControl.dtFrom) <= Convert.ToDateTime(item.so_edate) && Convert.ToDateTime(periodSearchControl.dtTo) >= Convert.ToDateTime(item.so_edate)
                        select item).ToList();
            return list;
        }

        private void dgvSO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            so_id = Convert.ToInt32(dgvSO[0, e.RowIndex].Value);
        }
    }
}
