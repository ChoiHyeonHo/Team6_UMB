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
    public partial class frmWarehouse : Form
    {
        public frmWarehouse()
        {
            InitializeComponent();
        }

        private void frmWarehouse_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvList);
            CommonUtil.AddGridTextColumn(dgvList, "창고번호", "w_id", 150);
            CommonUtil.AddGridTextColumn(dgvList, "창고명", "w_name", 150);
            CommonUtil.AddGridTextColumn(dgvList, "창고주소", "w_address", 150);
            CommonUtil.AddGridTextColumn(dgvList, "창고구분", "w_type", 150);
            CommonUtil.AddGridTextColumn(dgvList, "사용유무", "w_deleted", 150);
            CommonUtil.AddGridTextColumn(dgvList, "수정자", "w_uadmin", 150);
            CommonUtil.AddGridTextColumn(dgvList, "수정일", "w_udate", 150);


        }
    }
}
