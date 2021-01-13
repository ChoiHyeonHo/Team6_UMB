using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team6_UMB
{
    public partial class DGV_Custom : DataGridView
    {
        public DGV_Custom()
        {
            InitializeComponent();
            SetNomalValues();
        }

        private void SetNomalValues()
        {
            this.BorderStyle = BorderStyle.None;
            this.GridColor = Color.LightGray;
            this.Margin = new Padding(4, 1, 4, 1);
            this.Padding = new Padding(4);
            this.MinimumSize = new Size(150, 150);
            this.Cursor = Cursors.Arrow;
            this.ScrollBars = ScrollBars.Vertical;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("나눔바른고딕", 9, FontStyle.Regular);
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersHeight = 40;
            this.BackgroundColor = Color.White;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
