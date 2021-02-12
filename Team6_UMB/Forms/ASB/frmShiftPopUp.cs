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

namespace Team6_UMB.Forms.ASB
{
    public partial class frmShiftPopUp : Team6_UMB.frmPopUp
    {
        ShiftVO vo = null;
        public frmShiftPopUp()
        {
            InitializeComponent();
        }

        public frmShiftPopUp(ShiftVO vo)
        {
            InitializeComponent();
            this.vo = vo;
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
            if (cboMachine.Text.Trim() == "" || cboDns.Text.Trim() == "" || nuPersonnel.Value == 0 || cboWeekend.Text.Trim() == "")
            {
                MessageBox.Show("필수정보를 입력해 주십시오.");
            }
            else
            {
                ShiftService service = new ShiftService();
                if (label1.Text == "Shift")
                {
                    ShiftVO vo = new ShiftVO()
                    {
                        m_id = Convert.ToInt32(cboMachine.SelectedValue),
                        shift_dns = cboDns.Text,
                        shift_stime = dtpSTime.Text,
                        shift_etime = dtpETime.Text,
                        shift_sdate = dtpStart.Text,
                        shift_edate = dtpEnd.Text,
                        shift_personnel = Convert.ToInt32(nuPersonnel.Value),
                        shift_comment = txtComment.Text,
                        shift_weekend = cboWeekend.Text
                    };
                    if(service.InsertShift(vo) == 1)
                    {
                        MessageBox.Show("shift 등록 완료");
                        this.Close();
                    }
                }
                else
                {
                    ShiftVO vo = new ShiftVO()
                    {
                        shift_id = this.vo.shift_id,
                        m_id = Convert.ToInt32(cboMachine.SelectedValue),
                        shift_dns = cboDns.Text,
                        shift_stime = dtpSTime.Text,
                        shift_etime = dtpETime.Text,
                        shift_sdate = dtpStart.Text,
                        shift_edate = dtpEnd.Text,
                        shift_personnel = Convert.ToInt32(nuPersonnel.Value),
                        shift_comment = txtComment.Text,
                        shift_weekend = cboWeekend.Text
                    };
                    if (service.UpdateShift(vo) == 1)
                    {
                        MessageBox.Show("shift 수정 완료");
                        this.Close();
                    }
                }
            }
        }

        private void frmShiftPopUp_Load(object sender, EventArgs e)
        {
            cboMachineBind();
            
            if(vo != null)
            {
                label1.Text = "shift 수정";
                cboMachine.SelectedValue = vo.m_id;
                cboDns.Text = vo.shift_dns;
                dtpSTime.Text = vo.shift_stime;
                dtpETime.Text = vo.shift_etime;
                dtpStart.Text = vo.shift_sdate;
                dtpEnd.Text = vo.shift_edate;
                nuPersonnel.Value = vo.shift_personnel;
                cboWeekend.Text = vo.shift_weekend;
                if(vo.shift_comment != null)
                {
                    txtComment.Text = vo.shift_comment;
                }
            }
        }

        public void cboMachineBind()
        {
            ShiftService service = new ShiftService();
            List<cboMachineVO> list = service.cboMachine();
            cboMachineVO blank = new cboMachineVO
            { m_id = 0, m_name = "" };
            list.Insert(0, blank);
            cboMachine.DisplayMember = "m_name";
            cboMachine.ValueMember = "m_id";
            cboMachine.DataSource = list;
        }
    }
}
