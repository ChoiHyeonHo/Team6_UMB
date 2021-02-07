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
        ProdInsService service_P = new ProdInsService();
        string pEtc;
        int pID;
        public frmImpInsComment(string HeaderName, int cl_inc_id, string etc)
        {
            InitializeComponent();
            pEtc = etc;
            pID = cl_inc_id;
            label1.Text = HeaderName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string comment = txtComment.Text;

            if (label1.Text == "수입검사 비고")
            {
                bool result = service.Comment(pEtc, comment, pID);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);

                this.Close();
            }
            else if(label1.Text == "제품검사 비고")
            {
                bool result = service_P.Comment(pEtc, comment, pID);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);

                this.Close();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }
    }
}
