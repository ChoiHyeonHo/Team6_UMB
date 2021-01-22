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
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnSearch.Visible = false;
            newBtns1.btnWait.Visible = false;
            newBtns1.btnRefresh.Visible = false;
            newBtns1.btnExcel.Visible = false;
            newBtns1.btnDelete.Visible = false;
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
