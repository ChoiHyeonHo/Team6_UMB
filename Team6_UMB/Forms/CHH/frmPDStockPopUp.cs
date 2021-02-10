using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmPDStockPopUp : Team6_UMB.frmPopUp
    {
        PDStockService service = new PDStockService();
        //List<PDStockVO> allList;

        int ps_id, ps_stock;
        string product_id, product_name, product_type, w_name, company_name, ps_idate, ps_odate;

        #region 생성자
        public frmPDStockPopUp(string product_id)
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvPDStockPop);
            CommonUtil.AddGridTextColumn(dgvPDStockPop, "번호", "ps_id", 70);
            CommonUtil.AddGridTextColumn(dgvPDStockPop, "품목코드", "product_id", 100);
            CommonUtil.AddGridTextColumn(dgvPDStockPop, "품목명", "product_name", 80);
            CommonUtil.AddGridTextColumn(dgvPDStockPop, "분류", "product_type", 80);
            CommonUtil.AddGridTextColumn(dgvPDStockPop, "창고명", "w_name", 80);
            CommonUtil.AddGridTextColumn(dgvPDStockPop, "회사명", "company_name", 100);
            CommonUtil.AddGridTextColumn(dgvPDStockPop, "재고량", "ps_stock", 100);
            CommonUtil.AddGridTextColumn(dgvPDStockPop, "입고일", "ps_idate", 110);
            CommonUtil.AddGridTextColumn(dgvPDStockPop, "출고일", "ps_odate", 110);
            DGVBinding(product_id);

            newBtns1.btnBarCode.Visible = newBtns1.btnExcel.Visible = newBtns1.btnSearch.Visible = newBtns1.btnPrint.Visible = newBtns1.btnDocument.Visible = newBtns1.btnShipment.Visible = newBtns1.btnWait.Visible = newBtns1.btnCreate.Visible = false;
        }
        #endregion

        #region DGV Binding
        /// <summary>
        /// 생성자에서 넘겨받은 ID값을 토대로 데이터 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="product_id"></param>
        private void DGVBinding(string product_id)
        {
            try
            {
                dgvPDStockPop.DataSource = service.GetPDStockPopUpInfo(product_id);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 닫기버튼
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 셀 더블클릭
        /// <summary>
        /// 전역으로 선언한 변수들에 셀의 0~8번째까지의 내용을 담는다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPDStockPop_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ps_id = int.Parse(dgvPDStockPop.Rows[e.RowIndex].Cells[0].Value.ToString());
                product_id = dgvPDStockPop.Rows[e.RowIndex].Cells[1].Value.ToString();
                product_name = dgvPDStockPop.Rows[e.RowIndex].Cells[2].Value.ToString();
                product_type = dgvPDStockPop.Rows[e.RowIndex].Cells[3].Value.ToString();
                w_name = dgvPDStockPop.Rows[e.RowIndex].Cells[4].Value.ToString();
                company_name = dgvPDStockPop.Rows[e.RowIndex].Cells[5].Value.ToString();
                ps_stock = int.Parse(dgvPDStockPop.Rows[e.RowIndex].Cells[6].Value.ToString());
                ps_idate = dgvPDStockPop.Rows[e.RowIndex].Cells[7].Value.ToString();
                ps_odate = dgvPDStockPop.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 수정버튼
        /// <summary>
        /// ID가 0이상일 경우(셀 더블클릭을 통해 담겨진 변수들이 있는 경우) 팝업폼의 파라미터로 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            try
            {
                if (ps_id > 0)
                {
                    Forms.CHH.frmPDSPopUpUpdate frm = new CHH.frmPDSPopUpUpdate(ps_id, product_id, product_name, product_type, w_name, company_name, ps_stock, ps_idate, ps_odate);
                    frm.Show();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 삭제버튼
        /// <summary>
        /// 삭제확인 메세지 출력 후 확인시 삭제진행
        /// 결과를 True/False로 받아와서 확인/오류 메세지 출력
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

                    PDStockVO vo = new PDStockVO
                    {
                        ps_id = ps_id,
                        product_id = product_id
                    };

                    bool result = service.Delete(vo);

                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                        DGVBinding(product_id);
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
