using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmWarehouse : Form
    {
        List<WarehouseVO> list;
        WarehouseVO vo = new WarehouseVO();

        public frmWarehouse()
        {
            InitializeComponent();
        }

        private void frmWarehouse_Load(object sender, EventArgs e)
        {
            WarehouseService service = new WarehouseService();
            CommonUtil.ComboBinding(cboType, service.WType(), "창고구분");

            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnExcel.Visible = false;
            newBtns1.btnPrint.Visible = false;
            newBtns1.btnWait.Visible = false;
            newBtns1.btnSearch.Visible = false;

            CommonUtil.SetInitGridView(dgvList);
            CommonUtil.AddGridTextColumn(dgvList, "창고번호", "w_id", 150);
            CommonUtil.AddGridTextColumn(dgvList, "창고명", "w_name", 150);
            CommonUtil.AddGridTextColumn(dgvList, "창고주소", "w_address", 150);
            CommonUtil.AddGridTextColumn(dgvList, "창고구분", "w_type", 150);
            CommonUtil.AddGridTextColumn(dgvList, "사용유무", "w_deleted", 150);
            CommonUtil.AddGridTextColumn(dgvList, "수정자", "w_uadmin", 150);
            CommonUtil.AddGridTextColumn(dgvList, "수정일", "w_udate", 150);

            WarehouseList();
        }

        public void WarehouseList()
        {
            WarehouseService service = new WarehouseService();
            list = service.WarehouseList();
            dgvList.DataSource = list;
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            frmWarehousePopUp frm = new frmWarehousePopUp();
            frm.ShowDialog();
            WarehouseList();
        }

        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {
            if(MessageBox.Show(Properties.Resources.msgDelete, "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WarehouseService service = new WarehouseService();
                service.DeleteWH(vo.w_id);
                WarehouseList();
            }
        }

        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            frmWarehousePopUp frm = new frmWarehousePopUp(vo);
            frm.ShowDialog();
            WarehouseList();
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            WarehouseList();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                vo.w_id = Convert.ToInt32(dgvList[0, e.RowIndex].Value);
                vo.w_name = dgvList[1, e.RowIndex].Value.ToString();
                vo.w_address = dgvList[2, e.RowIndex].Value.ToString();
                vo.w_type = dgvList[3, e.RowIndex].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = SearchWH();
        }

        public List<WarehouseVO> SearchWH()
        {
            var SearchList = (from item in list
                              where item.w_name.Contains(txtName.Text) && item.w_type.Contains(cboType.Text)                             
                              select item).ToList();
            return SearchList;
        }
    }
}
