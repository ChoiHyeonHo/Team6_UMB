using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using Team6_UMB.Util;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmCheckHistory : Team6_UMB.frmBaseList
    {
        CheckHistoryService service = new CheckHistoryService();
        List<CheckHistoryVO> allList;
        List<GetCheckTypeVO> check;
        string checkType;

        public frmCheckHistory()
        {
            InitializeComponent();
            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();

            newBtns1.btnBarCode.Visible = newBtns1.btnCreate.Visible = newBtns1.btnDelete.Visible = newBtns1.btnDocument.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnUpdate.Visible = newBtns1.btnWait.Visible = false;
        }

        #region Form Load Event
        /// <summary>
        /// 컬럼 헤더를 바인딩하고 DB에서 조회.
        /// 수입검사인지 제품검사 구분을 콤보박스에 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCheckHistory_Load(object sender, EventArgs e)
        {
            try
            {
                CommonUtil.SetInitGridView(dgvCheckHistory);
                CommonUtil.AddGridTextColumn(dgvCheckHistory, "이력번호", "ch_id", 160);
                CommonUtil.AddGridTextColumn(dgvCheckHistory, "검사항목", "ch_item", 250);
                CommonUtil.AddGridTextColumn(dgvCheckHistory, "품목코드", "product_id", 160);
                CommonUtil.AddGridTextColumn(dgvCheckHistory, "검사일", "ch_date", 160);
                CommonUtil.AddGridTextColumn(dgvCheckHistory, "검사구분", "ch_type", 160);
                CommonUtil.AddGridTextColumn(dgvCheckHistory, "비고", "ch_comment", 250);
                CommonUtil.AddGridTextColumn(dgvCheckHistory, "제품검사ID", "cl_ship_id", 150);
                CommonUtil.AddGridTextColumn(dgvCheckHistory, "수입검사ID", "cl_inc_id", 150);
                DGVBinding();

                check = service.GetCheckTypeComboBox();
                CommonUtil.CheckHis_CheckTypeBinding(cbCheckType, check);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region DGV Binding
        /// <summary>
        /// 데이터그리드뷰 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        private void DGVBinding()
        {
            try
            {
                allList = service.GetCheckHisInfo();
                dgvCheckHistory.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 기간조회 검색조건
        /// <summary>
        /// 검색조건의 기간이 변경되면 DataGridView의 데이터 소스를 바꿔준다.
        /// 검사일이 FromDate와 ToDate의 사이에 위치해야 함.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void periodSearchControl_ChangedPeriod(object sender, EventArgs e)
        {
            try
            {
                if (dgvCheckHistory.DataSource != null)
                {
                    if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                    {
                        string FromDate = periodSearchControl.dtFrom;
                        string ToDate = periodSearchControl.dtTo;

                        List<CheckHistoryVO> periodList = (from period in allList
                                                           where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(period.ch_date) && Convert.ToDateTime(period.ch_date) <= Convert.ToDateTime(ToDate)
                                                           select period).ToList();
                        dgvCheckHistory.DataSource = periodList;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 검색버튼
        /// <summary>
        /// 검사구분 콤보박스의 내용을 checkType 변수에 담아 DAC단의 파라미터로 넘김
        /// 조회된 값을 DGV의 데이터소스로 받아온다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                checkType = cbCheckType.Text.ToString();
                allList = service.GetCheckHisInfoWhere(checkType);
                dgvCheckHistory.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 엑셀버튼
        private void newBtns1_btnExcel_Event(object sender, EventArgs e)
        {
            try
            {
                frmLoading frm = new frmLoading(ExportCustomerList);
                frm.ShowDialog(this);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void ExportCustomerList()
        {
            try
            {
                string sResult = ExcelExportImport.ExportToDataGridView<CheckHistoryVO>((List<CheckHistoryVO>)dgvCheckHistory.DataSource, "");
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
        #endregion

        #region 새로고침 버튼
        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            try
            {
                DGVBinding();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion
    }
}
