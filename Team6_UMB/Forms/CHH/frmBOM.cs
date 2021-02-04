using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Dev;
using Team6_UMB.Forms.CHH;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmBOM : Team6_UMB.frmBaseList
    {
        BOMService service = new BOMService();
        List<BOMVO> allList;
        List<GetProdTypeVO> GetProdType;

        int bomID, bom_use_count, bom_level;
        string bom_parent_id, prod_parent_id, prod_parent_name, product_id, product_name, product_type, product_unit, bom_comment;

        string prodName, prodType;
        int level;

        private void cbProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            prodName = cbProdName.Text;
        }

        private void cbProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            prodType = cbProdType.Text;
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            cbLevel.SelectedIndex = cbProdName.SelectedIndex = cbProdType.SelectedIndex = 0;
            gbBOM.Visible = false;
            DGV_Binding_Lv0();
        }

        public frmBOM()
        {
            InitializeComponent();
            newBtns1.btnBarCode.Visible = newBtns1.btnShipment.Visible = newBtns1.btnDocument.Visible = newBtns1.btnSearch.Visible = newBtns1.btnWait.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = false;
        }

        private void frmBOM_Load(object sender, EventArgs e)
        {
            #region 0레벨 BOM GridView
            CommonUtil.SetInitGridView(dgvBOM_Lv0);
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "번호", "bom_id", 40);                           //0
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "상위BOMID", "bom_parent_id", 10, false);        //1
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "상위품목ID", "prod_parent_id", 10, false);      //2
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "상위품목명", "prod_parent_name", 10, false);    //3
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "품목코드", "product_id", 80);                  //4
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "품목명", "product_name", 90);                  //5
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "분류", "product_type", 60);                    //6
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "단위", "product_unit", 60);                    //7
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "소요량", "bom_use_count", 70);                 //8
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "레벨", "bom_level", 40);                       //9
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "비고", "bom_comment", 140, false);              //10
            #endregion

            #region BOMAll GridView
            CommonUtil.SetInitGridView(dgvBOMAll);
            CommonUtil.AddGridTextColumn(dgvBOMAll, "번호", "bom_id", 80);                           //0
            CommonUtil.AddGridTextColumn(dgvBOMAll, "품목코드", "product_id", 140);                  //1
            CommonUtil.AddGridTextColumn(dgvBOMAll, "품목명", "product_name", 160);                  //2
            CommonUtil.AddGridTextColumn(dgvBOMAll, "분류", "product_type", 160);                    //3
            CommonUtil.AddGridTextColumn(dgvBOMAll, "단위", "product_unit", 140);                    //4
            CommonUtil.AddGridTextColumn(dgvBOMAll, "소요량", "bom_use_count", 150);                 //5
            CommonUtil.AddGridTextColumn(dgvBOMAll, "레벨", "bom_level", 140);                       //6
            #endregion

            gbBOM.Visible = false;

            allList = service.GetBOMCBProdName();
            CommonUtil.BOMProdName(cbProdName, allList);

            ProdStatusService service2 = new ProdStatusService();
            GetProdType = service2.GetProdType();
            CommonUtil.ProdTypeBinding(cbProdType, GetProdType);

            DGV_Binding_Lv0();
        }

        private void DGV_Binding_Lv0()
        {
            allList = service.GetBOMInfo();
            dgvBOM_Lv0.DataSource = allList;
        }

        private void dgvBOM_Lv0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bomID = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[0].Value.ToString());
            bom_parent_id = dgvBOM_Lv0.Rows[e.RowIndex].Cells[1].Value.ToString();
            prod_parent_id = dgvBOM_Lv0.Rows[e.RowIndex].Cells[2].Value.ToString();
            prod_parent_name = dgvBOM_Lv0.Rows[e.RowIndex].Cells[3].Value.ToString();
            product_id = dgvBOM_Lv0.Rows[e.RowIndex].Cells[4].Value.ToString();
            product_name = dgvBOM_Lv0.Rows[e.RowIndex].Cells[5].Value.ToString();
            product_type = dgvBOM_Lv0.Rows[e.RowIndex].Cells[6].Value.ToString();
            product_unit = dgvBOM_Lv0.Rows[e.RowIndex].Cells[7].Value.ToString();
            bom_use_count = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[8].Value.ToString());
            bom_level = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[9].Value.ToString());
            bom_comment = dgvBOM_Lv0.Rows[e.RowIndex].Cells[10].Value.ToString();

            btnPreView.PerformClick();
        }

        //private void cbLevel_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbLevel.SelectedIndex > 0)
        //    {
        //        allList = service.GetBOMComboBoxCall(int.Parse(cbLevel.Text));
        //        dgvBOM_Lv0.DataSource = allList;
        //    }
        //}

        private void btnWhere_Click(object sender, EventArgs e)
        {
            if (cbLevel.SelectedIndex > 0)
                level = int.Parse(cbLevel.Text);
            if (cbProdName.SelectedIndex > 0)
                prodName = cbProdName.Text;
            if (cbProdType.SelectedIndex > 0)
                prodType = cbProdType.Text;
            allList = service.GetBOMWhereInfo(level, prodName, prodType);
            dgvBOM_Lv0.DataSource = allList;
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            string headerName = "BOM 등록";
            frmBOMPopUp frm = new frmBOMPopUp(headerName);
            frm.ShowDialog();
        }

        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            string headerName = "BOM 수정";
            frmBOMPopUp frm = new frmBOMPopUp(headerName, bomID, bom_parent_id, prod_parent_id, prod_parent_name, product_id, product_name, product_type, product_unit, bom_use_count, bom_level, bom_comment);
            frm.ShowDialog();
        }

        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.msgDelete, "삭제확인 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = service.Delete(bomID);

                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGV_Binding_Lv0();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);

            }
        }

        private void btnPreView_Click(object sender, EventArgs e)
        {
            allList = service.GetBOMPreView(bomID);
            dgvBOMAll.DataSource = allList;

            #region 컬럼헤더 색상 및 글꼴 정의
            dgvBOMAll.EnableHeadersVisualStyles = false;
            dgvBOMAll.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBOMAll.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 52, 79);
            dgvBOMAll.ColumnHeadersDefaultCellStyle.Font = new Font("나눔바른고딕", 12, FontStyle.Regular);
            dgvBOMAll.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgvBOMAll.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBOMAll.ColumnHeadersHeight = 40;
            dgvBOMAll.CurrentCell = null;
            #endregion

            gbBOM.Visible = true;
        }
    }
}
