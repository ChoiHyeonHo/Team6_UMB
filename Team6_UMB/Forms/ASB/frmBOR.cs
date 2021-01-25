using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmBOR : Form
    {
        List<BORVO> borList = null;
        public frmBOR()
        {
            InitializeComponent();
        }


        private void frmBOR_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvBOR);
            CommonUtil.AddGridTextColumn(dgvBOR, "BOR_ID", "bor_id", 60);
            CommonUtil.AddGridTextColumn(dgvBOR, "품목명", "product_name", 260);
            CommonUtil.AddGridTextColumn(dgvBOR, "공정명", "process_name", 260);
            CommonUtil.AddGridTextColumn(dgvBOR, "설비명", "m_name", 180);
            CommonUtil.AddGridTextColumn(dgvBOR, "Tact_Time", "bor_tattime", 180);
            CommonUtil.AddGridTextColumn(dgvBOR, "사용유무", "bor_yn", 200);
            CommonUtil.AddGridTextColumn(dgvBOR, "비고", "bor_comment", 200);
            CommonUtil.AddGridTextColumn(dgvBOR, "수정자", "bor_uadmin", 120);
            CommonUtil.AddGridTextColumn(dgvBOR, "수정일", "bor_udate", 120);

            DGV_Binding();
        }

        private void DGV_Binding()
        {
            BORService service = new BORService();
            //borList = service.
            dgvBOR.DataSource = borList;
        }
    }
}
