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
    public partial class frmProductManagePopUp : Team6_UMB.frmPopUp
    {
        List<GetProdNameVO> prodName;
        List<GetCompanyNameVO> companyName;
        List<GetWHNameVO> whName;

        public frmProductManagePopUp(string headerName)
        {
            InitializeComponent();
            this.label1.Text = headerName;
            CBBinding();
        }

        public frmProductManagePopUp(string headerName, string product_id, string product_name, string product_type, string product_unit, string w_name, int product_lorder_count, int product_safety_count, string company_name, string product_exam, int company_id, int w_id, string product_stnd, string product_comment, string product_deleted)
        {
            InitializeComponent();
            CBBinding();
            this.label1.Text = headerName;
            cbProdName.Text = product_name;
            cbProdType.Text = product_type;
            cbUnit.Text = product_unit;
            nuMinOrder.Text = product_lorder_count.ToString();
            nuSafeCount.Text = product_safety_count.ToString();
            cbWHouse.Text = w_name;
            cbCompany.Text = company_name;
            cbExamYN.Text = product_exam;
            txtStnd.Text = product_stnd;
            txtComment.Text = product_comment;
            txtProdID.Text = product_id;
            lblWHID.Text = w_id.ToString();
            lblCompanyID.Text = company_id.ToString();
            cbDeleted.Text = product_deleted;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }

        private void CBBinding()
        {
            ProdStatusService service = new ProdStatusService();
            prodName = service.GetProdName();
            CommonUtil.ProdStatus_ProdNameBinding(cbProdName, prodName);

            companyName = service.GetCompanyName();
            CommonUtil.ProdStatus_CompanyNameBinding(cbCompany, companyName);

            whName = service.GetWHName();
            CommonUtil.ProdStatus_WHNameBinding(cbWHouse, whName);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ProdStatusService service = new ProdStatusService();
            if (label1.Text == "품목 등록")
            {
                ProdStatusVO vo = new ProdStatusVO
                {
                    product_id = txtProdID.Text,
                    product_type = cbProdType.Text,
                    product_unit = cbUnit.Text,
                    product_lorder_count = int.Parse(nuMinOrder.Value.ToString()),
                    product_safety_count = int.Parse(nuSafeCount.Value.ToString()),
                    product_name = cbProdName.Text,
                    company_name = cbCompany.Text,
                    w_name = cbWHouse.Text,
                    product_exam = cbExamYN.Text,
                    product_stnd = txtStnd.Text,
                    product_comment = txtComment.Text,
                    product_deleted = cbDeleted.Text
                };
                bool result = service.Insert(vo);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            else if(label1.Text == "품목 수정")
            {
                ProdStatusVO vo = new ProdStatusVO
                {
                    product_id = txtProdID.Text,
                    product_type = cbProdType.Text,
                    product_unit = cbUnit.Text,
                    product_lorder_count = int.Parse(nuMinOrder.Value.ToString()),
                    product_safety_count = int.Parse(nuSafeCount.Value.ToString()),
                    product_name = cbProdName.Text,
                    company_name = cbCompany.Text,
                    w_name = cbWHouse.Text,
                    product_exam = cbExamYN.Text,
                    product_stnd = txtStnd.Text,
                    product_comment = txtComment.Text,
                    product_deleted = cbDeleted.Text
                };
                bool result = service.Update(vo);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
        }
    }
}
