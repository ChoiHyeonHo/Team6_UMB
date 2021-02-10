using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmImportInspection : Team6_UMB.frmBaseList
    {
        ProdImpInsService service = new ProdImpInsService();
        List<ProdImpInsVO> allList;
        CheckBox headerCheck = new CheckBox();

        #region 생성자
        public frmImportInspection()
        {
            InitializeComponent();
            newBtns1.btnCreate.Text = "검사";
            newBtns1.btnBarCode.Visible = newBtns1.btnDelete.Visible = newBtns1.btnDocument.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnUpdate.Visible = newBtns1.btnWait.Visible = false;

            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();
        }
        #endregion

        #region Form Load Event
        /// <summary>
        /// 그리드뷰에 체크박스 바인딩
        /// 컬럼 헤더 텍스트 바인딩 후 데이터 조회
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmImportInspection_Load(object sender, EventArgs e)
        {
            try
            {
                dgvIncomming.AutoGenerateColumns = false;
                dgvIncomming.AllowUserToAddRows = false;
                dgvIncomming.MultiSelect = false;
                dgvIncomming.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "";
                chk.Name = "chk";
                chk.Width = 30;
                dgvIncomming.Columns.Add(chk);

                Point point = dgvIncomming.GetCellDisplayRectangle(0, -1, true).Location;

                headerCheck.Location = new Point(point.X + 8, point.Y + 2);
                headerCheck.BackColor = Color.White;
                headerCheck.Size = new Size(18, 18);
                headerCheck.Click += HeaderCheck_Click;
                dgvIncomming.Controls.Add(headerCheck);

                CommonUtil.SetInitGridView(dgvIncomming);
                CommonUtil.AddGridTextColumn(dgvIncomming, "입고번호", "incomming_ID", 80);
                CommonUtil.AddGridTextColumn(dgvIncomming, "발주번호", "order_id", 100);
                CommonUtil.AddGridTextColumn(dgvIncomming, "품목코드", "product_id", 100);
                CommonUtil.AddGridTextColumn(dgvIncomming, "품목명", "product_name", 100);
                CommonUtil.AddGridTextColumn(dgvIncomming, "입고상태", "incomming_state", 100);
                CommonUtil.AddGridTextColumn(dgvIncomming, "입고일", "incomming_date", 150);
                CommonUtil.AddGridTextColumn(dgvIncomming, "담당자", "incomming_rep", 150);
                CommonUtil.AddGridTextColumn(dgvIncomming, "입고량", "incomming_count", 150);
                CommonUtil.AddGridTextColumn(dgvIncomming, "합불판정", "orderexam_result", 100);
                CommonUtil.AddGridTextColumn(dgvIncomming, "수정자", "incomming_uadmin", 150);
                CommonUtil.AddGridTextColumn(dgvIncomming, "수정일", "incomming_udate", 150);
                DGVBinding();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region DGV Binding
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        private void DGVBinding()
        {
            try
            {
                allList = service.GetIncomminInfo();
                dgvIncomming.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 컬럼헤더의 체크박스 클릭
        /// <summary>
        /// EndEdit()를 통해 현재 포커스가 있는 셀의 편집을 종료한다.
        /// foreach문을 돌면서 선택된 체크박스가 있는 셀의 index를 List에 담는다
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIncomming.EndEdit();

                foreach (DataGridViewRow row in dgvIncomming.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                    chk.Value = headerCheck.Checked;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 검사 버튼
        /// <summary>
        /// foreach문을 돌며 체크된 셀의 입고번호 id 를 List에 담는다
        /// List에 담긴 id값들에 ","를 붙여 문자열 temp에 담는다
        /// DAC단의 파라미터로 temp를 넘기고 선택된 id값들을 조회하여 ImpInspecPopUp 폼의 생성자에 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            try
            {
                List<int> chkBarCodeList = new List<int>();
                foreach (DataGridViewRow row in dgvIncomming.Rows)
                {
                    bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                    if (bCheck)
                    {
                        chkBarCodeList.Add(int.Parse(row.Cells["incomming_ID"].Value.ToString()));
                    }
                }
                string temp = string.Join(",", chkBarCodeList);
                frmImpInspecPopUp frm = new frmImpInspecPopUp(temp);
                frm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 새로고침 버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }
        #endregion

        #region 검색조건 기간조회 내용 변경시
        /// <summary>
        /// 입고일이 FromDate와 ToDate 사이에 위치한 것을 DGV의 DataSource로 준다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void periodSearchControl_ChangedPeriod(object sender, EventArgs e)
        {
            try
            {
                if (dgvIncomming.DataSource != null)
                {
                    if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                    {
                        string FromDate = periodSearchControl.dtFrom;
                        string ToDate = periodSearchControl.dtTo;

                        List<ProdImpInsVO> periodList = (from period in allList
                                                         where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(period.incomming_date) && Convert.ToDateTime(period.incomming_date) <= Convert.ToDateTime(ToDate)
                                                         select period).ToList();
                        dgvIncomming.DataSource = periodList;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion
    }
}
