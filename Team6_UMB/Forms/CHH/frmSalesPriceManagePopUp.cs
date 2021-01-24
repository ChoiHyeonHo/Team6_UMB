using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmSalesPricePopUp : Team6_UMB.frmPopUp
    {
        List<ProdCBOBindingVO> prodName;
        List<CompanyCBOBindingVO> companyName;

        public frmSalesPricePopUp(string headerName)
        {
            InitializeComponent();
            this.label1.Text = headerName;
            dtpStart.Value = DateTime.Now;
            cboBinding();
        }


        #region 제품명, 콤보박스 바인딩
        /// <summary>
        /// 제품ID를 가져와서 ValueMember, 제품명은 DisplayMember
        /// 거래처ID를 가져와서 ValueMember, 거래처명은 DisplayMember
        /// 작성자: 최현호
        /// 작성일: 21-01-24
        /// </summary>
        private void cboBinding()
        {
            SalesPriceService service = new SalesPriceService();
            prodName = service.GetProdName();
            CommonUtil.ProdNameBinding(cbProductName, prodName);

            service = new SalesPriceService();
            companyName = service.GetCompanyName();
            CommonUtil.CompanyNameBinding(cbCompanyName, companyName);
        }
        #endregion

        #region 단가 텍스트박스 숫자, 백스페이스, 마침표
        private void txtPricePresent_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
        }
        #endregion

        #region 닫기, 취소버튼
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }
        #endregion

        private void ClearTB()
        {
            cbProductName.SelectedIndex = cbCompanyName.SelectedIndex = cbYN.SelectedIndex = 0;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = new DateTime(9999 - 12 - 30);
            txtPricePresent.Text = txtComment.Text = string.Empty;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SalesPriceService service;
            if (label1.Text == "단가관리 등록")
            {
                if (cbProductName.SelectedIndex != 0 || cbCompanyName.SelectedIndex != 0 || cbYN.SelectedIndex != 0 || txtPricePresent.Text != null)
                {
                    SalesPriceVO vo = new SalesPriceVO
                    {
                        product_name = cbProductName.ValueMember,
                        company_name = cbCompanyName.ValueMember,
                        price_sdate = dtpStart.Value.ToString(),
                        price_edate = dtpEnd.Value.ToString(),
                        price_yn = cbYN.Text,
                        price_present = int.Parse(txtPricePresent.Text),
                        price_comment = txtComment.Text
                    };
                    service = new SalesPriceService();
                    bool result = service.Insert(vo);

                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                        cboBinding();
                        ClearTB();
                    }
                    else
                        MessageBox.Show(Properties.Resources.msgError);
                }
            }
            else if (label1.Text == "단가관리 수정")
            {

            }
        }
    }
}
