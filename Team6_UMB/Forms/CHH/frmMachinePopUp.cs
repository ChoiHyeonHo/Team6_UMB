using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms
{
    public partial class frmMachinePopUp : Team6_UMB.frmPopUp
    {
        MachineService service = new MachineService();

        public frmMachinePopUp(string HeaderName)
        {
            InitializeComponent();
            label1.Text = HeaderName;
        }
        public frmMachinePopUp(string HeaderName, int m_id, string m_info, string m_name, string m_yn, string m_comment)
        {
            InitializeComponent();

            label1.Text = HeaderName;
            lblID.Text = m_id.ToString();
            txtMInfo.Text = m_info;
            txtMName.Text = m_name;
            cbYN.Text = m_yn;
            txtComment.Text = m_comment;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (label1.Text == "설비정보 등록")
            {
                MachineVO vo = new MachineVO
                {
                    m_info = txtMInfo.Text,
                    m_name = txtMName.Text,
                    m_comment = txtComment.Text,
                    m_yn = cbYN.Text,
                };
                bool result = service.CHH_MachineInsert(vo);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    this.Close();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            else if (label1.Text == "설비정보 수정")
            {
                MachineVO vo = new MachineVO
                {
                    m_id = int.Parse(lblID.Text),
                    m_info = txtMInfo.Text,
                    m_name = txtMName.Text,
                    m_comment = txtComment.Text,
                    m_yn = cbYN.Text,
                    m_uadmin = LoginVO.user.Name,
                    m_udate = DateTime.Now.ToShortDateString()
                };
                bool result = service.CHH_MachineUpdate(vo);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    this.Close();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
        }
    }
}
