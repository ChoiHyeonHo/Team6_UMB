using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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

            #region 1레벨 BOM GridView
            CommonUtil.SetInitGridView(dgvBOM_Lv1);
            CommonUtil.AddGridTextColumn(dgvBOM_Lv1, "번호", "bom_id", 60);               //0
            CommonUtil.AddGridTextColumn(dgvBOM_Lv1, "품목명", "product_name", 80);       //1
            CommonUtil.AddGridTextColumn(dgvBOM_Lv1, "분류", "product_type", 80);         //2
            CommonUtil.AddGridTextColumn(dgvBOM_Lv1, "단위", "product_unit", 60);         //3
            CommonUtil.AddGridTextColumn(dgvBOM_Lv1, "소요량", "bom_use_count", 70);      //4
            CommonUtil.AddGridTextColumn(dgvBOM_Lv1, "레벨", "bom_level", 70);            //5
            #endregion

            #region 2레벨 BOM GridView
            CommonUtil.SetInitGridView(dgvBOM_Lv2);
            CommonUtil.AddGridTextColumn(dgvBOM_Lv2, "번호", "bom_id", 60);               //0
            CommonUtil.AddGridTextColumn(dgvBOM_Lv2, "품목명", "product_name", 80);       //1
            CommonUtil.AddGridTextColumn(dgvBOM_Lv2, "분류", "product_type", 80);         //2
            CommonUtil.AddGridTextColumn(dgvBOM_Lv2, "단위", "product_unit", 60);         //3
            CommonUtil.AddGridTextColumn(dgvBOM_Lv2, "소요량", "bom_use_count", 70);      //4
            CommonUtil.AddGridTextColumn(dgvBOM_Lv2, "레벨", "bom_level", 70);            //5
            #endregion

            #region 3레벨 BOM GridView
            CommonUtil.SetInitGridView(dgvBOM_Lv3);
            CommonUtil.AddGridTextColumn(dgvBOM_Lv3, "번호", "bom_id", 60);               //0
            CommonUtil.AddGridTextColumn(dgvBOM_Lv3, "품목명", "product_name", 80);       //1
            CommonUtil.AddGridTextColumn(dgvBOM_Lv3, "분류", "product_type", 80);         //2
            CommonUtil.AddGridTextColumn(dgvBOM_Lv3, "단위", "product_unit", 60);         //3
            CommonUtil.AddGridTextColumn(dgvBOM_Lv3, "소요량", "bom_use_count", 70);      //4
            CommonUtil.AddGridTextColumn(dgvBOM_Lv3, "레벨", "bom_level", 70);            //5
            #endregion

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
            allList = service.GetBOMInfoLv(bomID);
            dgvBOM_Lv1.DataSource = allList;
        }
        private void dgvBOM_Lv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bomID = int.Parse(dgvBOM_Lv1.Rows[e.RowIndex].Cells[0].Value.ToString());
            allList = service.GetBOMInfoLv(bomID);
            dgvBOM_Lv2.DataSource = allList;
        }

        private void dgvBOM_Lv2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bomID = int.Parse(dgvBOM_Lv2.Rows[e.RowIndex].Cells[0].Value.ToString());
            allList = service.GetBOMInfoLv(bomID);
            dgvBOM_Lv3.DataSource = allList;
        }

        private void btnPreView_Click(object sender, EventArgs e)
        {
            allList = service.GetBOMPreView(bomPreview);
            dgvPreView.DataSource = allList;
        }
    }
}
