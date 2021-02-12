using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmShift : Form
    {
        public frmShift()
        {
            InitializeComponent();
        }

        private void frmShift_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvDepartment);
            CommonUtil.AddGridTextColumn(dgvDepartment, "부서번호", "department_id", 150);
        }
    }
}
