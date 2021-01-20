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
    public partial class btnSearchExcelPrint : UserControl
    {
        public event EventHandler btnSearch_Event;
        public btnSearchExcelPrint()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (this.btnSearch_Event != null)
            {
                btnSearch_Event(sender, e);
            }
        }
    }
}
