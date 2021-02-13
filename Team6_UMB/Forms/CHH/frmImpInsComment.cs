using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmImpInsComment : Team6_UMB.frmPopUp
    {
        ProdImpInsService service = new ProdImpInsService();
        ProdInsService service_P = new ProdInsService();
        string pEtc;
        int pID;

        #region 생성자
        /// <summary>
        /// 팝업폼의 제목, 수입검사번호, 비고text 내용을 파라미터로 전달받는다
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="HeaderName"></param>
        /// <param name="cl_inc_id"></param>
        /// <param name="etc"></param>
        public frmImpInsComment(string HeaderName, int cl_inc_id, string etc)
        {
            InitializeComponent();
            pEtc = etc;
            pID = cl_inc_id;
            label1.Text = HeaderName;
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

        #region Edit 버튼
        /// <summary>
        /// 비고의 Text내용과 검사ID를 변수에 담아 DAC단의 Comment 업데이트문에 파라미터로 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string comment = txtComment.Text;

            #region 수입검사, 제품검사 비고
            try
            {
                if (label1.Text == "수입검사 비고")
                {
                    bool result = service.Comment(pEtc, comment, pID);
                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                    }
                    else
                        MessageBox.Show(Properties.Resources.msgError);

                    this.Close();
                }
                else if (label1.Text == "제품검사 비고")
                {
                    bool result = service_P.Comment(pEtc, comment, pID);
                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                    }
                    else
                        MessageBox.Show(Properties.Resources.msgError);

                    this.Close();
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
