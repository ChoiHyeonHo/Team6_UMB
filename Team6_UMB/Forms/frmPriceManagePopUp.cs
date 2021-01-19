﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms
{
    public partial class frmPriceManagePopUp : Team6_UMB.frmPopUp
    {
        public frmPriceManagePopUp(string headerName)
        {
            InitializeComponent();
            this.label1.Text = headerName;

            if (label1.Text == "단가관리 - 등록")
            {
                btnCreate.Dock = DockStyle.Fill;
                btnUpdate.Visible = false;
            }
            else if (label1.Text == "단가관리 - 수정")
            {
                btnUpdate.Dock = DockStyle.Fill;
                btnCreate.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
