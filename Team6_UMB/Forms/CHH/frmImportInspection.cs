using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmImportInspection : Team6_UMB.frmBaseList
    {
        ProdImpInsService service = new ProdImpInsService();
        List<ProdImpInsVO> allList;
        CheckBox headerCheck = new CheckBox();

        public frmImportInspection()
        {
            InitializeComponent();
            newBtns1.btnCreate.Text = "검사";
            newBtns1.btnBarCode.Visible = newBtns1.btnDelete.Visible = newBtns1.btnDocument.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnUpdate.Visible = newBtns1.btnWait.Visible = false;
        }

        private void frmImportInspection_Load(object sender, EventArgs e)
        {
            dgvIncomming.AutoGenerateColumns = false;
            dgvIncomming.AllowUserToAddRows = false;
            dgvIncomming.MultiSelect = false;
            dgvIncomming.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvIncomming.Columns.Add(chk);

            Point point = dgvIncomming.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheck.Location = new Point(point.X + 8, point.Y + 2);
            headerCheck.BackColor = Color.White;
            headerCheck.Size = new Size(18, 18);
            headerCheck.Click += HeaderCheck_Click;
            dgvIncomming.Controls.Add(headerCheck);

            CommonUtil.SetInitGridView(dgvIncomming);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고번호", "incomming_ID", 80);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고상태", "incomming_state", 150);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고일", "incomming_date", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "담당자", "incomming_rep", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고량", "incomming_count", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "발주번호", "order_id", 150);
            CommonUtil.AddGridTextColumn(dgvIncomming, "합불판정", "orderexam_result", 100);
            CommonUtil.AddGridTextColumn(dgvIncomming, "수정자", "incomming_uadmin", 150);
            CommonUtil.AddGridTextColumn(dgvIncomming, "수정일", "incomming_udate", 150);

            allList = service.GetIncomminInfo();
            dgvIncomming.DataSource = allList;
        }

        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            dgvIncomming.EndEdit(); //현재 포커스가 있는 셀의 편집을 종료(다른 셀로 이동시키는것과 같은 효과)

            foreach (DataGridViewRow row in dgvIncomming.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                chk.Value = headerCheck.Checked;
            }
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            List<int> chkBarCodeList = new List<int>();

            foreach (DataGridViewRow row in dgvIncomming.Rows)
            {
                bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                if (bCheck)
                {
                    chkBarCodeList.Add(int.Parse(row.Cells["incomming_ID"].Value.ToString()));
                }
            }
            string temp = string.Join(",", chkBarCodeList);
            frmImpInspecPopUp frm = new frmImpInspecPopUp(temp);
            frm.Show();
        }
    }
}
