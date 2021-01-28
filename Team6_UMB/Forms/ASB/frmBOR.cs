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
using Team6_UMB.Util;
using UMB_VO;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmBOR : Form
    {
        List<BORVO> borList = null;
        int BOR_id, m_id, bor_tattime;
        string product_id, process_name, bor_yn, bor_comment, bor_uadmin, bor_udate,
            product_name, m_name;
        
        public frmBOR()
        {
            InitializeComponent();
            newBtns.btnBarCode.Visible = newBtns.btnDocument.Visible = newBtns.btnShipment.Visible =
                newBtns.btnWait.Visible = newBtns.btnSearch.Visible = newBtns.btnPrint.Visible = false;
        }

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnDelete_Event(object sender, EventArgs e)
        {
            if(BOR_id == 0)
            {
                MessageBox.Show("선택된 항목이 없습니다");
                return;
            }

            try
            {
                BORService service = new BORService();
                bool bResult = service.BORDelete(BOR_id);
                if (bResult)
                {
                    MessageBox.Show("선택항목이 삭제되었습니다");
                }
                else
                {
                    MessageBox.Show("삭제중 오류가 발생했습니다 다시 시도해주세요");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void frmBOR_Load(object sender, EventArgs e)
        {
            string[] gubun = { "공정명" };
            ProductService pService = new ProductService();
            List<ComboItemVO> allProcessItem = pService.GetProcessInfoByCodeTypes(gubun);
            List<ProdCBOBindingVO> allProItem = pService.GetProductInfo();
            MachineService mService = new MachineService();
            List<MachineVO> allMachineItem = mService.GetMachineInfo();


            CommonUtil.ComboBinding(cboProcess, allProcessItem, "공정명");
            CommonUtil.ProdNameBinding(cboProduct, allProItem);
            CommonUtil.MachineNameBinding(cboMachine, allMachineItem);

            CommonUtil.SetInitGridView(dgvBOR);            
            CommonUtil.AddGridTextColumn(dgvBOR, "BOR_ID", "bor_id", 60);
            CommonUtil.AddGridTextColumn(dgvBOR, "품목ID", "product_id", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "품목명", "product_name", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "공정명", "process_name", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "설비ID", "m_id", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "설비명", "m_name", 150);
            CommonUtil.AddGridTextColumn(dgvBOR, "Tact_Time", "bor_tacttime", 150);
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
            BOR_id = m_id = bor_tattime = 0;
            product_id = process_name = bor_yn = bor_comment = bor_uadmin = bor_udate =
                product_name = m_name = "";
            DGV_Binding();
        }

        /// <summary>
        /// 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnCreate_Event(object sender, EventArgs e)
        {
            string headName = "BOR추가";
            frmBORPopup pop = new frmBORPopup(headName);
            pop.ShowDialog();
        }

        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnUpdate_Event(object sender, EventArgs e)
        {
            if (BOR_id == 0)
            {
                MessageBox.Show("수정할 항목을 선택해주세요");
                return;
            }

            string headName = "BOR수정";
            
            frmBORPopup pop = new frmBORPopup(headName, BOR_id, product_name, process_name, m_name,
                bor_tattime, bor_yn, bor_comment, bor_uadmin);
            pop.ShowDialog();
        }

        /// <summary>
        /// 엑셀
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnExcel_Event(object sender, EventArgs e)
        {
            try
            {
                frmLoading frm = new frmLoading(ExportBORList);
                frm.ShowDialog(this);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// 엑셀
        /// </summary>
        private void ExportBORList()
        {
            try
            {
                string sResult = ExcelExportImport.ExportToDataGridView<BORVO>((List<BORVO>)dgvBOR.DataSource, "");
                if (sResult.Length > 0)
                {
                    MessageBox.Show(sResult);
                }
            }
            catch (Exception err) 
            {
                MessageBox.Show(err.Message);
            }
        }

        
        /// <summary>
        /// 조회버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BOR_id = m_id = bor_tattime = 0;
            product_id = process_name = bor_yn = bor_comment = bor_uadmin = bor_udate =
                product_name = m_name = "";

            string pid = "";
            int mid = 0;
            string pname = "";
            if (cboProduct.SelectedIndex > 0)            
                pid = cboProduct.SelectedValue.ToString();
            if (cboMachine.SelectedIndex > 0)
                mid = Convert.ToInt32(cboMachine.SelectedValue);
            if (cboProcess.SelectedIndex > 0)
                pname = cboProcess.SelectedText;
            try
            {
                BORService service = new BORService();
                borList = service.SearchBorList(pid, mid, pname);
                if (borList.Count == 0)
                {
                    MessageBox.Show("조회 결과가 없습니다.");
                    return;
                }
                dgvBOR.DataSource = borList;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        /// <summary>
        /// 데이터그리드뷰 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBOR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {  
                BOR_id = int.Parse(dgvBOR.Rows[e.RowIndex].Cells[0].Value.ToString());
                product_id = dgvBOR.Rows[e.RowIndex].Cells[1].Value.ToString();
                product_name = dgvBOR.Rows[e.RowIndex].Cells[2].Value.ToString();
                process_name = dgvBOR.Rows[e.RowIndex].Cells[3].Value.ToString();
                m_id = int.Parse(dgvBOR.Rows[e.RowIndex].Cells[4].Value.ToString());
                m_name = dgvBOR.Rows[e.RowIndex].Cells[5].Value.ToString();
                bor_tattime = int.Parse(dgvBOR.Rows[e.RowIndex].Cells[6].Value.ToString());                
                bor_yn = dgvBOR.Rows[e.RowIndex].Cells[7].Value.ToString();
                bor_comment = dgvBOR.Rows[e.RowIndex].Cells[8].Value.ToString();
                bor_uadmin = dgvBOR.Rows[e.RowIndex].Cells[9].Value.ToString();
                bor_udate = dgvBOR.Rows[e.RowIndex].Cells[10].Value.ToString();
            }

            
        }
    }
}
