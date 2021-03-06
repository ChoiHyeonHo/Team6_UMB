﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Dev;
using Team6_UMB.Service;
using UMB_VO;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmImpInspecPopUp : Team6_UMB.frmPopUp
    {
        ProdImpInsService service = new ProdImpInsService();
        List<InsCheckVO> allList;
        string dTemp, pTemp;
        CheckBox headerCheck = new CheckBox();
        int cl_inc_id;
        string cl_inc_Color, etc;

        #region 생성자
        /// <summary>
        /// 수입검사 폼에서 where in()절에 들어갈 id,id.. 의 값을 string 타입으로 받아서 dTemp변수에 담는다
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="temp"></param>
        public frmImpInspecPopUp(string temp)
        {
            InitializeComponent();
            dTemp = temp;
            newBtns1.btnBarCode.Visible = newBtns1.btnCreate.Visible = newBtns1.btnDelete.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = newBtns1.btnSearch.Visible = newBtns1.btnShipment.Visible = newBtns1.btnUpdate.Visible = false;
            newBtns1.btnDocument.Text = "검사지";
            newBtns1.btnWait.Text = "입고";
        }
        #endregion

        #region Form Load Event
        /// <summary>
        /// DGV 셀의 0번째에 체크박스를 바인딩
        /// 컬럼헤더 텍스트 바인딩 후 데이터 조회
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmImpInspecPopUp_Load(object sender, EventArgs e)
        {
            try
            {
                dgvCheckList.AutoGenerateColumns = false;
                dgvCheckList.AllowUserToAddRows = false;
                dgvCheckList.MultiSelect = false;
                dgvCheckList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "";
                chk.Name = "chk";
                chk.Width = 30;
                dgvCheckList.Columns.Add(chk);

                Point point = dgvCheckList.GetCellDisplayRectangle(0, -1, true).Location;

                headerCheck.Location = new Point(point.X + 8, point.Y + 2);
                headerCheck.BackColor = Color.White;
                headerCheck.Size = new Size(18, 18);
                headerCheck.Click += HeaderCheck_Click;
                dgvCheckList.Controls.Add(headerCheck);

                CommonUtil.SetInitGridView(dgvCheckList);
                CommonUtil.AddGridTextColumn(dgvCheckList, "검사번호", "cl_inc_id", 80);
                CommonUtil.AddGridTextColumn(dgvCheckList, "입고번호", "incomming_ID", 80);
                CommonUtil.AddGridTextColumn(dgvCheckList, "색상", "cl_inc_Color", 90);
                CommonUtil.AddGridTextColumn(dgvCheckList, "찢어짐", "cl_inc_Torn", 90);
                CommonUtil.AddGridTextColumn(dgvCheckList, "길이", "cl_inc_Length", 90);
                CommonUtil.AddGridTextColumn(dgvCheckList, "찍힘", "cl_inc_Crack", 90);
                CommonUtil.AddGridTextColumn(dgvCheckList, "기타", "etc", 200);
                DGVBinding();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 컬럼헤더의 체크박스 클릭
        /// <summary>
        /// EndEdit()를 통해 현재 포커스가 있는 셀의 편집을 종료한다.
        /// foreach문을 돌면서 선택된 체크박스가 있는 셀의 index를 List에 담는다
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCheckList.EndEdit();
                List<int> index = new List<int>();
                foreach (DataGridViewRow row in dgvCheckList.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                    chk.Value = headerCheck.Checked;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region DGV Binding
        /// <summary>
        /// 수입검사 폼에서 where in()절에 들어갈 id값들 여러개를 DAC단의 파라미터로 넘겨 해당 id값을 가진 데이터들만 조회
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        private void DGVBinding()
        {
            try
            {
                allList = service.GetInsCheckInfo(dTemp);
                dgvCheckList.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 검사지 버튼
        /// <summary>
        /// foreach문을 돌며 체크된 셀의 수입검사 id 를 List에 담는다
        /// List에 담긴 id값들에 ","를 붙여 문자열 temp에 담는다
        /// DAC단의 파라미터로 temp를 넘기고 선택된 id값들을 조회하여 DEV Reprot Preview 호출
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnDocument_Event(object sender, EventArgs e)
        {
            try
            {
                List<int> CheckList = new List<int>();
                foreach (DataGridViewRow row in dgvCheckList.Rows)
                {
                    bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                    if (bCheck)
                    {
                        CheckList.Add(int.Parse(row.Cells["cl_inc_id"].Value.ToString()));
                    }
                }
                string temp = string.Join(",", CheckList);
                InsCheck rpt = new InsCheck();
                rpt.DataSource = service.GetInsCheckInfoDEV(temp);
                frmReportPreview frm = new frmReportPreview(rpt);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 닫기 및 취소버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            btnClose.PerformClick();
        }
        #endregion

        #region 새로고침 버튼
        /// <summary>
        /// 작성자: 최현호 / 작성일: 212010
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            DGVBinding();
        }
        #endregion

        #region 컨텍스트 메뉴 스트립

        #region 색 양호
        private void 양호ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
                pTemp = "cl_inc_Color";
                cl_inc_Color = "양호";

                bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGVBinding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 색 불량
        private void 불량ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
                pTemp = "cl_inc_Color";
                cl_inc_Color = "불량";
                bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGVBinding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 찢어짐 양호
        private void 양호ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
                pTemp = "cl_inc_Torn";
                cl_inc_Color = "양호";
                bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGVBinding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void 비고ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string headerName = "수입검사 비고";
            cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
            etc = "etc";

            frmImpInsComment frm = new frmImpInsComment(headerName, cl_inc_id, etc);
            frm.Show();
        }

        private void newBtns1_btnWait_Event(object sender, EventArgs e)
        {
            List<int> CheckList = new List<int>();
            List<int> IncommingID = new List<int>();
            foreach (DataGridViewRow row in dgvCheckList.Rows)
            {
                bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                if (bCheck)
                {
                    CheckList.Add(int.Parse(row.Cells["cl_inc_id"].Value.ToString()));
                    IncommingID.Add(int.Parse(row.Cells["incomming_ID"].Value.ToString()));
                }
            }
            string temp = string.Join(",", CheckList);
            string incTemp = string.Join(",", IncommingID);
            string alphaTemp = string.Join("@", CheckList);
            string userName = LoginVO.user.Name;
            bool result = service.UpdateAll(temp, incTemp, userName, alphaTemp);
            bool result2 = service.InsertCheckHistory(alphaTemp);
            if (result && result2)
            {
                MessageBox.Show(Properties.Resources.msgOK);
                DGVBinding();
            }
            else
                MessageBox.Show(Properties.Resources.msgError);
        }
        #endregion

        #region 찢어짐 불량
        private void 불량ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
                pTemp = "cl_inc_Torn";
                cl_inc_Color = "불량";
                bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGVBinding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 길이 양호
        private void 양호ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
                pTemp = "cl_inc_Length";
                cl_inc_Color = "양호";
                bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGVBinding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 길이 불량
        private void 불량ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
                pTemp = "cl_inc_Length";
                cl_inc_Color = "불량";
                bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGVBinding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 찍힘 양호
        private void 양호ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
                pTemp = "cl_inc_Crack";
                cl_inc_Color = "양호";
                bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGVBinding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 찍힘 불량
        private void 불량ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                cl_inc_id = int.Parse(dgvCheckList.Rows[dgvCheckList.CurrentRow.Index].Cells[1].Value.ToString());
                pTemp = "cl_inc_Crack";
                cl_inc_Color = "불량";
                bool result = service.Update(pTemp, cl_inc_Color, cl_inc_id);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGVBinding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #endregion
    }
}
