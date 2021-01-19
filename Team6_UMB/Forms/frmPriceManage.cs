using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms
{
    public partial class frmPriceManage : frmBaseList
    {
        public frmPriceManage()
        {
            InitializeComponent();
        }

        private void btnAllButtons1_btnCreate_Event(object sender, EventArgs e)
        {
            string headerName = "단가관리 - 등록";
            frmPriceManagePopUp frm = new frmPriceManagePopUp(headerName);
            frm.ShowDialog();
        }

        private void btnAllButtons1_btnUpdate_Event(object sender, EventArgs e)
        {
            string headerName = "단가관리 - 수정";
            frmPriceManagePopUp frm = new frmPriceManagePopUp(headerName);
            frm.ShowDialog();
        }
    }
}
