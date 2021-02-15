using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Dev;
using Team6_UMB.Forms.CHH;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmBOM : Team6_UMB.frmBaseList
    {
        BOMService service = new BOMService();
        List<BOMVO> allList;
        List<GetProdTypeVO> GetProdType;

        int bomID, bom_use_count, bom_level;
        string bom_parent_id, prod_parent_id, prod_parent_name, product_id, product_name, product_type, product_unit, bom_comment;

        string prodName, prodType;
        int level;

        public frmBOM(bool Authority)
        {
            InitializeComponent();
            newBtns1.btnBarCode.Visible = newBtns1.btnShipment.Visible = newBtns1.btnDocument.Visible = newBtns1.btnSearch.Visible = newBtns1.btnWait.Visible = newBtns1.btnExcel.Visible = newBtns1.btnPrint.Visible = false;
            if (Authority == false)
            {
                newBtns1.btnCreate.Visible = false;
                newBtns1.btnUpdate.Visible = false;
                newBtns1.btnDelete.Visible = false;
            }
        }

        #region ComboBox Selected Index Changed Event
        /// <summary>
        /// 품목명, 분류 콤보박스의 선택된 인덱스를 담는다
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            prodName = cbProdName.Text;
        }

        private void cbProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            prodType = cbProdType.Text;
        }
        #endregion

        #region 새로고침 버튼
        /// <summary>
        /// 콤보박스의 선택된 인덱스를 0으로 바꾸고 폼의 우측 BOM 표를 보이지 않게, 0레벨로 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            cbLevel.SelectedIndex = cbProdName.SelectedIndex = cbProdType.SelectedIndex = 0;
            gbBOM.Visible = false;
            DGV_Binding_Lv0();
        }
        #endregion

        #region Form Load
        /// <summary>
        /// 폼 로드이벤트
        /// 컬럼헤더를 바인딩하고 DB에서 0레벨 BOM을 우선 조회한다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBOM_Load(object sender, EventArgs e)
        {
            try
            {
                #region 0레벨 BOM GridView
                CommonUtil.SetInitGridView(dgvBOM_Lv0);
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "번호", "bom_id", 40);                           //0
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "상위BOMID", "bom_parent_id", 10, false);        //1
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "상위품목ID", "prod_parent_id", 10, false);      //2
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "상위품목명", "prod_parent_name", 10, false);    //3
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "품목코드", "product_id", 80);                  //4
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "품목명", "product_name", 90);                  //5
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "분류", "product_type", 60);                    //6
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "단위", "product_unit", 60);                    //7
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "소요량", "bom_use_count", 70);                 //8
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "레벨", "bom_level", 40);                       //9
                CommonUtil.AddGridTextColumn(dgvBOM_Lv0, "비고", "bom_comment", 140, false);              //10
                #endregion

                #region BOMAll GridView
                CommonUtil.SetInitGridView(dgvBOMAll);
                CommonUtil.AddGridTextColumn(dgvBOMAll, "번호", "bom_id", 80);                           //0
                CommonUtil.AddGridTextColumn(dgvBOMAll, "품목코드", "product_id", 140);                  //1
                CommonUtil.AddGridTextColumn(dgvBOMAll, "품목명", "product_name", 160);                  //2
                CommonUtil.AddGridTextColumn(dgvBOMAll, "분류", "product_type", 160);                    //3
                CommonUtil.AddGridTextColumn(dgvBOMAll, "단위", "product_unit", 140);                    //4
                CommonUtil.AddGridTextColumn(dgvBOMAll, "소요량", "bom_use_count", 150);                 //5
                CommonUtil.AddGridTextColumn(dgvBOMAll, "레벨", "bom_level", 140);                       //6
                #endregion

                gbBOM.Visible = false;

                allList = service.GetBOMCBProdName();
                CommonUtil.BOMProdName(cbProdName, allList);

                ProdStatusService service2 = new ProdStatusService();
                GetProdType = service2.GetProdType();
                CommonUtil.ProdTypeBinding(cbProdType, GetProdType);

                DGV_Binding_Lv0();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region DGV Binding
        /// <summary>
        /// DataGridView Binding
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        private void DGV_Binding_Lv0()
        {
            try
            {
                allList = service.GetBOMInfo();
                dgvBOM_Lv0.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region Cell Double Click
        /// <summary>
        /// 셀 더블클릭 이벤트
        /// 0~10번째까지의 내용을 전역에 선언한 각 변수에 담는다.
        /// PreView 버튼의 내용 PerformClick.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBOM_Lv0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bomID = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[0].Value.ToString());
                bom_parent_id = dgvBOM_Lv0.Rows[e.RowIndex].Cells[1].Value.ToString();
                prod_parent_id = dgvBOM_Lv0.Rows[e.RowIndex].Cells[2].Value.ToString();
                prod_parent_name = dgvBOM_Lv0.Rows[e.RowIndex].Cells[3].Value.ToString();
                product_id = dgvBOM_Lv0.Rows[e.RowIndex].Cells[4].Value.ToString();
                product_name = dgvBOM_Lv0.Rows[e.RowIndex].Cells[5].Value.ToString();
                product_type = dgvBOM_Lv0.Rows[e.RowIndex].Cells[6].Value.ToString();
                product_unit = dgvBOM_Lv0.Rows[e.RowIndex].Cells[7].Value.ToString();
                bom_use_count = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[8].Value.ToString());
                bom_level = int.Parse(dgvBOM_Lv0.Rows[e.RowIndex].Cells[9].Value.ToString());
                bom_comment = dgvBOM_Lv0.Rows[e.RowIndex].Cells[10].Value.ToString();

                btnPreView.PerformClick();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 검색버튼
        /// <summary>
        /// 검색버튼 클릭 이벤트.
        /// 선택된 인덱스가 0 이상일 경우 콤보박스의 내용을 각각의 변수에 담아두고 DAC의 파라미터로 전달
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWhere_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLevel.SelectedIndex > 0)
                    level = int.Parse(cbLevel.Text);
                if (cbProdName.SelectedIndex > 0)
                    prodName = cbProdName.Text;
                if (cbProdType.SelectedIndex > 0)
                    prodType = cbProdType.Text;
                allList = service.GetBOMWhereInfo(level, prodName, prodType);
                dgvBOM_Lv0.DataSource = allList;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 등록버튼
        /// <summary>
        /// 등록, 수정버튼은 한개의 팝업폼을 공용으로 사용하지만 생성자의 파라미터를 다르게 넘겨준다.
        /// 등록의 경우 팝업폼의 제목을 BOM등록으로 넘김
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            string headerName = "BOM 등록";
            frmBOMPopUp frm = new frmBOMPopUp(headerName);
            frm.ShowDialog();
        }
        #endregion

        #region 수정버튼
        /// <summary>
        /// 등록, 수정버튼은 한개의 팝업폼을 공용으로 사용하지만 생성자의 파라미터를 다르게 넘겨준다.
        /// 수정의 경우 팝업폼의 제목을 BOM등록으로 넘김
        /// 셀 더블클릭을 통해 담긴 변수를 같이 넘긴다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBtns1_btnUpdate_Event(object sender, EventArgs e)
        {
            string headerName = "BOM 수정";
            frmBOMPopUp frm = new frmBOMPopUp(headerName, bomID, bom_parent_id, prod_parent_id, prod_parent_name, product_id, product_name, product_type, product_unit, bom_use_count, bom_level, bom_comment);
            frm.ShowDialog();
        }
        #endregion

        #region 삭제버튼
        /// <summary>
        /// 삭제확인 메세지 출력후 확인시 삭제 진행
        /// DAC단에서의 결과를 Bool 타입으로 받아와서 True / False로 구분
        /// True일 경우 확인 메세지 출력 이후 데이터그리드뷰 다시 바인딩
        /// False일 경우 에러메세지
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
                    bool result = service.Delete(bomID);

                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                        DGV_Binding_Lv0();
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

        #region PreView 버튼
        /// <summary>
        /// 변수에 담긴 bomID를 파라미터로 넘겨 DAC에서 조회하여 우측 그리드뷰로 나타낸다.
        /// 그리드뷰 속성에 대한 재정의
        /// 작성자: 최현호/ 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreView_Click(object sender, EventArgs e)
        {
            try
            {
                allList = service.GetBOMPreView(bomID);
                dgvBOMAll.DataSource = allList;

                #region 컬럼헤더 색상 및 글꼴 정의
                dgvBOMAll.EnableHeadersVisualStyles = false;
                dgvBOMAll.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvBOMAll.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 52, 79);
                dgvBOMAll.ColumnHeadersDefaultCellStyle.Font = new Font("나눔바른고딕", 12, FontStyle.Regular);
                dgvBOMAll.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                dgvBOMAll.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBOMAll.ColumnHeadersHeight = 40;
                dgvBOMAll.CurrentCell = null;
                #endregion

                gbBOM.Visible = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion
    }
}
