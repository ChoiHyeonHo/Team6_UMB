using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmPDSPopUpUpdate : Team6_UMB.frmPopUp
    {
        PDStockService service = new PDStockService();

        #region 생성자
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="ps_id"></param>            ==> 재고수량ID
        /// <param name="product_id"></param>       ==> 품목ID
        /// <param name="product_name"></param>     ==> 품목명
        /// <param name="product_type"></param>     ==> 품목분류
        /// <param name="w_name"></param>           ==> 창고명
        /// <param name="company_name"></param>     ==> 거래처명
        /// <param name="ps_stock"></param>         ==> 재고수량
        /// <param name="ps_idate"></param>         ==> 시작일
        /// <param name="ps_odate"></param>         ==> 종료일
        public frmPDSPopUpUpdate(int ps_id, string product_id, string product_name, string product_type, string w_name, string company_name, int ps_stock, string ps_idate, string ps_odate)
        {
            InitializeComponent();

            lblPSID.Text = ps_id.ToString();
            txtProduct_id.Text = product_id;
            txtProduct_Name.Text = product_name;
            txtProduct_Type.Text = product_type;
            txtWHouse.Text = w_name;
            txtCompany.Text = company_name;
            nuStock.Value = ps_stock;
            dtp_idate.Value = Convert.ToDateTime(ps_idate);
            dtp_odate.Value = Convert.ToDateTime(ps_odate);
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
        /// PDStockVO 타입의 vo에 각 컨트롤의 내용을 담아서 DAC단의 파라미터로 전달
        /// 결과를 Bool타입으로 받아서 True/False에 따라 확인/오류 메세지 출력
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                PDStockVO vo = new PDStockVO
                {
                    ps_id = int.Parse(lblPSID.Text),
                    product_id = txtProduct_id.Text,
                    ps_stock = int.Parse(nuStock.Value.ToString()),
                    ps_idate = dtp_idate.Value.ToShortDateString(),
                    ps_odate = dtp_odate.Value.ToShortDateString()
                };

                bool result = service.Update(vo);
                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    this.Close();
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
    }
}
