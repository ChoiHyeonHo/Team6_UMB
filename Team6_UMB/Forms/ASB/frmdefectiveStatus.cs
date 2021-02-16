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
using UMB_VO.ASB;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.BMN
{
    public partial class frmdefectiveStatus : Form
    {
        List<DefectiveVO> defectiveList = null;

        public frmdefectiveStatus()
        {
            InitializeComponent();
            newBtns1.btnBarCode.Visible = newBtns1.btnDocument.Visible = newBtns1.btnShipment.Visible =
                newBtns1.btnWait.Visible = newBtns1.btnSearch.Visible = newBtns1.btnPrint.Visible = false;

            periodSearchControl1.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl1.dtTo = DateTime.Now.ToString();
        }

        private void periodSearchControl_ChangedPeriod(object sender, EventArgs e)
        {
            if (dgvStatus.DataSource != null)
            {
                if (periodSearchControl1.dtFrom != DateTime.Now.ToShortDateString())
                {
                    string FromDate = periodSearchControl1.dtFrom;
                    string ToDate = periodSearchControl1.dtTo;

                    List<DefectiveVO> defList = (from def in defectiveList
                                                 where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(def.defective_stime)
                                                 select def).ToList();
                    dgvStatus.DataSource = defList;
                }
            }
        }

        private void frmdefectiveStatus_Load(object sender, EventArgs e)
        {
            string[] gubun = { "공정명" };
            ProductService pService = new ProductService();
            List<ComboItemVO> allProcessItem = pService.GetProcessInfoByCodeTypes(gubun);
            List<ProdCBOBindingVO> allProItem = pService.GetProductInfo();
                       
            CommonUtil.ComboBinding(cboProcess, allProcessItem, "공정명");
            CommonUtil.ProdNameBinding(cboProduct, allProItem);           

            CommonUtil.SetInitGridView(dgvStatus);
            CommonUtil.AddGridTextColumn(dgvStatus, "불량이력ID", "defective_ID", 120);
            CommonUtil.AddGridTextColumn(dgvStatus, "품목코드", "product_id", 120);
            CommonUtil.AddGridTextColumn(dgvStatus, "품목명", "product_name", 120);
            CommonUtil.AddGridTextColumn(dgvStatus, "공정명", "process_name", 120);
            CommonUtil.AddGridTextColumn(dgvStatus, "발생시간", "defective_stime", 150);
            CommonUtil.AddGridTextColumn(dgvStatus, "생산실적ID", "performance_id", 100);
            CommonUtil.AddGridTextColumn(dgvStatus, "불량명", "common_name", 150);
            CommonUtil.AddGridTextColumn(dgvStatus, "불량갯수", "defective_count", 100);
            
            DGV_Binding();
        }

        private void DGV_Binding()
        {
            DefService service = new DefService();
            defectiveList = service.GetDefStatus();
            dgvStatus.DataSource = defectiveList;
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            periodSearchControl1.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl1.dtTo = DateTime.Now.ToString();
            cboProduct.SelectedIndex = 0;
            cboProcess.SelectedIndex = 0;
            DGV_Binding();
        }

        private void newBtns1_btnExcel_Event(object sender, EventArgs e)
        {
            try
            {
                frmLoading frm = new frmLoading(ExportWorkList);
                frm.ShowDialog(this);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void ExportWorkList()
        {
            try
            {
                string sResult = ExcelExportImport.ExportToDataGridView<DefectiveVO>((List<DefectiveVO>)dgvStatus.DataSource, "");
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

        private void newBtns1_btnPrint_Event(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            string pid = "";           
            string pname = "";
            if (cboProduct.SelectedIndex > 0)
                pid = cboProduct.SelectedValue.ToString();
            if (cboProcess.SelectedIndex > 0)
                pname = cboProcess.Text;
            try
            {
                DefService service = new DefService();
                defectiveList = service.SearchDefList(pid, pname);

                string FromDate = periodSearchControl1.dtFrom;
                string ToDate = periodSearchControl1.dtTo;

                List<DefectiveVO> defList = (from def in defectiveList
                                             where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(def.defective_stime)
                                             select def).ToList();
                dgvStatus.DataSource = defList;
                if (defectiveList.Count == 0)
                {
                    MessageBox.Show("조회 결과가 없습니다.");
                    return;
                }
                dgvStatus.DataSource = defectiveList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
