using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Forms.CHH;
using Team6_UMB.Service;
using UMB_VO;
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmCompanyPopUp : Team6_UMB.frmPopUp
    {
        List<CompanyTypeVO> Ctype;
        CompanyService service = new CompanyService();

        #region 등록버튼 생성자
        /// <summary>
        /// InitializeComponent 이후 거래처 분류 콤보박스를 바인딩하고 HeaderName 문자열을 팝업폼의 제목으로 준다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="HeaderName"></param>
        public frmCompanyPopUp(string HeaderName)
        {
            InitializeComponent();

            try
            {
                Ctype = service.GetCompanyType();
                CommonUtil.CompanyTypeBinding(cbCType, Ctype);

                label1.Text = HeaderName;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 수정버튼 생성자
        /// <summary>
        /// InitializeComponent 이후 거래처 분류 콤보박스를 바인딩하고 HeaderName 문자열을 팝업폼의 제목으로 준다.
        /// 파라미터로 전달받은 값들을 각 텍스트박스, 콤보박스, 라벨에 부여
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="HeaderName"></param>           ==> 폼 제목
        /// <param name="company_id"></param>           ==> 거래처ID
        /// <param name="company_name"></param>         ==> 거래처명
        /// <param name="company_type"></param>         ==> 거래처 분류
        /// <param name="company_ceo"></param>          ==> 대표명
        /// <param name="company_cnum"></param>         ==> 사업자번호
        /// <param name="company_btype"></param>        ==> 업종
        /// <param name="company_gtype"></param>        ==> 업태
        /// <param name="company_email"></param>        ==> 이메일
        /// <param name="company_phone"></param>        ==> 회사번호
        /// <param name="company_fax"></param>          ==> 팩스번호
        /// <param name="company_ZipCode"></param>      ==> 도로명주소
        /// <param name="company_Address"></param>      ==> 기본주소
        /// <param name="company_DetAddress"></param>   ==> 상세주소
        /// <param name="company_comment"></param>      ==> 비고
        public frmCompanyPopUp(string HeaderName, int company_id, string company_name, string company_type, string company_ceo, string company_cnum, string company_btype, string company_gtype, string company_email, string company_phone, string company_fax, string company_ZipCode, string company_Address, string company_DetAddress, string company_comment)
        {
            InitializeComponent();

            try
            {
                Ctype = service.GetCompanyType();
                CommonUtil.CompanyTypeBinding(cbCType, Ctype);

                label1.Text = HeaderName;
                lblCompanyID.Text = company_id.ToString();
                txtCName.Text = company_name;
                cbCType.Text = company_type;
                txtCCeo.Text = company_ceo;
                txtCNum.Text = company_cnum;
                txtCEmail.Text = company_email;
                txtCPNum.Text = company_phone;
                txtCFax.Text = company_fax;
                txtCBtype.Text = company_btype;
                txtCGtype.Text = company_gtype;
                txtZipCode.Text = company_ZipCode;
                txtAddress.Text = company_Address;
                txtDetAddress.Text = company_DetAddress;
                txtComment.Text = company_comment;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 주소찾기 버튼
        /// <summary>
        /// frmAddressAPI 폼의 주소 3개를 현재 폼의 각 텍스트박스로 부여
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZip_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddressAPI frmAddressAPI = new frmAddressAPI();

                if (frmAddressAPI.ShowDialog() == DialogResult.OK)
                {
                    txtZipCode.Text = frmAddressAPI.ZipCode;
                    txtAddress.Text = frmAddressAPI.Address1;
                    txtDetAddress.Text = frmAddressAPI.Address2;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 닫기 및 취소버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }
        #endregion

        #region Edit 버튼
        /// <summary>
        /// CompanyVO 타입으로 선언한 vo에 각 텍스트 내용을 담아서 DAC단의 파라미터로 전달
        /// 수정의 경우 수정자는 현재 로그인계정, 수정일은 현재 날짜 ToShortDateString
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            #region 등록 및 수정
            try
            {
                if (label1.Text == "업체관리 등록")
                {
                    CompanyVO vo = new CompanyVO
                    {
                        company_name = txtCName.Text,
                        company_type = cbCType.Text,
                        company_ceo = txtCCeo.Text,
                        company_cnum = txtCNum.Text,
                        company_btype = txtCBtype.Text,
                        company_gtype = txtCGtype.Text,
                        company_email = txtCEmail.Text,
                        company_phone = txtCPNum.Text,
                        company_fax = txtCFax.Text,
                        company_ZipCode = txtZipCode.Text,
                        company_Address = txtAddress.Text,
                        company_DetAddress = txtDetAddress.Text,
                        company_comment = txtComment.Text,
                    };
                    bool result = service.Insert(vo);

                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                        this.Close();
                    }
                    else
                        MessageBox.Show(Properties.Resources.msgError);
                }
                else if (label1.Text == "업체관리 수정")
                {

                    CompanyVO vo = new CompanyVO
                    {
                        company_id = int.Parse(lblCompanyID.Text),
                        company_name = txtCName.Text,
                        company_type = cbCType.Text,
                        company_ceo = txtCCeo.Text,
                        company_cnum = txtCNum.Text,
                        company_btype = txtCBtype.Text,
                        company_gtype = txtCGtype.Text,
                        company_email = txtCEmail.Text,
                        company_phone = txtCPNum.Text,
                        company_fax = txtCFax.Text,
                        company_ZipCode = txtZipCode.Text,
                        company_Address = txtAddress.Text,
                        company_DetAddress = txtDetAddress.Text,
                        company_comment = txtComment.Text,
                        company_uadmin = LoginVO.user.Name,
                        company_udate = DateTime.Now.ToShortDateString()
                    };
                    bool result = service.Update(vo);

                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                        this.Close();
                    }
                    else
                        MessageBox.Show(Properties.Resources.msgError);

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            #endregion
        }
        #endregion
    }
}
