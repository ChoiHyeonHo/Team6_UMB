using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmImpInsComment : Team6_UMB.frmPopUp
    {
        ProdImpInsService service = new ProdImpInsService();
        string pEtc;
        int pID;
        public frmImpInsComment(int cl_inc_id, string etc)
        {
            InitializeComponent();
            pEtc = etc;
            pID = cl_inc_id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string comment = txtComment.Text;
            bool result = service.Comment(pEtc, comment, pID);
            if (result)
            {
                MessageBox.Show(Properties.Resources.msgOK);
            }
            else
                MessageBox.Show(Properties.Resources.msgError);

            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }
    }
}
