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

namespace Team6_UMB.Forms.BMN
{
    public partial class frmdefectiveRegi : Form
    {
        List<ComboItemVO> defList = null;
        string common_name, common_value;

        public frmdefectiveRegi()
        {
            InitializeComponent();
            newBtns1.btnBarCode.Visible = newBtns1.btnDocument.Visible = newBtns1.btnShipment.Visible =
                newBtns1.btnWait.Visible = newBtns1.btnSearch.Visible = newBtns1.btnPrint.Visible = newBtns1.btnExcel.Visible = false;
        }

        private void frmdefectiveRegi_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvdef);
            CommonUtil.AddGridTextColumn(dgvdef, "불량유형명", "common_name", 150);
            CommonUtil.AddGridTextColumn(dgvdef, "불량유형비고", "common_value", 200);

            DGV_Binding();
        }

        private void DGV_Binding()
        {
            DefService service = new DefService();
            defList = service.GetDefList();
            dgvdef.DataSource = defList;
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            string headName = "불량유형추가";
            frmdefectiveRegiPopUp pop = new frmdefectiveRegiPopUp(headName);
            pop.ShowDialog();
        }

        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {
            if (common_name == "")
            {
                MessageBox.Show("삭제할 항목을 선택해주세요");
                return;
            }                       
            try
            {
                DefService service = new DefService();
                int common_id = service.GetDefID(common_name);
                bool bResult = service.DefDelete(common_id);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            if (common_name == "")
            {
                MessageBox.Show("수정할 항목을 선택해주세요");
                return;
            }

            string headName = "불량유형수정";
            frmdefectiveRegiPopUp pop = new frmdefectiveRegiPopUp(headName, common_name, common_value);
            pop.ShowDialog();


        }

        private void dgvdef_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                common_name = dgvdef.Rows[e.RowIndex].Cells[0].Value.ToString();
                common_value = dgvdef.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            common_name = common_value = "";
            DGV_Binding();
        }
    }
}
