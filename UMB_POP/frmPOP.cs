using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UMB_POP
{
    public partial class frmPOP : Form
    {
        //전역변수

        public frmPOP()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Tick += new EventHandler(SystemTimer_Tick);
            t.Start();


        }

        private void SystemTimer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string datePart = dt.ToString("yyyy-MM-dd  hh:mm:ss");
            lb_time.Text = datePart;

        }
    }
}
