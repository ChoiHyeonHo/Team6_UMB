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
        int bomID, bomPreview;
        public frmBOM()
        {
            InitializeComponent();
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnSearch.Visible = false;
            newBtns1.btnWait.Visible = false;
            newBtns1.btnRefresh.Visible = false;
            newBtns1.btnExcel.Visible = false;
            newBtns1.btnDelete.Visible = false;
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

            DGV_Binding_Lv0();
        }

        private void DGV_Binding_Lv0()
        {
            allList = service.GetBOMInfo();
            dgvBOM_Lv0.DataSource = allList;
        }

        private void dgvBOM_Lv0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bomID = bomPreview = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[0].Value.ToString());
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
