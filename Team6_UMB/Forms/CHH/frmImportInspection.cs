using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmImportInspection : Team6_UMB.frmBaseList
    {
        public frmImportInspection()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            frmImpInspecPopUp frm = new frmImpInspecPopUp();
            frm.ShowDialog();
        }
    }
}
