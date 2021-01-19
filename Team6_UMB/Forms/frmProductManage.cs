using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms
{
    public partial class frmProductManage : Team6_UMB.frmBaseList
    {
        string headerName;
        public frmProductManage()
        {
            InitializeComponent();
        }

        private void btnAllButtons1_btnCreate_Event(object sender, EventArgs e)
        {
            headerName = "품목관리 - 등록";
            frmProductManagePopUp frm = new frmProductManagePopUp(headerName);
            frm.ShowDialog();
        }

        private void btnAllButtons1_btnUpdate_Event(object sender, EventArgs e)
        {
            headerName = "품목관리 - 수정";
            frmProductManagePopUp frm = new frmProductManagePopUp(headerName);
            frm.ShowDialog();
        }
    }
}
