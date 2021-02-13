using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_POP.Service;
using UMB_VO;


namespace UMB_POP
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );

        private void txtID_Click(object sender, EventArgs e)
        {
            txtID.Clear();
        }

        private void txtPwd_Click(object sender, EventArgs e)
        {
            txtPwdFocus();
        }

        private void txtPwdFocus()
        {
            txtPwd.Clear();
            txtPwd.PasswordChar = '●';
        }

        private void login_Load(object sender, EventArgs e)
        {
            btnSignIn.Focus();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            POPService service = new POPService();
            //로그인 유효성검사 null or 기본값
            if (txtID.Text == null || txtPwd.Text == null || txtID.Text == "UserID" || txtPwd.Text == "PassWord")
            {
                MessageBox.Show(Properties.Resources.msgLoginNull);
            }
            else
            {
                service.Login(int.Parse(txtID.Text), int.Parse(txtPwd.Text));
                if (LoginVO.user.ID != 0)
                {
                    frmPOP frm = new frmPOP();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.msgLoginCheck);
                }
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            txtPwd.Clear();
            txtPwd.PasswordChar = '●';
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                btnSignIn.PerformClick();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
