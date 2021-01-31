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
        int bomID, bom_use_count, bom_level;
        string product_name, product_type, product_unit, bom_comment, bom_parent_id;

        string prodName, prodType;
        int level;
        
        public frmBOM()
        {
            InitializeComponent();
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnSearch.Visible = false;
            newBtns1.btnWait.Visible = false;
            newBtns1.btnExcel.Visible = false;
            newBtns1.btnPrint.Visible = false;
        }

        private void frmBOM_Load(object sender, EventArgs e)
        {
            #region 0레벨 BOM GridView
            CommonUtil.SetInitGridView(dgvBOM_Lv0);
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "번호", "bom_id", 60);               //0
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "품목명", "product_name", 80);       //1
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "분류", "product_type", 80);         //2
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "단위", "product_unit", 60);         //3
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "소요량", "bom_use_count", 70);      //4
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "레벨", "bom_level", 70);            //5
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "비고", "bom_comment", 10, false);   //6
            CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "상위", "bom_parent_id", 10, false); //7
            #endregion

            #region BOMAll GridView
            CommonUtil.SetInitGridView(dgvBOMAll);
            CommonUtil.AddGridTextColumn(dgvBOMAll, "번호", "bom_id", 80);               //0
            CommonUtil.AddGridTextColumn(dgvBOMAll, "품목코드", "product_id", 140);        //1
            CommonUtil.AddGridTextColumn(dgvBOMAll, "품목명", "product_name", 160);       //2
            CommonUtil.AddGridTextColumn(dgvBOMAll, "분류", "product_type", 160);         //3
            CommonUtil.AddGridTextColumn(dgvBOMAll, "단위", "product_unit", 140);         //4
            CommonUtil.AddGridTextColumn(dgvBOMAll, "소요량", "bom_use_count", 150);      //5
            CommonUtil.AddGridTextColumn(dgvBOMAll, "레벨", "bom_level", 140);            //6
            #endregion

            gbBOM.Visible = false;

            allList = service.GetBOMCBProdName();
            CommonUtil.BOMProdName(cbProdName, allList);

            DGV_Binding_Lv0();

//            ; WITH temp as
// (
//     select bom_id, B.product_id, product_name, product_type, product_unit, bom_use_count, bom_level, bom_comment, bom_parent_id
//     from TBL_BOM B join TBL_PRODUCT P on B.product_id = P.product_id where bom_level = 3
//)
//select a.bom_id, a.product_id, a.product_name, a.product_type, a.product_unit, a.bom_use_count, a.bom_level, a.bom_comment, a.bom_parent_id, b.product_id pp, tp.product_name pn
//from temp a inner join TBL_BOM b on a.bom_parent_id = b.bom_id inner join TBL_PRODUCT tp on b.product_id = tp.product_id;

        }

        private void DGV_Binding_Lv0()
        {
            allList = service.GetBOMInfo();
            dgvBOM_Lv0.DataSource = allList;
        }

        private void dgvBOM_Lv0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bomID = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[0].Value.ToString());           //BOMID
            product_name = dgvBOM_Lv0.Rows[e.RowIndex].Cells[1].Value.ToString();               //제품명
            product_type = dgvBOM_Lv0.Rows[e.RowIndex].Cells[2].Value.ToString();               //분류
            product_unit = dgvBOM_Lv0.Rows[e.RowIndex].Cells[3].Value.ToString();               //단위
            bom_use_count = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[4].Value.ToString());   //소요량
            bom_level = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[5].Value.ToString());       //레벨
            bom_comment = dgvBOM_Lv0.Rows[e.RowIndex].Cells[6].Value.ToString();                //비고
            bom_parent_id = dgvBOM_Lv0.Rows[e.RowIndex].Cells[7].Value.ToString();              //상위품목ID
            btnPreView.PerformClick();
        }

        private void cbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLevel.SelectedIndex > 0)
            {
                allList = service.GetBOMComboBoxCall(int.Parse(cbLevel.Text));
                dgvBOM_Lv0.DataSource = allList;
            }
        }

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



            frmBOMPopUp frm = new frmBOMPopUp(headerName, bomID, product_name, product_type, product_unit, bom_use_count, bom_level, bom_comment, bom_parent_id);
            frm.ShowDialog();
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
