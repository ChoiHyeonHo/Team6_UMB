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
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmCompany : Form
    {
        List<CompanyVO> allList;
        List<CompanyTypeVO> Ctype;
        List<GetCompanyNameVO> companyName;
        CompanyService service = new CompanyService();

        int company_id;
        string company_name, company_type, company_ceo, company_cnum, company_btype, company_gtype, company_email, company_phone, company_fax, company_ZipCode, company_Address, company_DetAddress, company_comment;
        string cbName, cbType;

        #region 검색버튼
        /// <summary>
        /// 전역에 선언한 변수를 초기값으로 설정
        /// 콤보박스의 인덱스가 0이상일 경우 변수에 값을 담아 DAC단의 파라미터로 넘김
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            cbName = cbType = string.Empty;
            if (cbCompanyName.SelectedIndex > 0)
                cbName = cbCompanyName.Text;
            if (cbCompanyType.SelectedIndex > 0)
                cbType = cbCompanyType.Text;

            allList = service.GetWhereInfo(cbName, cbType);
            dgvCompany.DataSource = allList;
        }
        #endregion

        #region 생성자 및 콤보박스 바인딩
        /// <summary>
        /// 폼 우측 상단의 공용 버튼의 Visible 속성을 제어하고
        /// 거래처명, 거래처분류 콤보박스 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        public frmCompany(bool Authority)
        {
            InitializeComponent();
            newBtns1.btnBarCode.Visible = newBtns1.btnDocument.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnWait.Visible = false;
            if (Authority == false)
            {
                newBtns1.btnCreate.Visible = false;
                newBtns1.btnUpdate.Visible = false;
                newBtns1.btnDelete.Visible = false;
            }
            try
            {
                Ctype = service.GetCompanyType();
                CommonUtil.CompanyTypeBinding(cbCompanyType, Ctype);

                ProdStatusService Pservice = new ProdStatusService();

                companyName = Pservice.GetCompanyName();
                CommonUtil.ProdStatus_CompanyNameBinding(cbCompanyName, companyName);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region Form Load Event
        /// <summary>
        /// 컬럼헤더 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCompany_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvCompany);
            CommonUtil.AddGridTextColumn(dgvCompany, "업체번호", "company_id", 80);             //0
            CommonUtil.AddGridTextColumn(dgvCompany, "업체명", "company_name", 100);            //1
            CommonUtil.AddGridTextColumn(dgvCompany, "업체구분", "company_type", 80);           //2
            CommonUtil.AddGridTextColumn(dgvCompany, "대표명", "company_ceo", 100);             //3
            CommonUtil.AddGridTextColumn(dgvCompany, "사업자번호", "company_cnum", 100);         //4
            CommonUtil.AddGridTextColumn(dgvCompany, "업종", "company_btype", 80);              //5
            CommonUtil.AddGridTextColumn(dgvCompany, "업태", "company_gtype", 80);              //6
            CommonUtil.AddGridTextColumn(dgvCompany, "이메일", "company_email", 200);           //7
            CommonUtil.AddGridTextColumn(dgvCompany, "전화번호", "company_phone", 100);         //8
            CommonUtil.AddGridTextColumn(dgvCompany, "팩스번호", "company_fax", 100);           //9
            CommonUtil.AddGridTextColumn(dgvCompany, "지번", "company_ZipCode", 10, false);    //10
            CommonUtil.AddGridTextColumn(dgvCompany, "주소", "company_Address", 140);          //11
            CommonUtil.AddGridTextColumn(dgvCompany, "주소상세", "company_DetAddress", 400);   //12
            CommonUtil.AddGridTextColumn(dgvCompany, "수정자", "company_uadmin", 10, false);   //13
            CommonUtil.AddGridTextColumn(dgvCompany, "수정일", "company_udate", 10, false);    //14
            CommonUtil.AddGridTextColumn(dgvCompany, "비고", "company_comment", 10, false);    //15
            DGVBinding();
        }
        #endregion

        #region DGV Binding
        /// <summary>
        /// 데이터 그리드 뷰 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        private void DGVBinding()
        {
            try
            {
                allList = service.GetCompanyInfo();
                dgvCompany.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 새로고침버튼
        /// <summary>
        /// 데이터 그리드뷰 메서드를 통해 다시 바인딩한다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }
        #endregion

        #region Cell Click Event
        /// <summary>
        /// 전역으로 선언한 변수에 셀의 0~15번째까지의 내용을 담는다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                company_id = int.Parse(dgvCompany.Rows[e.RowIndex].Cells[0].Value.ToString());
                company_name = dgvCompany.Rows[e.RowIndex].Cells[1].Value.ToString();
                company_type = dgvCompany.Rows[e.RowIndex].Cells[2].Value.ToString();
                company_ceo = dgvCompany.Rows[e.RowIndex].Cells[3].Value.ToString();
                company_cnum = dgvCompany.Rows[e.RowIndex].Cells[4].Value.ToString();
                company_btype = dgvCompany.Rows[e.RowIndex].Cells[5].Value.ToString();
                company_gtype = dgvCompany.Rows[e.RowIndex].Cells[6].Value.ToString();
                company_email = dgvCompany.Rows[e.RowIndex].Cells[7].Value.ToString();
                company_phone = dgvCompany.Rows[e.RowIndex].Cells[8].Value.ToString();
                company_fax = dgvCompany.Rows[e.RowIndex].Cells[9].Value.ToString();
                company_ZipCode = dgvCompany.Rows[e.RowIndex].Cells[10].Value.ToString();
                company_Address = dgvCompany.Rows[e.RowIndex].Cells[11].Value.ToString();
                company_DetAddress = dgvCompany.Rows[e.RowIndex].Cells[12].Value.ToString();
                company_comment = dgvCompany.Rows[e.RowIndex].Cells[15].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 등록 및 수정버튼
        /// <summary>
        /// 등록과 수정은 같은 팝업폼 사용, 생성자에 팝업폼의 제목이 될 문자열을 담는다.
        /// 수정의 경우 전역으로 선언한 변수를 같이 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            string HeaderName = "업체관리 등록";
            frmCompanyPopUp frm = new frmCompanyPopUp(HeaderName);
            frm.ShowDialog();
        }
        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            string HeaderName = "업체관리 수정";
            frmCompanyPopUp frm = new frmCompanyPopUp(HeaderName, company_id, company_name, company_type, company_ceo, company_cnum, company_btype, company_gtype, company_email, company_phone, company_fax, company_ZipCode, company_Address, company_DetAddress, company_comment);
            frm.ShowDialog();
        }
        #endregion

        #region 삭제버튼
        /// <summary>
        /// 삭제확인 메세지 출력 후 확인버튼시 삭제 진행
        /// DAC에서 결과를 Bool 타입으로 받아와서 True일 경우 확인메세지 출력 후 DGV 다시 바인딩
        /// False일 경우 에러메세지 출력
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Properties.Resources.msgDelete, "삭제확인 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = service.Delete(company_id);
                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                        DGVBinding();
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
    }
}
