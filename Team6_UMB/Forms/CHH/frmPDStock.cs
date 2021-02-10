using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmPDStock : Team6_UMB.frmBaseList
    {
        PDStockService service = new PDStockService();
        List<PDStockVO> allList;
        List<GetProdNameVO> prodName;
        List<GetWHNameVO> whName;
        List<GetProdTypeVO> pdType;

        string strProdName, strProdType, strWHouse = "";
        string product_id;

        #region 생성자
        public frmPDStock()
        {
            InitializeComponent();
            newBtns1.btnBarCode.Visible = newBtns1.btnExcel.Visible = newBtns1.btnSearch.Visible = newBtns1.btnPrint.Visible = newBtns1.btnDocument.Visible = newBtns1.btnShipment.Visible = newBtns1.btnWait.Visible = newBtns1.btnCreate.Visible = newBtns1.btnUpdate.Visible = newBtns1.btnDelete.Visible = false;
            periodSearchControl.dtFrom = DateTime.Now.AddDays(-7).ToString();
            periodSearchControl.dtTo = DateTime.Now.ToString();
        }
        #endregion

        #region Form Load Event
        /// <summary>
        /// 컬럼 헤더 텍스트 바인딩
        /// 데이터 조회해서 바인딩
        /// 품목명, 창고명, 품목분류 콤보박스바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPDStock_Load(object sender, EventArgs e)
        {
            try
            {
                CommonUtil.SetInitGridView(dgv_PDStock);
                //CommonUtil.AddGridTextColumn(dgv_PDStock, "번호", "ps_id", 80);
                CommonUtil.AddGridTextColumn(dgv_PDStock, "품목코드", "product_id", 220);
                CommonUtil.AddGridTextColumn(dgv_PDStock, "품목명", "product_name", 220);
                CommonUtil.AddGridTextColumn(dgv_PDStock, "분류", "product_type", 220);
                CommonUtil.AddGridTextColumn(dgv_PDStock, "창고명", "w_name", 170);
                CommonUtil.AddGridTextColumn(dgv_PDStock, "회사명", "company_name", 150);
                CommonUtil.AddGridTextColumn(dgv_PDStock, "재고량", "ps_stock", 150);
                DGVBinding();

                ProdStatusService service = new ProdStatusService();
                prodName = service.GetProdName();
                CommonUtil.ProdStatus_ProdNameBinding(cbProdName, prodName);
                whName = service.GetWHName();
                CommonUtil.ProdStatus_WHNameBinding(cbWHName, whName);
                pdType = service.GetProdType();
                CommonUtil.ProdTypeBinding(cbProdType, pdType);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region Cell Double Click Event
        /// <summary>
        /// 셀의 0번째인 ID값을 변수에 담아서 팝업폼의 파라미터로 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_PDStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                product_id = dgv_PDStock.Rows[e.RowIndex].Cells[0].Value.ToString();
                frmPDStockPopUp frm = new frmPDStockPopUp(product_id);
                frm.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 콤보박스 Index Changed
        /// <summary>
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            strProdName = cbProdName.Text;
        }

        private void cbProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            strProdType = cbProdType.Text;
        }

        private void cbWHName_SelectedIndexChanged(object sender, EventArgs e)
        {
            strWHouse = cbWHName.Text;
        }
        #endregion

        #region 검색조건 기간조회
        /// <summary>
        /// 현재일과 종료일이 FromDate와 ToDate의 사이에 있어야 함
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void periodSearchControl1_ChangedPeriod(object sender, EventArgs e)
        {
            try
            {
                if (dgv_PDStock.DataSource != null)
                {
                    if (periodSearchControl.dtFrom != DateTime.Now.ToShortDateString())
                    {
                        string FromDate = periodSearchControl.dtFrom;
                        string ToDate = periodSearchControl.dtTo;

                        List<PDStockVO> periodList = (from period in allList
                                                      where Convert.ToDateTime(FromDate) <= Convert.ToDateTime(period.ps_idate) && Convert.ToDateTime(period.ps_odate) <= Convert.ToDateTime(ToDate)
                                                      select period).ToList();
                        dgv_PDStock.DataSource = periodList;
                    }
                }
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

        #region DGV Binding
        private void DGVBinding()
        {
            try
            {
                allList = service.GetPDStockInfo();
                dgv_PDStock.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 검색버튼
        /// <summary>
        /// 검색조건의 콤보박스의 Index가 0 이상일 경우 전역에 선언한 변수들에 내용을 담아 DAC단의 파라미터로 넘김
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbProdName.SelectedIndex > 0)
                    strProdName = cbProdName.Text;
                if (cbProdType.SelectedIndex > 0)
                    strProdType = cbProdType.Text;
                if (cbWHName.SelectedIndex > 0)
                    strWHouse = cbWHName.Text;

                allList = service.GetPDStockWhereInfo(strProdName, strProdType, strWHouse);
                dgv_PDStock.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion
    }
}
