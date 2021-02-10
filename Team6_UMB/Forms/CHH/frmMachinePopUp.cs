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

        #region 등록 생성자
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="HeaderName"></param>
        public frmMachinePopUp(string HeaderName)
        {
            InitializeComponent();
            label1.Text = HeaderName;
        }
        #endregion

        #region 수정 생성자
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="HeaderName"></param>   ==> 팝업폼 제목
        /// <param name="m_id"></param>         ==> 설비ID
        /// <param name="m_info"></param>       ==> 설비정보
        /// <param name="m_name"></param>       ==> 설비명
        /// <param name="m_yn"></param>         ==> 사용유무
        /// <param name="m_comment"></param>    ==> 비고
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
        #endregion

        #region Edit 버튼
        /// <summary>
        /// MachineVO로 선언한 vo에 각 text의 내용을 담아서 DAC단의 파라미터로 전달
        /// 결과를 Bool 타입으로 받아서 True/False시 확인/오류 메세지 출력
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            #region 등록 및 수정
            try
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            #endregion
        }
        #endregion
    }
}
