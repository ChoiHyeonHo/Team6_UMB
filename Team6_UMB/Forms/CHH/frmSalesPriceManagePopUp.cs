using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms
{
    public partial class frmSalesPricePopUp : Team6_UMB.frmPopUp
    {
        public frmSalesPricePopUp(string headerName)
        {
            InitializeComponent();
            this.label1.Text = headerName;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now.AddDays(7);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (label1.Text == "단가관리 등록")
            {

            }
            else if (label1.Text == "단가관리 수정")
            {

            }
        }
    }
}
