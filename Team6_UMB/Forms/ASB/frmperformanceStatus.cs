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
    public partial class frmperformanceStatus : Form
    {
        List<PerformanceVO> perList = null;

        public frmperformanceStatus()
        {
            InitializeComponent();

            newBtns1.btnCreate.Visible = newBtns1.btnDelete.Visible = newBtns1.btnUpdate.Visible =
                newBtns1.btnBarCode.Visible = newBtns1.btnDocument.Visible = newBtns1.btnSearch.Visible = newBtns1.btnBarCode.Visible =
                newBtns1.btnShipment.Visible = newBtns1.btnWait.Visible = newBtns1.btnPrint.Visible = false;

            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();
        }

        private void frmperformanceStatus_Load(object sender, EventArgs e)
        {
            //품목명바인딩, 공정명바인딩            
            string[] gubun = { "공정명" };
            ProductService processService = new ProductService();
            List<ComboItemVO> allProcessItem = processService.GetProcessInfoByCodeTypes(gubun);
            ProductService productService = new ProductService();            
            List<ProdCBOBindingVO> allProItem = productService.GetProductInfo();

            CommonUtil.ComboBinding(cboProcess, allProcessItem, "공정명");
            CommonUtil.ProdNameBinding(cboProduct, allProItem);

            //performance_id, production_id, product_id, process_name, performance_qty_ok, performance_qty_ng, performance_qtyimport
            //production_state, production_sdate
            CommonUtil.SetInitGridView(dgvPerformance);
            CommonUtil.AddGridTextColumn(dgvPerformance, "실적ID", "performance_id", 80);
            CommonUtil.AddGridTextColumn(dgvPerformance, "생산ID", "production_id", 80);
            CommonUtil.AddGridTextColumn(dgvPerformance, "품목ID", "product_id", 120);
            CommonUtil.AddGridTextColumn(dgvPerformance, "품목명", "product_name", 120);
            CommonUtil.AddGridTextColumn(dgvPerformance, "공정명", "process_name", 120);
            CommonUtil.AddGridTextColumn(dgvPerformance, "양품수량", "performance_qty_ok", 100);
            CommonUtil.AddGridTextColumn(dgvPerformance, "불량수량", "performance_qty_ng", 100);
            CommonUtil.AddGridTextColumn(dgvPerformance, "생산용청수량", "performance_qtyimport", 120);
            CommonUtil.AddGridTextColumn(dgvPerformance, "상태", "production_state", 120);
            CommonUtil.AddGridTextColumn(dgvPerformance, "생산시작일", "production_sdate", 120);

            DGV_Binding();
        }

        private void periodSearchControl_ChangedPeriod(object sender, EventArgs e)
        {
            if (dgvPerformance.DataSource != null)
            {
                if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                {
                    string FromDate = periodSearchControl.dtFrom;
                    string ToDate = periodSearchControl.dtTo;

                    List<PerformanceVO> PerformanceList = (from per in perList
                                                       where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(per.production_sdate) &&
                                                       Convert.ToDateTime(per.production_sdate) <= Convert.ToDateTime(ToDate)
                                                       select per).ToList();
                    dgvPerformance.DataSource = PerformanceList;
                }
            }
        }

        private void DGV_Binding()
        {
            PerformanceService service = new PerformanceService();
            perList = service.GetPerList();
            dgvPerformance.DataSource = perList;
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGV_Binding();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string pid = "";
            string process = "";

            if (cboProduct.SelectedIndex > 0)
                pid = cboProduct.SelectedValue.ToString();
            if (cboProcess.SelectedIndex > 0)
                process = cboProcess.Text;

            try
            {
                PerformanceService service = new PerformanceService();
                perList = service.SearchPerList(pid, process);

                string FromDate = periodSearchControl.dtFrom;
                string ToDate = periodSearchControl.dtTo;

                List<PerformanceVO> PerformanceList = (from per in perList
                                                       where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(per.production_sdate) &&
                                                       Convert.ToDateTime(per.production_sdate) <= Convert.ToDateTime(ToDate)
                                                       select per).ToList();
                dgvPerformance.DataSource = PerformanceList;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void newBtns1_btnExcel_Event(object sender, EventArgs e)
        {
            try
            {
                frmLoading frm = new frmLoading(ExportPerList);
                frm.ShowDialog(this);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void ExportPerList()
        {
            try
            {
                string sResult = ExcelExportImport.ExportToDataGridView<PerformanceVO>((List<PerformanceVO>)dgvPerformance.DataSource, "");
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
    }
}
