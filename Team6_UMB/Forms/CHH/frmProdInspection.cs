using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmProdInspection : Team6_UMB.frmBaseList
    {
        ProdInsService service = new ProdInsService();
        List<ProdInsVO> allList;
        CheckBox headerCheck = new CheckBox();

        public frmProdInspection()
        {
            InitializeComponent();
            newBtns1.btnCreate.Text = "검사";
            newBtns1.btnBarCode.Visible = newBtns1.btnDelete.Visible = newBtns1.btnDocument.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnUpdate.Visible = newBtns1.btnWait.Visible = false;

            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();
        }
        private void frmProdInspection_Load(object sender, EventArgs e)
        {
            dgvProdCheck.AutoGenerateColumns = false;
            dgvProdCheck.AllowUserToAddRows = false;
            dgvProdCheck.MultiSelect = false;
            dgvProdCheck.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvProdCheck.Columns.Add(chk);

            Point point = dgvProdCheck.GetCellDisplayRectangle(0, -1, true).Location;

            headerCheck.Location = new Point(point.X + 8, point.Y + 2);
            headerCheck.BackColor = Color.White;
            headerCheck.Size = new Size(18, 18);
            headerCheck.Click += HeaderCheck_Click;
            dgvProdCheck.Controls.Add(headerCheck);

            CommonUtil.SetInitGridView(dgvProdCheck);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "생산번호", "production_id", 90);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "작업지시번호", "wo_id", 100);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "수주번호", "so_id", 90);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "품목코드", "product_id", 150);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "품목명", "product_name", 150);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "출하상태", "ship_state", 200);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "생산상태", "production_state", 200);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "납기일", "so_edate", 150);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "출하번호", "ship_id", 150);
            CommonUtil.AddGridTextColumn(dgvProdCheck, "생산량", "production_count", 150);
            DGVBinding();
        }

        private void DGVBinding()
        {
            allList = service.GetProdInsInfo();
            dgvProdCheck.DataSource = allList;
        }

        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            dgvProdCheck.EndEdit(); //현재 포커스가 있는 셀의 편집을 종료(다른 셀로 이동시키는것과 같은 효과)

            foreach (DataGridViewRow row in dgvProdCheck.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                chk.Value = headerCheck.Checked;
            }
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            List<int> chkBarCodeList = new List<int>();
            foreach (DataGridViewRow row in dgvProdCheck.Rows)
            {
                bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                if (bCheck)
                {
                    chkBarCodeList.Add(int.Parse(row.Cells["ship_id"].Value.ToString()));
                }
            }
            string temp = string.Join(",", chkBarCodeList);
            frmProdInspPopUp frm = new frmProdInspPopUp(temp);
            frm.Show();
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }

        private void periodSearchControl2_ChangedPeriod(object sender, EventArgs e)
        {
            if (dgvProdCheck.DataSource != null)
            {
                if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                {
                    string FromDate = periodSearchControl.dtFrom;
                    string ToDate = periodSearchControl.dtTo;

                    List<ProdInsVO> periodList = (from period in allList
                                                     where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(period.so_edate) && Convert.ToDateTime(period.so_edate) <= Convert.ToDateTime(ToDate)
                                                     select period).ToList();
                    dgvProdCheck.DataSource = periodList;
                }
            }
        }
    }
}
