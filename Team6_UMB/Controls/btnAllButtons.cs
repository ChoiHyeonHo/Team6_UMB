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

        public btnAllButtons()
        {
            InitializeComponent();
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
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
