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

        public frmCompanyPopUp(string HeaderName)
        {
            InitializeComponent();

            Ctype = service.GetCompanyType();
            CommonUtil.CompanyTypeBinding(cbCType, Ctype);

            label1.Text = HeaderName;
        }
        public frmCompanyPopUp(string HeaderName, int company_id, string company_name, string company_type, string company_ceo, string company_cnum, string company_btype, string company_gtype, string company_email, string company_phone, string company_fax, string company_ZipCode, string company_Address, string company_DetAddress, string company_comment)
        {
            InitializeComponent();

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
    }
}
