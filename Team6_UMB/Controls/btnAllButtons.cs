using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team6_UMB.Controls
{
    public partial class btnAllButtons : UserControl
    {
        public event EventHandler btnCreate_Event;
        public event EventHandler btnUpdate_Event;
        public event EventHandler btnDelete_Event;
        public event EventHandler btnExcel_Event;
        public event EventHandler btnPrint_Event;

        public btnAllButtons()
        {
            InitializeComponent();
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnExcel.Click += BtnExcel_Click;
            btnPrint.Click += BtnPrint_Click;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (this.btnPrint_Event != null)
            {
                btnPrint_Event(sender, e);
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (this.btnExcel_Event != null)
            {
                btnExcel_Event(sender, e);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.btnDelete_Event != null)
            {
                btnDelete_Event(sender, e);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.btnUpdate_Event != null)
            {
                btnUpdate_Event(sender, e);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (this.btnCreate_Event != null)
            {
                btnCreate_Event(sender, e);
            }
        }
    }
}
