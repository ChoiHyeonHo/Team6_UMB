using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmBORPopup : Team6_UMB.frmPopUp
    {
        string headName;
        //string BOR

        public frmBORPopup(string headName)
        {
            InitializeComponent();
            this.headName = headName;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(headName == "BOR추가")
            {
                BORService service = new BORService();
                service.BORInsert();
            }
        }

        private void setBORInfo()
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
