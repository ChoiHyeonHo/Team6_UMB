﻿using System;
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
        public frmBOMPopUp(string headerName, int bomID, string bom_parent_id, string prod_parent_id, string prod_parent_name, string product_id, string product_name, string product_type, string product_unit, int bom_use_count, int bom_level, string bom_comment)
        {
            InitializeComponent();
            CBBinding();

            label1.Text = headerName;
            lblBOMID.Text = bomID.ToString();
            lblBOMParentID.Text = bom_parent_id;
            lblProdParentID.Text = prod_parent_id;
            cbParent.Text = prod_parent_name;
            lblProdID.Text = product_id;
            cbProd.Text = product_name;
            lblProdType.Text = product_type;
            lblProdUnit.Text = product_unit;
            nuUseCount.Value = bom_use_count;
            nuLevel.Value = bom_level;
            txtComment.Text = bom_comment;
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
            //
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (label1.Text == "BOM 등록")
            {
                BOMVO vo = new BOMVO
                {
                    prod_parent_name = cbParent.Text,
                    product_name = cbProd.Text,
                    bom_use_count = (int)nuUseCount.Value,
                    bom_level = (int)nuLevel.Value,
                    bom_comment = txtComment.Text
                };

                bool result = service.Insert(vo);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            else if (label1.Text == "BOM 수정")
            {
                BOMVO vo = new BOMVO
                {
                    bom_id = int.Parse(lblBOMID.Text),
                    prod_parent_name = cbParent.Text,
                    product_name = cbProd.Text,
                    bom_use_count = (int)nuUseCount.Value,
                    bom_level = (int)nuLevel.Value,
                    bom_comment = txtComment.Text
                };

                bool result = service.Update(vo);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
        }
    }
}
