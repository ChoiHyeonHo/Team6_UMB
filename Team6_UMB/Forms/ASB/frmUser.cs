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
    public partial class frmUser : Form
    {
        int userid;
        List<UserVO> list = new List<UserVO>();
        public frmUser()
        {
            InitializeComponent();
        }

        public void UserList()
        {
            UserService service = new UserService();
            list = service.UserList();
            dgvUser.DataSource = list;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            UserService service = new UserService();
            CommonUtil util = new CommonUtil();
            util.DepartmentBinding(cboDepartment, service.DepartmentCboList());

            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnSearch.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnWait.Visible = false;
            newBtns1.btnPrint.Visible = false;
            newBtns1.btnDelete.Text = "퇴사";

            CommonUtil.SetInitGridView(dgvUser);
            CommonUtil.AddGridTextColumn(dgvUser, "사원번호", "user_id", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "사원명", "user_name", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "입사일", "user_hiredate", 120);
            CommonUtil.AddGridTextColumn(dgvUser, "국적", "user_national", 120);
            CommonUtil.AddGridTextColumn(dgvUser, "퇴사일", "user_enddate", 120);
            CommonUtil.AddGridTextColumn(dgvUser, "관리자여부", "user_isadmin", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "부서명", "department_name", 150);
            CommonUtil.AddGridTextColumn(dgvUser, "전화번호", "user_phone", 120);
            CommonUtil.AddGridTextColumn(dgvUser, "생년월일", "user_birth", 120);
            CommonUtil.AddGridTextColumn(dgvUser, "비밀번호", "user_pwd", 80);

            UserList();
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            frmUserPopUp frm = new frmUserPopUp();
            frm.ShowDialog();
        }

        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {
            UserService service = new UserService();
            if (service.EndUser(userid) != 0)
            {
                MessageBox.Show("퇴사처리 완료");
                UserList();
            }            
        }

        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            frmUserPopUp frm = new frmUserPopUp(userid);
            frm.ShowDialog();            
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userid = Convert.ToInt32(dgvUser[0, e.RowIndex].Value);
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            UserList();
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
                string sResult = ExcelExportImport.ExportToDataGridView<UserVO>((List<UserVO>)dgvUser.DataSource, "");
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
            string work = null;
            if(rdWork.Checked == true)
            {
                work = "9999-01-01";
            }
            else if(rdEnd.Checked == true)
            {
                work = "2";
            }
            dgvUser.DataSource = SearchUser(list, txtUserName.Text, cboDepartment.Text, work);
        }

        public List<UserVO> SearchUser(List<UserVO> SearchList, string UserName, string Department, string work)
        {
            var list = (from item in SearchList
                        where item.user_name.Contains(UserName) && item.department_name.Contains(Department) && item.user_enddate.Contains(work)
                        && Convert.ToDateTime(periodSearchControl.dtFrom) <= Convert.ToDateTime(item.user_hiredate) && Convert.ToDateTime(periodSearchControl.dtTo) >= Convert.ToDateTime(item.user_hiredate)
                        select item).ToList();
            return list;
        }
    }
}
