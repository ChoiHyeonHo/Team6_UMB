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

namespace Team6_UMB.Forms
{
    public partial class frmWorkOrderRegi : Form
    {


        // wo_id, so_id, product_id, product_name, m_id, m_name, wo_pcount, wo_count, wo_date, wo_sdate, wo_state, wo_uadmin, wo_udate
        List<WorkOrderVO> woList = null;
        CheckBox headerCheck = new CheckBox();
        

        public frmWorkOrderRegi()
        {
            InitializeComponent();

            newBtns1.btnCreate.Visible = newBtns1.btnDelete.Visible = newBtns1.btnUpdate.Visible =
                newBtns1.btnBarCode.Visible = newBtns1.btnDocument.Visible = newBtns1.btnSearch.Visible = newBtns1.btnBarCode.Visible =
                newBtns1.btnShipment.Visible = newBtns1.btnWait.Visible = newBtns1.btnPrint.Visible = false;


            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();
            
        }
        private void periodSearchControl_ChangedPeriod(object sender, EventArgs e)
        {
            if (dgvOrder.DataSource != null)
            {
                if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                {
                    string FromDate = periodSearchControl.dtFrom;
                    string ToDate = periodSearchControl.dtTo;

                    List<WorkOrderVO> WorkOrderList = (from wo in woList
                                                        where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(wo.wo_date) &&
                                                        Convert.ToDateTime(wo.wo_date) <= Convert.ToDateTime(ToDate)
                                                        select wo).ToList();
                    dgvOrder.DataSource = WorkOrderList;
                }
            }
        }

        private void frmWorkOrderRegi_Load(object sender, EventArgs e)
        {
            //품목명바인딩, 생산상태 바인딩
            string[] gubun = { "생산상태" };
            ProductService pService = new ProductService();
            List<ComboItemVO> allState = pService.GetProcessInfoByCodeTypes(gubun);
            List<ProdCBOBindingVO> allProItem = pService.GetProductInfo();
            CommonUtil.ProdNameBinding(cboProductName, allProItem);
            CommonUtil.ComboBinding(cboState, allState, "생산상태");

            //데이터그리드뷰 컬럼 추가
            dgvOrder.AutoGenerateColumns = false;
            dgvOrder.AllowUserToAddRows = false;
            dgvOrder.MultiSelect = false;
            dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvOrder.Columns.Add(chk);

            //Header체크 속성추가
            Point point = dgvOrder.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheck.Location = new Point(point.X + 8, point.Y + 2);
            headerCheck.BackColor = Color.White;
            headerCheck.Size = new Size(18, 18);
            headerCheck.Click += HeaderCheck_Click;
            dgvOrder.Controls.Add(headerCheck);

            
            CommonUtil.SetInitGridView(dgvOrder);
            CommonUtil.AddGridTextColumn(dgvOrder, "WO_NUM", "wo_id", 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "수주번호", "so_id", 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "제품ID", "product_id", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "제품명", "product_name", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "설비ID", "m_id", 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "설비명", "m_name", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "수주량", "wo_pcount", 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "지시량", "wo_count", 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "지시일", "wo_date", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업시작일", "wo_sdate", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "상태", "wo_state", 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "수정자", "wo_uadmin", 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "수정일", "wo_udate", 120);

            

            
            DGV_Binding(dgvOrder);
            
        }

        private void DGV_Binding(DataGridView dgv)
        {
            WorkOrderService service = new WorkOrderService();
            woList = service.GetWoList();
            dgv.DataSource = woList;
        }

        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            dgvOrder.EndEdit(); //현재 포커스가 있는 셀의 편집을 종료 (다른 셀로 이동시킨 것과 같은 효과)

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                chk.Value = headerCheck.Checked;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string pid = "";
            string state = "";
            
            if (cboProductName.SelectedIndex > 0)
                pid = cboProductName.SelectedValue.ToString();
            if (cboState.SelectedIndex > 0)
                state = cboState.Text;

            try
            {
                WorkOrderService service = new WorkOrderService();
                woList = service.SearchWOList(pid, state);
                
                string FromDate = periodSearchControl.dtFrom;
                string ToDate = periodSearchControl.dtTo;

                List<WorkOrderVO> WorkOrderList = (from wo in woList
                                                   where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(wo.wo_date) &&
                                                   Convert.ToDateTime(wo.wo_date) <= Convert.ToDateTime(ToDate)
                                                   select wo).ToList();
                dgvOrder.DataSource = WorkOrderList;
                
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// 작업지시확정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrderComplete_Click(object sender, EventArgs e)
        {
            //생산실적 생성
            List<int> chkWOList = new List<int>();

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                if (bCheck)
                {
                    //wo_state
                    if (row.Cells["wo_state"].Value.ToString() == "작업지시대기")
                    {
                        chkWOList.Add(Convert.ToInt32(row.Cells["wo_id"].Value));
                    }
                    else
                    {
                        MessageBox.Show("작업지시대기상태만 확정시킬 수 있습니다. ");
                        return;
                    }
                    
                }
            }

            WorkOrderService service = new WorkOrderService();
            bool bResult = service.updateWOState(chkWOList);
            if (bResult)
            {
                MessageBox.Show($"{chkWOList.Count}개의 작업지시를 확정하였습니다.");
            }
            else
            {
                MessageBox.Show("작업지시가 확정되지 않았습니다 다시 시도하여주세요.");
            }

            DGV_Binding(dgvOrder);
        }

        /// <summary>
        /// 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();
            cboProductName.SelectedIndex = 0;
            DGV_Binding(dgvOrder);
            
        }

        /// <summary>
        /// 엑셀
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                string sResult = ExcelExportImport.ExportToDataGridView<WorkOrderVO>((List<WorkOrderVO>)dgvOrder.DataSource, "");
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
