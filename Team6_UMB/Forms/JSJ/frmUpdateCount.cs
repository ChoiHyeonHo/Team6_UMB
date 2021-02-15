using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms
{
    public partial class frmUpdateCount : Team6_UMB.frmPopUp
    {
        public frmUpdateCount(string title, int id)
        {
            InitializeComponent();
            label1.Text = title;
            label1.Tag = id;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(label1.Text == "발주 수정")
            {
                OrderService service = new OrderService();
                OrderListVO vo = new OrderListVO()
                {
                    order_id = Convert.ToInt32(label1.Tag),
                    order_edate = dtpEdate.Text,
                    order_count = Convert.ToInt32(nuCount.Value)
                };
                if(service.UpdateOrder(vo) == 1)
                {
                    MessageBox.Show("수정 완료");
                    this.Close();
                }
            }
            else
            {
                SOService service = new SOService();
                SOListVO vo = new SOListVO()
                {
                    so_id = Convert.ToInt32(label1.Tag),
                    so_edate = dtpEdate.Text,
                    so_ocount = Convert.ToInt32(nuCount.Value)
                };
                if (service.UpdateSO(vo) == 1)
                {
                    MessageBox.Show("수정 완료");
                    this.Close();
                }
            }
        }
    }
}
