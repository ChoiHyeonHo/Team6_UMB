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
    public partial class frmProdInspection : Team6_UMB.frmBaseList
    {
        ProdInsService service = new ProdInsService();
        List<ProdInsVO> allList;
        CheckBox headerCheck = new CheckBox();

        #region 생성자
        public frmProdInspection(bool Authority)
        {
            InitializeComponent();
            newBtns1.btnCreate.Text = "검사";
            newBtns1.btnBarCode.Visible = newBtns1.btnDelete.Visible = newBtns1.btnDocument.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnUpdate.Visible = newBtns1.btnWait.Visible = false;

            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();

            if (Authority == false)
            {
                newBtns1.btnCreate.Visible = false;
                newBtns1.btnUpdate.Visible = false;
                newBtns1.btnDelete.Visible = false;
            }
        }
        #endregion

        #region Form Load Event
        /// <summary>
        /// 그리드뷰에 체크박스 바인딩
        /// 컬럼 헤더 텍스트 바인딩
        /// 데이터 조회해서 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProdInspection_Load(object sender, EventArgs e)
        {
            try
            {
                dgvProdCheck.AutoGenerateColumns = false;
                dgvProdCheck.AllowUserToAddRows = false;
                dgvProdCheck.MultiSelect = false;
                dgvProdCheck.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "";
                chk.Name = "chk";
                chk.Width = 30;
                dgvProdCheck.Columns.Add(chk);

                Point point = dgvProdCheck.GetCellDisplayRectangle(0, -1, true).Location;

                headerCheck.Location = new Point(point.X + 8, point.Y + 2);
                headerCheck.BackColor = Color.White;
                headerCheck.Size = new Size(18, 18);
                headerCheck.Click += HeaderCheck_Click;
                dgvProdCheck.Controls.Add(headerCheck);

                CommonUtil.SetInitGridView(dgvProdCheck);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "생산번호", "production_id", 90);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "작업지시번호", "wo_id", 100);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "수주번호", "so_id", 90);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "품목코드", "product_id", 150);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "품목명", "product_name", 150);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "출하상태", "ship_state", 200);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "생산상태", "production_state", 200);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "납기일", "so_edate", 150);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "출하번호", "ship_id", 150);
                CommonUtil.AddGridTextColumn(dgvProdCheck, "생산량", "production_QtyReleased", 150);
                DGVBinding();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region DGV Binding
        private void DGVBinding()
        {
            try
            {
                allList = service.GetProdInsInfo();
                dgvProdCheck.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 컬럼헤더 체크박스 클릭
        /// <summary>
        /// EndEdit() 를 통해 현재 포커스가 있는 셀의 편집을 종료
        /// foreach문을 돌면서 체크박스의 Value를 Checked로 변경
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProdCheck.EndEdit();

                foreach (DataGridViewRow row in dgvProdCheck.Rows)
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

        #region 등록버튼
        /// <summary>
        /// 체크박스가 Checked인 것의 출하ID를 List에 담는다
        /// List에 담긴 ID들을 string.Join의 "," 사용해서 쿼리문의 Where in()에 담길 문자열로 변환
        /// 문자열을 팝업폼의 파라미터로 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            try
            {
                List<int> chkBarCodeList = new List<int>();
                foreach (DataGridViewRow row in dgvProdCheck.Rows)
                {
                    bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                    if (bCheck)
                    {
                        chkBarCodeList.Add(int.Parse(row.Cells["ship_id"].Value.ToString()));
                    }
                }
                string temp = string.Join(",", chkBarCodeList);
                frmProdInspPopUp frm = new frmProdInspPopUp(temp);
                frm.Show();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }
        #endregion

        #region 검색조건 기간조회
        /// <summary>
        /// 납기일이 FromDate와 ToDate의 사이에 있어야 함
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void periodSearchControl2_ChangedPeriod(object sender, EventArgs e)
        {
            try
            {
                if (dgvProdCheck.DataSource != null)
                {
                    if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                    {
                        string FromDate = periodSearchControl.dtFrom;
                        string ToDate = periodSearchControl.dtTo;

                        List<ProdInsVO> periodList = (from period in allList
                                                      where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(period.so_edate) && Convert.ToDateTime(period.so_edate) <= Convert.ToDateTime(ToDate)
                                                      select period).ToList();
                        dgvProdCheck.DataSource = periodList;
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
