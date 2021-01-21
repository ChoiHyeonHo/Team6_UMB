using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms
{
    public partial class frmPDStock : Team6_UMB.frmBaseList
    {
        public frmPDStock()
        {
            InitializeComponent();
        }

        private void btnSearchExcelPrint1_btnSearch_Event(object sender, EventArgs e)
        {
            frmPDStockPopUp frm = new frmPDStockPopUp();
            frm.ShowDialog();
        }
    }
}
