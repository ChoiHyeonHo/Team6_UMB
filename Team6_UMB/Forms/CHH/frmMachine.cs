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

namespace Team6_UMB.Forms
{
    public partial class frmMachine : Form
    {
        List<MachineVO> allList;
        MachineService service = new MachineService();
        string m_info, m_name, m_yn, m_comment;
        int m_id;

        public frmMachine()
        {
            InitializeComponent();

            newBtns1.btnBarCode.Visible = newBtns1.btnDocument.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnWait.Visible = false;
        }

        private void frmMachine_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvMachine);
            CommonUtil.AddGridTextColumn(dgvMachine, "설비번호", "m_id", 80);
            CommonUtil.AddGridTextColumn(dgvMachine, "설비정보", "m_info", 250);
            CommonUtil.AddGridTextColumn(dgvMachine, "설비명", "m_name", 200);
            CommonUtil.AddGridTextColumn(dgvMachine, "사용여부", "m_yn", 80);
            CommonUtil.AddGridTextColumn(dgvMachine, "비고", "m_comment", 500);
            CommonUtil.AddGridTextColumn(dgvMachine, "수정자", "m_uadmin", 120);
            CommonUtil.AddGridTextColumn(dgvMachine, "수정일", "m_udate", 150);
            DGVBinding();

            List<MachineVO> allMachineItem = service.GetMachineInfo();
            CommonUtil.MachineNameBinding(cbMachine, allMachineItem);
        }

        private void DGVBinding()
        {
            allList = service.CHH_GetMachineInfo();
            dgvMachine.DataSource = allList;
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            string HeaderName = "설비정보 등록";
            frmMachinePopUp frm = new frmMachinePopUp(HeaderName);
            frm.Show();
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            allList = service.CHH_MachineWhere(m_name);
            dgvMachine.DataSource = allList;
        }

        private void cbMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_name = cbMachine.Text;
        }

        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            string HeaderName = "설비정보 수정";
            frmMachinePopUp frm = new frmMachinePopUp(HeaderName, m_id, m_info, m_name, m_yn, m_comment);
            frm.Show();
        }

        private void dgvMachine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            m_id = int.Parse(dgvMachine.Rows[e.RowIndex].Cells[0].Value.ToString());
            m_info = dgvMachine.Rows[e.RowIndex].Cells[1].Value.ToString();
            m_name = dgvMachine.Rows[e.RowIndex].Cells[2].Value.ToString();
            m_yn = dgvMachine.Rows[e.RowIndex].Cells[3].Value.ToString();
            m_comment = dgvMachine.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.msgDelete, "삭제확인 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = service.CHH_MachineDelete(m_id);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGVBinding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
        }
    }
}
