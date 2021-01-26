using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UMB_VO;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmUserPopUp : Team6_UMB.frmPopUp
    {
        public frmUserPopUp()
        {
            InitializeComponent();
        }

        public frmUserPopUp(UserVO user)
        {
            InitializeComponent();
            label1.Text = "사원정보수정";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(label1.Text == "사원정보등록")
            {

            }
            else
            {

            }
        }

        private void frmUserPopUp_Load(object sender, EventArgs e)
        {

        }
    }
}
