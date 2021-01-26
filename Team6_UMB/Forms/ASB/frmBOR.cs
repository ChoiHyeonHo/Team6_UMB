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
using UMB_VO.CHH;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmBOR : Form
    {
        List<BORVO> borList = null;
        public frmBOR()
        {
            InitializeComponent();
            newBtns.btnBarCode.Visible = newBtns.btnDocument.Visible = newBtns.btnShipment.Visible =
                newBtns.btnWait.Visible = newBtns.btnSearch.Visible = newBtns.btnPrint.Visible = false;
        }


        private void frmBOR_Load(object sender, EventArgs e)
        {
            string[] gubun = { "공정명" };
            ProductService pService = new ProductService();
            List<ComboItemVO> allProcessItem = pService.GetProcessInfoByCodeTypes(gubun);
            List<ProdCBOBindingVO> allProItem = pService.GetProductInfo();

            CommonUtil.ComboBinding(cboProcess, allProcessItem, "공정명");
            CommonUtil.ProdNameBinding(cboProduct, allProItem);

            CommonUtil.SetInitGridView(dgvBOR);
            CommonUtil.AddGridTextColumn(dgvBOR, "BOR_ID", "bor_id", 60);
            CommonUtil.AddGridTextColumn(dgvBOR, "품목ID", "product_id", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "품목명", "product_name", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "공정명", "process_name", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "설비ID", "m_id", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "설비명", "m_name", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "Tact_Time", "bor_tattime", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "사용유무", "bor_yn", 60);
            CommonUtil.AddGridTextColumn(dgvBOR, "비고", "bor_comment", 200);
            CommonUtil.AddGridTextColumn(dgvBOR, "수정자", "bor_uadmin", 120);
            CommonUtil.AddGridTextColumn(dgvBOR, "수정일", "bor_udate", 120);

            DGV_Binding();
        }

        private void DGV_Binding()
        {
            BORService service = new BORService();
            borList = service.GetBORList();
            dgvBOR.DataSource = borList;
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGV_Binding();
        }
    }
}
