using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmProdInspection : Team6_UMB.frmBaseList
    {
        public frmProdInspection()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            frmProdInspPopUp frm = new frmProdInspPopUp();
            frm.ShowDialog();
        }
    }
}
