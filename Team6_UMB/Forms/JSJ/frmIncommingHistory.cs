using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;

namespace Team6_UMB.Forms.JSJ
{
    public partial class frmIncommingHistory : Team6_UMB.frmPopUp
    {
        string product_name;
        public frmIncommingHistory(string product_name)
        {
            InitializeComponent();
            this.product_name = product_name;
        }

        private void frmIncommingHistory_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvHistory);
            CommonUtil.AddGridTextColumn(dgvHistory, "품목", "product_name", 195);
            CommonUtil.AddGridTextColumn(dgvHistory, "입고수량", "incomming_count", 145);
            CommonUtil.AddGridTextColumn(dgvHistory, "입고일", "incomming_date", 195);
            CommonUtil.AddGridTextColumn(dgvHistory, "합불판정", "orderexam_result", 145);

            IncommingService service = new IncommingService();
            dgvHistory.DataSource = service.IncommingHistory(product_name);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
