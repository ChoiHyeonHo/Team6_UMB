using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms
{
    public partial class frmMatPriceManage : Team6_UMB.frmBaseList
    {
        string headerName;
        public frmMatPriceManage()
        {
            InitializeComponent();
        }

        private void btnAllButtons1_btnCreate_Event(object sender, EventArgs e)
        {
            headerName = "자재단가관리 - 등록";
            frmSalesPricePopUp frm = new frmSalesPricePopUp(headerName);
            frm.ShowDialog();
        }

        private void btnAllButtons1_btnUpdate_Event(object sender, EventArgs e)
        {
            headerName = "자재단가관리 - 수정";
            frmSalesPricePopUp frm = new frmSalesPricePopUp(headerName);
            frm.ShowDialog();
        }
    }
}
