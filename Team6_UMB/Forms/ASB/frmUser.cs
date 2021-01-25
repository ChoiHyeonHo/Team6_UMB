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
using UMB_VO;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        public void UserList()
        {
            UserService service = new UserService();
            dgvUser.DataSource = service.UserList();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvUser);
            CommonUtil.AddGridTextColumn(dgvUser, "사원번호", "user_id", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "사원이름", "user_name", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "입사일", "user_hiredate", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "국적", "user_national", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "퇴사일", "user_enddate", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "관리자여부", "user_isadmin", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "부서", "department_name", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "전화번호", "user_phone", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "생년월일", "user_birth", 80);
            CommonUtil.AddGridTextColumn(dgvUser, "비밀번호", "user_pwd", 80);

            UserList();
        }
    }
}
