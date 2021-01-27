using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmDepartmentPopUp : Team6_UMB.frmPopUp
    {
        int Department_id = 0;
        public frmDepartmentPopUp()
        {
            InitializeComponent();
        }

        public frmDepartmentPopUp(int Department_id)
        {
            InitializeComponent();
            this.Department_id = Department_id;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DepartmentService service = new DepartmentService();
            if(Department_id == 0)
            {                
                DepartmentVO vo = new DepartmentVO()
                {
                    department_name = txtDeptName.Text,
                    department_comment = txtComment.Text                    
                };
                if(service.InsertDept(vo) != 0)
                {
                    MessageBox.Show("등록 완료");
                    this.Close();
                }
            }
            else
            {
                DepartmentVO vo = new DepartmentVO()
                {
                    department_id = Department_id,
                    department_name = txtDeptName.Text,
                    department_uadmin = LoginVO.user.Name,
                    department_comment = txtComment.Text                    
                };
                if(service.UpdateDept(vo) != 0)
                {
                    MessageBox.Show("수정 완료");
                    this.Close();
                }
            }
        }

        private void frmDepartmentPopUp_Load(object sender, EventArgs e)
        {
            if(Department_id != 0)
            {
                label1.Text = "부서 정보 - 수정";
                DepartmentService service = new DepartmentService();
                DepartmentVO vo = service.DetailDepartment(Department_id);
                txtDeptName.Text = vo.department_name;
                txtComment.Text = vo.department_comment;
            }
        }
    }
}
