using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using Team6_UMB.Util;
using UMB_VO.CHH;
using Team6_UMB.Dev;

namespace Team6_UMB.Forms
{
    public partial class frmProductManage : Team6_UMB.frmBaseList
    {
        ProdStatusService service;
        List<ProdStatusVO> allList;
        List<GetProdNameVO> prodName;
        List<GetCompanyNameVO> companyName;
        List<GetWHNameVO> whName;
        CheckBox headerCheck = new CheckBox();

        int product_lorder_count, product_safety_count, company_id, w_id;
        string product_id, product_name, product_type, product_unit, w_name, company_name, product_exam, product_stnd, product_comment, product_deleted;
        string cbpName, cbpType, cbpCompany, cbpWH, cbpExam;

        #region 생성자
        public frmProductManage()
        {
            InitializeComponent();
            newBtns.btnShipment.Visible = newBtns.btnWait.Visible = newBtns.btnSearch.Visible = newBtns.btnDocument.Visible = false;
        }
        #endregion

        #region Form Load Event
        /// <summary>
        /// 컬럼헤더 체크박스 바인딩
        /// 컬럼헤더 텍스트 바인딩
        /// 데이터 조회하여 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProductManage_Load(object sender, EventArgs e)
        {
            try
            {
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.AllowUserToAddRows = false;
                dgvProduct.MultiSelect = false;
                dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "";
                chk.Name = "chk";
                chk.Width = 30;
                dgvProduct.Columns.Add(chk);

                Point point = dgvProduct.GetCellDisplayRectangle(0, -1, true).Location;

                headerCheck.Location = new Point(point.X + 8, point.Y + 2);
                headerCheck.BackColor = Color.White;
                headerCheck.Size = new Size(18, 18);
                headerCheck.Click += HeaderCheck_Click;
                dgvProduct.Controls.Add(headerCheck);

                #region 그리드뷰 컬럼헤더 바인딩
                CommonUtil.SetInitGridView(dgvProduct);
                CommonUtil.AddGridTextColumn(dgvProduct, "번호", "product_id", 60);                   //1
                CommonUtil.AddGridTextColumn(dgvProduct, "품목명", "product_name", 150);              //2
                CommonUtil.AddGridTextColumn(dgvProduct, "제품분류", "product_type", 100);            //3
                CommonUtil.AddGridTextColumn(dgvProduct, "단위", "product_unit", 100);                //4
                CommonUtil.AddGridTextColumn(dgvProduct, "창고명", "w_name", 150);                    //5
                CommonUtil.AddGridTextColumn(dgvProduct, "최소발주량", "product_lorder_count", 100);  //6
                CommonUtil.AddGridTextColumn(dgvProduct, "안전재고량", "product_safety_count", 100);  //7
                CommonUtil.AddGridTextColumn(dgvProduct, "업체명", "company_name", 170);              //8
                CommonUtil.AddGridTextColumn(dgvProduct, "검사여부", "product_exam", 90);             //9
                CommonUtil.AddGridTextColumn(dgvProduct, "규격", "product_stnd", 130);               //10
                CommonUtil.AddGridTextColumn(dgvProduct, "비고", "product_comment", 10, false);      //11
                CommonUtil.AddGridTextColumn(dgvProduct, "삭제여부", "product_deleted", 90);          //12
                CommonUtil.AddGridTextColumn(dgvProduct, "거래처id", "company_id", 10, false);        //13
                CommonUtil.AddGridTextColumn(dgvProduct, "창고id", "w_id", 10, false);                //14
                #endregion

                SearchCBBinding();
                DGV_Binding();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 엑셀버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnExcel_Event(object sender, EventArgs e)
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
                string sResult = ExcelExportImport.ExportToDataGridView<ProdStatusVO>((List<ProdStatusVO>)dgvProduct.DataSource, "");
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

        #region 출력버튼
        /// <summary>
        /// 현재 그리드뷰의 내용을 DEV의 ReportPreview에 담아 호출
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnPrint_Event(object sender, EventArgs e)
        {
            try
            {
                ProductStautsReport rpt = new ProductStautsReport();
                rpt.DataSource = allList;

                frmReportPreview frm = new frmReportPreview(rpt);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 바코드 버튼
        /// <summary>
        /// 체크된 행의 품목ID를 List에 담는다
        /// List에 담긴 품목ID를 string.Join(",")을 사용해 쿼리문의 Where in()절에 담을 문자열로 변환
        /// DAC단의 파라미터로 문자열을 넘기고 결과를 DEV의 ReportPreview로 받는다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnBarCode_Event(object sender, EventArgs e)
        {
            try
            {
                List<string> chkBarCodeList = new List<string>();

                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                    if (bCheck)
                    {
                        chkBarCodeList.Add(row.Cells["product_id"].Value.ToString());
                    }
                }
                string temp = string.Join("','", chkBarCodeList);
                ProdStatusBarCode rpt = new ProdStatusBarCode();
                rpt.DataSource = service.GetBarCode(temp);
                frmReportPreview frm = new frmReportPreview(rpt);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 검색버튼
        /// <summary>
        /// 전역에 선언한 변수들을 string.Empty로 줌으로써 초기값설정
        /// 각 콤보박스의 선택된 Index가 0이상일 경우 변수에 담는다
        /// DAC단의 파라미터로 변수들을 담아 데이터소스로 호출
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                cbpName = cbpType = cbpCompany = cbpWH = cbpExam = string.Empty;
                if (cbProdName.SelectedIndex > 0)
                    cbpName = cbProdName.Text;
                if (cbProdType.SelectedIndex > 0)
                    cbpType = cbProdType.Text;
                if (cbCompanyName.SelectedIndex > 0)
                    cbpCompany = cbCompanyName.Text;
                if (cbWHName.SelectedIndex > 0)
                    cbpWH = cbWHName.Text;
                if (cbExamYN.SelectedIndex > 0)
                    cbpExam = cbExamYN.Text;

                service = new ProdStatusService();
                allList = service.GetWhereInfo(cbpName, cbpType, cbpCompany, cbpWH, cbpExam);
                dgvProduct.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 컬럼헤더 체크박스
        /// <summary>
        /// EndEdit()를 통해 현재 포커스가 있는 셀의 편집을 종료
        /// foreach문을 돌면서 Value를 Checked로 변경
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProduct.EndEdit(); //현재 포커스가 있는 셀의 편집을 종료(다른 셀로 이동시키는것과 같은 효과)

                foreach (DataGridViewRow row in dgvProduct.Rows)
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

        #region 검색조건 콤보박스 바인딩
        /// <summary>
        /// 품목명, 거래처명, 창고명 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        private void SearchCBBinding()
        {
            try
            {
                service = new ProdStatusService();
                prodName = service.GetProdName();
                CommonUtil.ProdStatus_ProdNameBinding(cbProdName, prodName);

                companyName = service.GetCompanyName();
                CommonUtil.ProdStatus_CompanyNameBinding(cbCompanyName, companyName);

                whName = service.GetWHName();
                CommonUtil.ProdStatus_WHNameBinding(cbWHName, whName);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region DGV Binding
        private void DGV_Binding()
        {
            try
            {
                service = new ProdStatusService();
                allList = service.GetProdInfo();
                dgvProduct.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 새로고침버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnRefresh_Event(object sender, EventArgs e)
        {
            try
            {
                DGV_Binding();
                SearchCBBinding();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 등록버튼
        /// <summary>
        /// 팝업폼의 제목이 될 HeaderName을 생성자의 파라미터로 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnCreate_Event(object sender, EventArgs e)
        {
            try
            {
                string headerName = "품목 등록";
                frmProductManagePopUp frm = new frmProductManagePopUp(headerName);
                frm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 수정버튼
        /// <summary>
        /// 전역에 선언한 변수들을 생성자의 파라미터로 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnUpdate_Event(object sender, EventArgs e)
        {
            try
            {
                string headerName = "품목 수정";
                frmProductManagePopUp frm = new frmProductManagePopUp(headerName, product_id, product_name, product_type, product_unit, w_name, product_lorder_count, product_safety_count, company_name, product_exam, company_id, w_id, product_stnd, product_comment, product_deleted);
                frm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 삭제버튼
        /// <summary>
        /// 삭제확인 메세지 출력 후 확인시 삭제 진행
        /// 결과를 True/False로 받아서 확인/오류 메세지 출력
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns_btnDelete_Event(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Properties.Resources.msgDelete, "삭제확인 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    service = new ProdStatusService();
                    bool result = service.Delete(product_id);

                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                        DGV_Binding();
                    }
                    else
                        MessageBox.Show(Properties.Resources.msgError);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region Cell Double Click
        /// <summary>
        /// 전역에 선언한 변수들에 셀의 내용을 담는다
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                product_id = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                product_name = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                product_type = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                product_unit = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                w_name = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                product_lorder_count = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString());
                product_safety_count = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString());
                company_name = dgvProduct.Rows[e.RowIndex].Cells[8].Value.ToString();
                product_exam = dgvProduct.Rows[e.RowIndex].Cells[9].Value.ToString();
                product_stnd = dgvProduct.Rows[e.RowIndex].Cells[10].Value.ToString();
                product_comment = dgvProduct.Rows[e.RowIndex].Cells[11].Value.ToString();
                product_deleted = dgvProduct.Rows[e.RowIndex].Cells[12].Value.ToString();
                company_id = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[13].Value.ToString());
                w_id = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[14].Value.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion
    }
}
