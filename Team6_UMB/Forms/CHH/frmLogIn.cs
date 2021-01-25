using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms
{
    public partial class frmLogIn : Form
    {
        Point mMyPoint = new Point();
        public frmLogIn()
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

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtID.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtPwdFocus();
        }
        private void txtPwdFocus()
        {
            txtPwd.Clear();
            txtPwd.PasswordChar = '●';
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            btnSignIn.Focus();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            LoginService service = new LoginService();
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
                    frmMain frm = new frmMain();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.msgLoginCheck);
                }
            }
            //if (textBox1.Text.ToUpper() == "TEAM6" && textBox2.Text.ToUpper() == "UMB")
            //{
            //    frmMain frm = new frmMain();
            //    frm.Show();
            //}
            //else
            //{
            //    MessageBox.Show("에엥엥ㅇ에 틀렸대요 다시하셈");
            //}
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogIn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //현재 마우스 좌표를 저장한다.
                mMyPoint.X = e.X;
                mMyPoint.Y = e.Y;
            }
        }

        private void frmLogIn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //현재 마우스 좌표와 저장된 마우스 좌표의 차이만큼 이동 시킨다.
                this.Location = new Point(this.Location.X + (e.X - mMyPoint.X)

                , this.Location.Y + (e.Y - mMyPoint.Y));
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            txtPwd.Clear();
            txtPwd.PasswordChar = '●';
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}