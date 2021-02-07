using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Dev;
using Team6_UMB.Service;
using UMB_VO;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmProdInspPopUp : Team6_UMB.frmPopUp
    {
        CheckBox headerCheck = new CheckBox();
        ProdInsService service = new ProdInsService();
        List<ProdInsPopUpVO> allList;
        string dTemp, componentTemp, state, etc;
        int clPK;

        public frmProdInspPopUp(string temp)
        {
            InitializeComponent();
            dTemp = temp;
            newBtns1.btnBarCode.Visible = newBtns1.btnCreate.Visible = newBtns1.btnDelete.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnWait.Visible = newBtns1.btnUpdate.Visible = false;
            newBtns1.btnDocument.Text = "검사지";
            newBtns1.btnShipment.Text = "완료";
        }

        private void frmProdInspPopUp_Load(object sender, EventArgs e)
        {
            dgv_CheckList.AutoGenerateColumns = false;
            dgv_CheckList.AllowUserToAddRows = false;
            dgv_CheckList.MultiSelect = false;
            dgv_CheckList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgv_CheckList.Columns.Add(chk);

            Point point = dgv_CheckList.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheck.Location = new Point(point.X + 8, point.Y + 2);
            headerCheck.BackColor = Color.White;
            headerCheck.Size = new Size(18, 18);
            headerCheck.Click += HeaderCheck_Click;
            dgv_CheckList.Controls.Add(headerCheck);

            CommonUtil.SetInitGridView(dgv_CheckList);
            CommonUtil.AddGridTextColumn(dgv_CheckList, "검사번호", "cl_ship_id", 80);
            CommonUtil.AddGridTextColumn(dgv_CheckList, "출하번호", "ship_id", 80);
            CommonUtil.AddGridTextColumn(dgv_CheckList, "품목명", "product_name", 90);
            CommonUtil.AddGridTextColumn(dgv_CheckList, "구성품", "cl_ship_Components", 90);
            CommonUtil.AddGridTextColumn(dgv_CheckList, "포장", "cl_ship_Packing", 90);
            CommonUtil.AddGridTextColumn(dgv_CheckList, "기타", "etc", 90);
            CommonUtil.AddGridTextColumn(dgv_CheckList, "생산상태", "production_state", 200);
            DGVBinding();
        }
        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            dgv_CheckList.EndEdit(); //현재 포커스가 있는 셀의 편집을 종료(다른 셀로 이동시키는것과 같은 효과)
            List<int> index = new List<int>();
            foreach (DataGridViewRow row in dgv_CheckList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                chk.Value = headerCheck.Checked;
            }
        }

        private void DGVBinding()
        {
            allList = service.GetProdInsPopUpInfo(dTemp);
            dgv_CheckList.DataSource = allList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newBtns1_btnShipment_Event(object sender, EventArgs e)
        {
            List<int> clShipID = new List<int>();
            List<int> shipID = new List<int>();
            foreach (DataGridViewRow row in dgv_CheckList.Rows)
            {
                bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                if (bCheck)
                {
                    clShipID.Add(int.Parse(row.Cells["cl_ship_id"].Value.ToString()));
                    shipID.Add(int.Parse(row.Cells["ship_id"].Value.ToString()));
                }
            }
            string ctemp = string.Join(",", clShipID);
            string stemp = string.Join(",", shipID);
            string userName = LoginVO.user.Name;
            bool result = service.UpdateAll(ctemp, stemp, userName); // ctemp = PK
            bool result2 = service.InsertCheckHistory(ctemp);
            if (result && result2)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }

        

        private void btnCancle_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }

        private void newBtns1_btnDocument_Event(object sender, EventArgs e)
        {
            List<int> CheckList = new List<int>();
            foreach (DataGridViewRow row in dgv_CheckList.Rows)
            {
                bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                if (bCheck)
                {
                    CheckList.Add(int.Parse(row.Cells["cl_ship_id"].Value.ToString()));
                }
            }
            string temp = string.Join(",", CheckList);
            ProdCheck rpt = new ProdCheck();
            rpt.DataSource = service.GetProdCheckInfoDEV(temp);
            frmReportPreview frm = new frmReportPreview(rpt);
        }

        #region 컨텍스트 메뉴스트립
        #region 비고
        private void 비고ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string headerName = "제품검사 비고";
            clPK = int.Parse(dgv_CheckList.Rows[dgv_CheckList.CurrentRow.Index].Cells[1].Value.ToString());
            etc = "etc";

            frmImpInsComment frm = new frmImpInsComment(headerName, clPK, etc);
            frm.Show();
        }
        #endregion

        #region 구성품 양품
        private void 양품ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clPK = int.Parse(dgv_CheckList.Rows[dgv_CheckList.CurrentRow.Index].Cells[1].Value.ToString());
            componentTemp = "cl_ship_Components";
            state = "양호";

            bool result = service.Update(state, componentTemp, clPK);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
        #endregion
        #region 구성품 불량
        private void 불량ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clPK = int.Parse(dgv_CheckList.Rows[dgv_CheckList.CurrentRow.Index].Cells[1].Value.ToString());
            componentTemp = "cl_ship_Components";
            state = "불량";

            bool result = service.Update(state, componentTemp, clPK);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }

        
        #endregion

        #region 포장 양품
        private void 양품ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clPK = int.Parse(dgv_CheckList.Rows[dgv_CheckList.CurrentRow.Index].Cells[1].Value.ToString());
            componentTemp = "cl_ship_Packing";
            state = "양호";

            bool result = service.Update(state, componentTemp, clPK);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
        #endregion
        #region 포장 불량
        private void 불량ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clPK = int.Parse(dgv_CheckList.Rows[dgv_CheckList.CurrentRow.Index].Cells[1].Value.ToString());
            componentTemp = "cl_ship_Packing";
            state = "불량";

            bool result = service.Update(state, componentTemp, clPK);
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
