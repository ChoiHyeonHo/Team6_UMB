using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms
{
    public partial class frmProductManagePopUp : Team6_UMB.frmPopUp
    {
        public frmProductManagePopUp(string headerName)
        {
            InitializeComponent();
            this.label1.Text = headerName;
        }

        public frmProductManagePopUp(string headerName, string product_id, string product_name, string product_type, string product_unit, int price_present, string w_name, int product_lorder_count, int product_safety_count, string company_name, string product_exam, string price_yn, int company_id, int w_id, string product_stnd, string product_comment, string product_deleted)
        {
            InitializeComponent();
            this.label1.Text = headerName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
