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
using Team6_UMB.Util;
using UMB_VO;

namespace Team6_UMB.Forms.ASB
{    
    public partial class frmDepartment : Form
    {
        int department_id = 0;
        List<DepartmentVO> list = new List<DepartmentVO>();
        public frmDepartment(bool Authority)
        {
            InitializeComponent();

            if (Authority == false)
            {
                newBtns1.btnCreate.Visible = false;
                newBtns1.btnUpdate.Visible = false;
                newBtns1.btnDelete.Visible = false;
            }
        }

        public void DepartmentList()
        {
            DepartmentService service = new DepartmentService();
            list = service.DepartmentList();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnSearch.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnWait.Visible = false;
            newBtns1.btnPrint.Visible = false;

            CommonUtil.SetInitGridView(dgvDepartment);
            CommonUtil.AddGridTextColumn(dgvDepartment, "부서번호", "department_id", 150);
            CommonUtil.AddGridTextColumn(dgvDepartment, "부서명", "department_name", 250);
            CommonUtil.AddGridTextColumn(dgvDepartment, "수정자", "department_uadmin", 200);
            CommonUtil.AddGridTextColumn(dgvDepartment, "수정일", "department_udate", 200);

            DepartmentList();
            dgvDepartment.DataSource = list;
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            frmDepartmentPopUp frm = new frmDepartmentPopUp();
            frm.ShowDialog();
        }

        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            if (department_id == 0)
            {
                MessageBox.Show("수정할 부서를 선택하십시오.");
            }
            else
            {
                frmDepartmentPopUp frm = new frmDepartmentPopUp(department_id);
                frm.ShowDialog();
            }
        }

        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {

        }

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
                string sResult = ExcelExportImport.ExportToDataGridView<DepartmentVO>((List<DepartmentVO>)dgvDepartment.DataSource, "");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDepartment.DataSource = SearchDepartment(list, txtDepartment.Text);
        }

        public List<DepartmentVO> SearchDepartment(List<DepartmentVO> SearchList, string department_name)
        {
            var list = (from item in SearchList
                        where item.department_name.Contains(department_name)
                        select item).ToList();
            return list;
        }

        private void dgvDepartment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            department_id = Convert.ToInt32(dgvDepartment[0, e.RowIndex].Value);
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DepartmentList();
            dgvDepartment.DataSource = list;
        }
    }
}
