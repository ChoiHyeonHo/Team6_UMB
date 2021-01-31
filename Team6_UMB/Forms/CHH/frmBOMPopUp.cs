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
    public partial class frmBOMPopUp : Team6_UMB.frmPopUp
    {
        BOMService service = new BOMService();
        List<BOMVO> allList;
        public frmBOMPopUp(string HeaderName)
        {
            InitializeComponent();
            CBBinding();
            label1.Text = HeaderName;
        }
        public frmBOMPopUp(string headerName, int bomID, string product_name, string product_type, string product_unit, int bom_use_count, int bom_level, string bom_comment, string bom_parent_id)
        {
            InitializeComponent();
            CBBinding();

            label1.Text = headerName;
            lblBOMID.Text = bomID.ToString();
            cbProd.Text = product_name;
            nuUseCount.Text = bom_use_count.ToString();
            nuLevel.Text = bom_level.ToString();
            txtComment.Text = bom_comment;
            lblParentProdID.Text = bom_parent_id;

        }
        private void CBBinding()
        {
            allList = service.GetBOMCBProdName();
            CommonUtil.BOMProdName(cbParent, allList);
            CommonUtil.BOMProdName(cbProd, allList);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbParent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
