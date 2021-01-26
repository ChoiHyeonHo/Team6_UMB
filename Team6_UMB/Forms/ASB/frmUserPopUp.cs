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
    public partial class frmUserPopUp : Team6_UMB.frmPopUp
    {
        int id = 0;
        public frmUserPopUp()
        {
            InitializeComponent();
        }

        public frmUserPopUp(int userid)
        {
            InitializeComponent();
            this.id = userid;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            UserService service = new UserService();            
            StringBuilder phone = new StringBuilder();
            phone.Append(cboPhone.Text);
            phone.Append("-");
            phone.Append(txtPhone1.Text);
            phone.Append("-");
            phone.Append(txtPhone2.Text);
            if(label1.Text == "사원정보등록")                
            {
                UserVO vo = new UserVO()
                {
                    user_name = txtUserName.Text,
                    user_national = cboNational.Text,
                    user_hiredate = dtpHire.Text,
                    user_pwd = txtPwd.Text,
                    user_phone = phone.ToString(),
                    user_birth = dtpBirth.Text,
                    department_id = int.Parse(cboDepartment.SelectedValue.ToString())
                };
                if (service.RegistUser(vo) == 0)
                {

                }
                else
                {
                    MessageBox.Show("등록 완료");
                    this.Close();
                }
            }
            else
            {
                UserVO vo = new UserVO()
                {
                    user_id = id,
                    user_name = txtUserName.Text,
                    user_national = cboNational.Text,
                    user_hiredate = dtpHire.Text,
                    user_pwd = txtPwd.Text,
                    user_phone = phone.ToString(),
                    user_birth = dtpBirth.Text,
                    department_id = int.Parse(cboDepartment.SelectedValue.ToString())                    
                };
                if(service.UpdateUser(vo) == 0)
                {

                }
                else
                {
                    MessageBox.Show("수정 완료");
                    this.Close();
                }
            }
        }

        private void frmUserPopUp_Load(object sender, EventArgs e)
        {
            UserService service = new UserService();
            CommonUtil util = new CommonUtil();
            util.DepartmentBinding(cboDepartment, service.DepartmentCboList());
            if(id != 0)
            {
                label1.Text = "사원정보수정";
                UserVO vo = service.userDetail(id);
                txtUserName.Text = vo.user_name;
                cboDepartment.SelectedValue = vo.department_id;
                txtPwd.Text = vo.user_pwd;
                dtpHire.Text = vo.user_hiredate;
                dtpBirth.Text = vo.user_birth;
                cboNational.Text = vo.user_national;
                string[] phone = vo.user_phone.Split(new char[] { '-' });
                cboPhone.Text = phone[0];
                txtPhone1.Text = phone[1];
                txtPhone2.Text = phone[2];
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
