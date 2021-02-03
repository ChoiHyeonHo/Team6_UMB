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
    public partial class frmPDSPopUpUpdate : Team6_UMB.frmPopUp
    {
        PDStockService service = new PDStockService();
        public frmPDSPopUpUpdate(int ps_id, string product_id, string product_name, string product_type, string w_name, string company_name, int ps_stock, string ps_idate, string ps_odate)
        {
            InitializeComponent();

            lblPSID.Text = ps_id.ToString();
            txtProduct_id.Text = product_id;
            txtProduct_Name.Text = product_name;
            txtProduct_Type.Text = product_type;
            txtWHouse.Text = w_name;
            txtCompany.Text = company_name;
            nuStock.Value = ps_stock;
            dtp_idate.Value = Convert.ToDateTime(ps_idate);
            dtp_odate.Value = Convert.ToDateTime(ps_odate);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PDStockVO vo = new PDStockVO
            {
                ps_id = int.Parse(lblPSID.Text),
                product_id = txtProduct_id.Text,
                ps_stock = int.Parse(nuStock.Value.ToString()),
                ps_idate = dtp_idate.Value.ToShortDateString(),
                ps_odate = dtp_odate.Value.ToShortDateString()
            };

            bool result = service.Update(vo);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                this.Close();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
    }
}
