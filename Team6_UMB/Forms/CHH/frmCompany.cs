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
        CompanyService service = new CompanyService();

        int company_id;
        string company_name, company_type, company_ceo, company_cnum, company_btype, company_gtype, company_email, company_phone, company_fax, company_address, company_uadmin, company_udate, company_comment;

        

        public frmCompany()
        {
            InitializeComponent();
            newBtns1.btnBarCode.Visible = newBtns1.btnDocument.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnWait.Visible = false;
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvCompany);
            CommonUtil.AddGridTextColumn(dgvCompany, "업체번호", "company_id", 80);
            CommonUtil.AddGridTextColumn(dgvCompany, "업체명", "company_name", 100);
            CommonUtil.AddGridTextColumn(dgvCompany, "업체구분", "company_type", 80);
            CommonUtil.AddGridTextColumn(dgvCompany, "대표명", "company_ceo", 100);
            CommonUtil.AddGridTextColumn(dgvCompany, "사업자번호", "company_cnum", 100);
            CommonUtil.AddGridTextColumn(dgvCompany, "업종", "company_btype", 80);
            CommonUtil.AddGridTextColumn(dgvCompany, "업태", "company_gtype", 80);
            CommonUtil.AddGridTextColumn(dgvCompany, "이메일", "company_email", 200);
            CommonUtil.AddGridTextColumn(dgvCompany, "전화번호", "company_phone", 100);
            CommonUtil.AddGridTextColumn(dgvCompany, "팩스번호", "company_fax", 100);
            CommonUtil.AddGridTextColumn(dgvCompany, "주소", "company_address", 440);
            CommonUtil.AddGridTextColumn(dgvCompany, "수정자", "company_uadmin", 10, false);
            CommonUtil.AddGridTextColumn(dgvCompany, "수정일", "company_udate", 10, false);
            CommonUtil.AddGridTextColumn(dgvCompany, "비고", "company_comment", 10, false);
            DGVBinding();
        }

        private void DGVBinding()
        {
            allList = service.GetCompanyInfo();
            dgvCompany.DataSource = allList;
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }
        private void dgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
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
            company_address = dgvCompany.Rows[e.RowIndex].Cells[10].Value.ToString();
            company_uadmin = dgvCompany.Rows[e.RowIndex].Cells[11].Value.ToString();
            company_udate = dgvCompany.Rows[e.RowIndex].Cells[12].Value.ToString();
            company_comment = dgvCompany.Rows[e.RowIndex].Cells[13].Value.ToString();
        }
    

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            frmCompanyPopUp frm = new frmCompanyPopUp();
            frm.ShowDialog();
        }
        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            frmCompanyPopUp frm = new frmCompanyPopUp(company_id, company_name, company_type, company_ceo, company_cnum, company_btype, company_gtype, company_email, company_phone, company_fax, company_address, company_uadmin, company_udate, company_comment);
            frm.ShowDialog();
        }
    }
}
