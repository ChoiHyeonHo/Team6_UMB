using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Dev;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmImpInspecPopUp : Team6_UMB.frmPopUp
    {
        ProdImpInsService service = new ProdImpInsService();
        List<InsCheckVO> allList;
        string dTemp, pTemp;
        CheckBox headerCheck = new CheckBox();
        int cl_inc_id;
        string cl_inc_Color, cl_inc_Torn, cl_inc_Length, cl_inc_Crack, etc;

        public frmImpInspecPopUp(string temp)
        {
            InitializeComponent();
            dTemp = temp;
            newBtns1.btnBarCode.Visible = newBtns1.btnCreate.Visible = newBtns1.btnDelete.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnUpdate.Visible = newBtns1.btnWait.Visible = false;
            newBtns1.btnDocument.Text = "검사지";
        }

        private void frmImpInspecPopUp_Load(object sender, EventArgs e)
        {
            dgvCheckList.AutoGenerateColumns = false;
            dgvCheckList.AllowUserToAddRows = false;
            dgvCheckList.MultiSelect = false;
            dgvCheckList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvCheckList.Columns.Add(chk);

            Point point = dgvCheckList.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheck.Location = new Point(point.X + 8, point.Y + 2);
            headerCheck.BackColor = Color.White;
            headerCheck.Size = new Size(18, 18);
            headerCheck.Click += HeaderCheck_Click;
            dgvCheckList.Controls.Add(headerCheck);

            CommonUtil.SetInitGridView(dgvCheckList);
            CommonUtil.AddGridTextColumn(dgvCheckList, "검사번호", "cl_inc_id", 80);
            CommonUtil.AddGridTextColumn(dgvCheckList, "입고번호", "incomming_ID", 80);
            CommonUtil.AddGridTextColumn(dgvCheckList, "색상", "cl_inc_Color", 90);
            CommonUtil.AddGridTextColumn(dgvCheckList, "찢어짐", "cl_inc_Torn", 90);
            CommonUtil.AddGridTextColumn(dgvCheckList, "길이", "cl_inc_Length", 90);
            CommonUtil.AddGridTextColumn(dgvCheckList, "찍힘", "cl_inc_Crack", 90);
            CommonUtil.AddGridTextColumn(dgvCheckList, "기타", "etc", 200);
            DGVBinding();
        }
        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            dgvCheckList.EndEdit(); //현재 포커스가 있는 셀의 편집을 종료(다른 셀로 이동시키는것과 같은 효과)

            foreach (DataGridViewRow row in dgvCheckList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                chk.Value = headerCheck.Checked;
            }
        }
        private void DGVBinding()
        {
            allList = service.GetInsCheckInfo(dTemp);
            dgvCheckList.DataSource = allList;
        }

        private void newBtns1_btnDocument_Event(object sender, EventArgs e)
        {
            List<int> CheckList = new List<int>();
            foreach (DataGridViewRow row in dgvCheckList.Rows)
            {
                CheckList.Add(int.Parse(row.Cells["cl_inc_id"].Value.ToString()));
            }
            string temp = string.Join(",", CheckList);
            InsCheck rpt = new InsCheck();
            rpt.DataSource = service.GetInsCheckInfoDEV(temp);
            frmReportPreview frm = new frmReportPreview(rpt);
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnCancle_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }

        

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }

        

        #region 컨텍스트 메뉴 스트립

        #region 색 양호
        private void 양호ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            pTemp = "cl_inc_Color";
            cl_inc_Color = "양호";

            bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }

        
        #endregion
        #region 색 불량
        private void 불량ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            pTemp = "cl_inc_Color";
            cl_inc_Color = "불량";
            bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
        #endregion

        #region 찢어짐 양호
        private void 양호ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            pTemp = "cl_inc_Torn";
            cl_inc_Color = "양호";
            bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }

        private void 비고ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            etc = "etc";

            frmImpInsComment frm = new frmImpInsComment(cl_inc_id, etc);
            frm.Show();
        }
        #endregion
        #region 찢어짐 불량
        private void 불량ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            pTemp = "cl_inc_Torn";
            cl_inc_Color = "불량";
            bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
        #endregion

        #region 길이 양호
        private void 양호ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            pTemp = "cl_inc_Length";
            cl_inc_Color = "양호";
            bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
        #endregion
        #region 길이 불량
        private void 불량ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            pTemp = "cl_inc_Length";
            cl_inc_Color = "불량";
            bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
        #endregion

        #region 찍힘 양호
        private void 양호ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            pTemp = "cl_inc_Crack";
            cl_inc_Color = "양호";
            bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
        #endregion
        #region 찍힘 불량
        private void 불량ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            pTemp = "cl_inc_Crack";
            cl_inc_Color = "불량";
            bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
        #endregion

        #endregion
    }
}
