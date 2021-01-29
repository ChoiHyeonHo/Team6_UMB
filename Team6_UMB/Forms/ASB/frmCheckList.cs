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

namespace Team6_UMB.Forms.ASB
{
    public partial class frmCheckList : Form
    {
        List<CheckListVO> chkList = null;
        string cl_name, product_id, cl_stnd, cl_comment, cl_uadmin, cl_udate, cl_type, product_name;
        int cl_id;
        public frmCheckList()
        {
            InitializeComponent();
            newBtns.btnBarCode.Visible = newBtns.btnDocument.Visible = newBtns.btnShipment.Visible =
                newBtns.btnWait.Visible = newBtns.btnSearch.Visible = newBtns.btnPrint.Visible = false;
        }
        
        /// <summary>
        /// 폼로드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCheckList_Load(object sender, EventArgs e)
        {
            string[] gubun = { "검사구분" };
            CheckListService cService = new CheckListService();
            List<ComboItemVO> allCheckType = cService.GetCheckTypeInfoByCodeTypes(gubun);

            CommonUtil.ComboBinding(cboCheckType, allCheckType, "검사구분");

            CommonUtil.SetInitGridView(dgvCheckList);
            CommonUtil.AddGridTextColumn(dgvCheckList, "검사ID", "cl_id", 60);
            CommonUtil.AddGridTextColumn(dgvCheckList, "검사명", "cl_name", 150);
            CommonUtil.AddGridTextColumn(dgvCheckList, "품목ID", "product_id", 60);
            CommonUtil.AddGridTextColumn(dgvCheckList, "품목명", "product_name", 150);
            CommonUtil.AddGridTextColumn(dgvCheckList, "검사타입", "cl_type", 120);
            CommonUtil.AddGridTextColumn(dgvCheckList, "기준", "cl_stnd", 100);
            CommonUtil.AddGridTextColumn(dgvCheckList, "비고", "cl_comment", 150);
            CommonUtil.AddGridTextColumn(dgvCheckList, "수정자", "cl_uadmin", 100);
            CommonUtil.AddGridTextColumn(dgvCheckList, "수정일", "cl_udate", 150);            

            DGV_Binding();
        }

        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            cl_name = product_id = cl_stnd = cl_comment = cl_uadmin = cl_udate = cl_type = "";
            cl_id = 0;

            string checkType = "";
            if (cboCheckType.SelectedIndex > 0)
                checkType = cboCheckType.Text;
            try
            {
                CheckListService service = new CheckListService();
                chkList = service.SearchChkList(checkType);
                if (chkList.Count == 0)
                {
                    MessageBox.Show("조회 결과가 없습니다.");
                    return;
                }
                dgvCheckList.DataSource = chkList;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        /// <summary>
        /// DGV 바인딩
        /// </summary>
        private void DGV_Binding()
        {
            CheckListService service = new CheckListService();
            chkList = service.GetChkList();
            dgvCheckList.DataSource = chkList;
        }

        /// <summary>
        /// dgv 셀클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCheckList_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex >= 0)
            {
                cl_id = int.Parse(dgvCheckList.Rows[e.RowIndex].Cells[0].Value.ToString());
                cl_name = dgvCheckList.Rows[e.RowIndex].Cells[1].Value.ToString();
                product_id = dgvCheckList.Rows[e.RowIndex].Cells[2].Value.ToString();
                product_name = dgvCheckList.Rows[e.RowIndex].Cells[3].Value.ToString();
                cl_type = dgvCheckList.Rows[e.RowIndex].Cells[4].Value.ToString();
                cl_stnd = dgvCheckList.Rows[e.RowIndex].Cells[5].Value.ToString();
                cl_comment = dgvCheckList.Rows[e.RowIndex].Cells[6].Value.ToString();
                cl_uadmin = dgvCheckList.Rows[e.RowIndex].Cells[7].Value.ToString();
                cl_udate = dgvCheckList.Rows[e.RowIndex].Cells[8].Value.ToString();                
            }
        }

        private void newBtns_btnDelete_Event(object sender, EventArgs e)
        {
            if (cl_id == 0)
            {
                MessageBox.Show("선택된 항목이 없습니다");
                return;
            }

            try
            {
                CheckListService service = new CheckListService();
                bool bResult = service.ChkDelete(cl_id);
                if (bResult)
                {
                    MessageBox.Show("선택항목이 삭제되었습니다");
                }
                else
                {
                    MessageBox.Show("삭제중 오류가 발생했습니다 다시 시도해주세요");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void newBtns_btnCreate_Event(object sender, EventArgs e)
        {
            string headName = "검사항목등록";
            frmCheckListPopUp pop = new frmCheckListPopUp(headName);
            pop.ShowDialog(); 
        }

        private void newBtns_btnUpdate_Event(object sender, EventArgs e)
        {
            if (cl_id == 0)
            {
                MessageBox.Show("수정할 항목을 선택해주세요");
                return;
            }

            string headName = "검사항목수정";
            
            frmCheckListPopUp pop = new frmCheckListPopUp(headName, cl_id, cl_name, product_id, product_name, cl_stnd, cl_comment, cl_uadmin, cl_type);
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
                frmLoading frm = new frmLoading(ExportCheckList);
                frm.ShowDialog(this);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /// <summary>
        /// 엑셀 Export 함수
        /// </summary>
        private void ExportCheckList()
        {
            try
            {
                string sResult = ExcelExportImport.ExportToDataGridView<CheckListVO>((List<CheckListVO>)dgvCheckList.DataSource, "");
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
        /// 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnRefresh_Event(object sender, EventArgs e)
        {
            cl_name = product_id = cl_stnd = cl_comment = cl_uadmin = cl_udate = cl_type = "";
            cl_id = 0;
            DGV_Binding();
        }

        
    }
}
