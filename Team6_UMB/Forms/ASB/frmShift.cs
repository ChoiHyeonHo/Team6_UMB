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
    public partial class frmShift : Form
    {
        List<ShiftVO> list = new List<ShiftVO>();
        ShiftVO vo = new ShiftVO();

        public frmShift()
        {
            InitializeComponent();
        }

        private void frmShift_Load(object sender, EventArgs e)
        {
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnExcel.Visible = false;
            newBtns1.btnPrint.Visible = false;
            newBtns1.btnWait.Visible = false;
            newBtns1.btnSearch.Visible = false;

            CommonUtil.SetInitGridView(dgvShift);
            CommonUtil.AddGridTextColumn(dgvShift, "shift번호", "shift_id", 80);
            CommonUtil.AddGridTextColumn(dgvShift, "설비번호", "m_id", 80);
            CommonUtil.AddGridTextColumn(dgvShift, "시작시간", "shift_stime", 100);
            CommonUtil.AddGridTextColumn(dgvShift, "완료시간", "shift_etime", 100);
            CommonUtil.AddGridTextColumn(dgvShift, "시작일", "shift_sdate", 120);
            CommonUtil.AddGridTextColumn(dgvShift, "완료일", "shift_edate", 120);
            CommonUtil.AddGridTextColumn(dgvShift, "사용유무", "shift_yn", 80);
            CommonUtil.AddGridTextColumn(dgvShift, "비고", "shift_comment", 150);
            CommonUtil.AddGridTextColumn(dgvShift, "수정자", "shift_uadmin", 100);
            CommonUtil.AddGridTextColumn(dgvShift, "수정일", "shift_udate", 100);
            CommonUtil.AddGridTextColumn(dgvShift, "투입인원", "shift_personnel", 80);
            CommonUtil.AddGridTextColumn(dgvShift, "주말사용", "shift_weekend", 80);
            CommonUtil.AddGridTextColumn(dgvShift, "주/야간", "shift_dns", 80);

            ShiftList();
        }

        public void ShiftList()
        {
            ShiftService service = new ShiftService();
            list = service.ShiftList();
            dgvShift.DataSource = list;
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            frmShiftPopUp frm = new frmShiftPopUp();
            frm.ShowDialog();
            ShiftList();
        }

        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {            
            if (MessageBox.Show(Properties.Resources.msgDelete, "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ShiftService service = new ShiftService();
                service.DeleteShift(vo.shift_id);
                ShiftList();
            }
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            ShiftList();
        }

        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            frmShiftPopUp frm = new frmShiftPopUp(vo);
            frm.ShowDialog();
            ShiftList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchShift();
        }

        public void SearchShift()
        {
            var SearchList = (from item in list
                              where item.shift_dns.Contains(cboDns.Text)
                              && Convert.ToDateTime(periodSearchControl.dtFrom) <= Convert.ToDateTime(item.shift_sdate) && Convert.ToDateTime(periodSearchControl.dtTo) >= Convert.ToDateTime(item.shift_sdate)
                              select item).ToList();
            dgvShift.DataSource = SearchList;
        }

        private void dgvShift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                vo.shift_id = Convert.ToInt32(dgvShift[0, e.RowIndex].Value);
                vo.m_id = Convert.ToInt32(dgvShift[1, e.RowIndex].Value);
                vo.shift_stime = dgvShift[2, e.RowIndex].Value.ToString();
                vo.shift_etime = dgvShift[3, e.RowIndex].Value.ToString();
                vo.shift_sdate = dgvShift[4, e.RowIndex].Value.ToString();
                vo.shift_edate = dgvShift[5, e.RowIndex].Value.ToString();
                vo.shift_comment = dgvShift[7, e.RowIndex].Value.ToString();
                vo.shift_personnel = Convert.ToInt32(dgvShift[10, e.RowIndex].Value);
                vo.shift_weekend = dgvShift[11, e.RowIndex].Value.ToString();
                vo.shift_dns = dgvShift[12, e.RowIndex].Value.ToString();
            }
        }
    }
}
