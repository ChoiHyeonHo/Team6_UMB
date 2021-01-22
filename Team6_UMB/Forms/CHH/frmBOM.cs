using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms
{
    public partial class frmBOM : Team6_UMB.frmBaseList
    {
        string headerName;
        public frmBOM()
        {
            InitializeComponent();
        }

        private void btnAllButtons1_btnCreate_Event(object sender, EventArgs e)
        {
            headerName = "BOM - 등록";
            frmBOMPopUp frm = new frmBOMPopUp(headerName);
            frm.ShowDialog();
        }

        private void btnAllButtons1_btnUpdate_Event(object sender, EventArgs e)
        {
            headerName = "BOM - 수정";
            frmBOMPopUp frm = new frmBOMPopUp(headerName);
            frm.ShowDialog();
        }
    }
}
