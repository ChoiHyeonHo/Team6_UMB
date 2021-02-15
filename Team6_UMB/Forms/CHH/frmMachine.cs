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

namespace Team6_UMB.Forms
{
    public partial class frmMachine : Form
    {
        List<MachineVO> allList;
        MachineService service = new MachineService();
        string m_info, m_name, m_yn, m_comment;
        int m_id;

        public frmMachine(bool Authority)
        {
            InitializeComponent();

            newBtns1.btnBarCode.Visible = newBtns1.btnDocument.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnWait.Visible = false;

            if (Authority == false)
            {
                newBtns1.btnCreate.Visible = false;
                newBtns1.btnUpdate.Visible = false;
                newBtns1.btnDelete.Visible = false;
            }
        }

        #region Form Load Event
        /// <summary>
        /// 컬럼 헤더 텍스트 바인딩, 데이터 조회
        /// 콤보박스에 설비명 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMachine_Load(object sender, EventArgs e)
        {
            try
            {
                CommonUtil.SetInitGridView(dgvMachine);
                CommonUtil.AddGridTextColumn(dgvMachine, "설비번호", "m_id", 80);
                CommonUtil.AddGridTextColumn(dgvMachine, "설비정보", "m_info", 250);
                CommonUtil.AddGridTextColumn(dgvMachine, "설비명", "m_name", 200);
                CommonUtil.AddGridTextColumn(dgvMachine, "사용여부", "m_yn", 80);
                CommonUtil.AddGridTextColumn(dgvMachine, "비고", "m_comment", 500);
                CommonUtil.AddGridTextColumn(dgvMachine, "수정자", "m_uadmin", 120);
                CommonUtil.AddGridTextColumn(dgvMachine, "수정일", "m_udate", 150);
                DGVBinding();

                List<MachineVO> allMachineItem = service.GetMachineInfo();
                CommonUtil.MachineNameBinding(cbMachine, allMachineItem);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region DGV Binding
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        private void DGVBinding()
        {
            try
            {
                allList = service.CHH_GetMachineInfo();
                dgvMachine.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 등록버튼
        /// <summary>
        /// 등록과 수정이 같은 팝업폼 사용
        /// HeaderName 변수에 팝업폼의 제목을 담아서 파라미터로 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            try
            {
                string HeaderName = "설비정보 등록";
                frmMachinePopUp frm = new frmMachinePopUp(HeaderName);
                frm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 새로고침 버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }
        #endregion

        #region 검색버튼
        /// <summary>
        /// 콤보박스에 바인딩된 설비명을 DAC단의 파라미터로 넘겨서 쿼리문의 where절의 조건으로 넣는다
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                allList = service.CHH_MachineWhere(m_name);
                dgvMachine.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 콤보박스 인덱스 변경 Event
        private void cbMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_name = cbMachine.Text;
        }
        #endregion

        #region 수정버튼
        /// <summary>
        /// 전역에 선언한 변수에 설비 id, 설비명, 설비정보, 사용유무, 비고의 내용을 담아 파라미터로 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            try
            {
                string HeaderName = "설비정보 수정";
                frmMachinePopUp frm = new frmMachinePopUp(HeaderName, m_id, m_info, m_name, m_yn, m_comment);
                frm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region Cell Click Event
        /// <summary>
        /// 셀 클릭시 전역에 선언한 변수에 각 셀의 0~4번째의 내용을 담는다
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMachine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                m_id = int.Parse(dgvMachine.Rows[e.RowIndex].Cells[0].Value.ToString());
                m_info = dgvMachine.Rows[e.RowIndex].Cells[1].Value.ToString();
                m_name = dgvMachine.Rows[e.RowIndex].Cells[2].Value.ToString();
                m_yn = dgvMachine.Rows[e.RowIndex].Cells[3].Value.ToString();
                m_comment = dgvMachine.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 삭제버튼
        /// <summary>
        /// 삭제 확인 메세지 출력후 확인시 삭제 진행
        /// 클릭했을때의 설비 id를 변수에 담아 DAC단의 파라미터로 전달
        /// bool타입으로 받아서 true일 경우 DGV 다시 바인딩, False일 경우 오류메세지
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Properties.Resources.msgDelete, "삭제확인 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = service.CHH_MachineDelete(m_id);
                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                        DGVBinding();
                    }
                    else
                        MessageBox.Show(Properties.Resources.msgError);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion
    }
}
