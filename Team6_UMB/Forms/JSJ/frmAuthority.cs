using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms
{
    public partial class frmAuthority : Team6_UMB.frmBaseList
    {
        CheckBox headerCheck = new CheckBox();
        (List<DepartmentVO>, List<MenuVO>) list;
        int department_id;

        public frmAuthority()
        {
            InitializeComponent();
        }

        private void frmAuthority_Load(object sender, EventArgs e)
        {
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnCreate.Visible = false;
            newBtns1.btnDelete.Visible = false;
            newBtns1.btnExcel.Visible = false;
            newBtns1.btnPrint.Visible = false;
            newBtns1.btnWait.Visible = false;
            newBtns1.btnSearch.Visible = false;

            CommonUtil.SetInitGridView(dgvDepartment);
            CommonUtil.AddGridTextColumn(dgvDepartment, "부서번호", "department_id", 150);
            CommonUtil.AddGridTextColumn(dgvDepartment, "부서명", "department_name", 300);
            CommonUtil.AddGridTextColumn(dgvDepartment, "비고", "department_comment", 500);


            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvMenu.Columns.Add(chk);

            //Header체크 속성추가
            Point point = dgvMenu.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheck.Location = new Point(point.X + 8, point.Y + 2);
            headerCheck.BackColor = Color.White;
            headerCheck.Size = new Size(18, 18);
            headerCheck.Click += HeaderCheck_Click;
            dgvMenu.Controls.Add(headerCheck);

            CommonUtil.SetInitGridView(dgvMenu);
            CommonUtil.AddGridTextColumn(dgvMenu, "메뉴명", "common_name", 300);

            List();   
        }

        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            dgvMenu.EndEdit(); //현재 포커스가 있는 셀의 편집을 종료 (다른 셀로 이동시킨 것과 같은 효과)

            foreach (DataGridViewRow row in dgvMenu.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                chk.Value = headerCheck.Checked;
            }
        }

        public void List()
        {
            AuthorityService service = new AuthorityService();
            list = service.DepartmentList();
            dgvDepartment.DataSource = list.Item1;
            dgvMenu.DataSource = list.Item2;
        }

        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            AuthorityService service = new AuthorityService();
            List<AuthorityVO> list = new List<AuthorityVO>();
            AuthorityVO vo;

            foreach (DataGridViewRow row in dgvMenu.Rows)
            {
                bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                if (bCheck)
                {
                    vo = new AuthorityVO();
                    vo.auth_formname = row.Cells["common_name"].Value.ToString();
                    list.Add(vo);
                }
            }
            if (list.Count == 0)
            {
                MessageBox.Show("메뉴를 선택해 주십시오.");
            }
            else
            {
                if (service.UpdateAuthority(list, department_id) == 1)
                {
                    MessageBox.Show("권한 수정 완료");
                }
            }
        }

        private void dgvDepartment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            department_id = Convert.ToInt32(dgvDepartment[0, e.RowIndex].Value);

            AuthorityService service = new AuthorityService();
            //List<AuthorityVO> MenuList = service.MenuCheck(department_id);
            List<string> MenuList = service.MenuCheck(department_id);

            foreach(DataGridViewRow row in dgvMenu.Rows)
            {
                //AuthorityVO Menu = new AuthorityVO() {auth_formname = row.Cells["common_name"].Value.ToString()};
                //if (MenuList.Contains(Menu))
                //{
                //    row.Cells["chk"].Value = true;
                //}

                string Menu = row.Cells["common_name"].Value.ToString();
                if(MenuList.Contains(Menu))
                {
                    row.Cells["chk"].Value = true;
                }
                else

                {
                    row.Cells["chk"].Value = false;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
