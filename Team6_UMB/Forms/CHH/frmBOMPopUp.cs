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
    public partial class frmBOMPopUp : Team6_UMB.frmPopUp
    {
        BOMService service = new BOMService();
        List<BOMVO> allList;

        #region 등록버튼 생성자
        /// <summary>
        /// 등록버튼을 눌렀을 경우의 생성자.
        /// 팝업폼의 헤더 이름을 받아오고, 콤보박스 바인딩
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="HeaderName"></param>
        public frmBOMPopUp(string HeaderName)
        {
            InitializeComponent();
            CBBinding();
            label1.Text = HeaderName;
        }
        #endregion

        #region 수정버튼 생성자
        /// <summary>
        /// 수정버튼을 눌렀을 경우의 생성자.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="headerName"></param>       ==> 팝업폼 제목의 이름
        /// <param name="bomID"></param>            ==> BOMID
        /// <param name="bom_parent_id"></param>    ==> 상위 BOM ID
        /// <param name="prod_parent_id"></param>   ==> 상위 품목 ID
        /// <param name="prod_parent_name"></param> ==> 상위 품목명
        /// <param name="product_id"></param>       ==> 품목코드
        /// <param name="product_name"></param>     ==> 품목명
        /// <param name="product_type"></param>     ==> 품목분류
        /// <param name="product_unit"></param>     ==> 품목 단위
        /// <param name="bom_use_count"></param>    ==> 소요량
        /// <param name="bom_level"></param>        ==> BOM 레벨
        /// <param name="bom_comment"></param>      ==> 비고
        public frmBOMPopUp(string headerName, int bomID, string bom_parent_id, string prod_parent_id, string prod_parent_name, string product_id, string product_name, string product_type, string product_unit, int bom_use_count, int bom_level, string bom_comment)
        {
            InitializeComponent();
            CBBinding();

            label1.Text = headerName;
            lblBOMID.Text = bomID.ToString();
            lblBOMParentID.Text = bom_parent_id;
            lblProdParentID.Text = prod_parent_id;
            cbParent.Text = prod_parent_name;
            lblProdID.Text = product_id;
            cbProd.Text = product_name;
            lblProdType.Text = product_type;
            lblProdUnit.Text = product_unit;
            nuUseCount.Value = bom_use_count;
            nuLevel.Value = bom_level;
            txtComment.Text = bom_comment;
        }
        #endregion

        #region 콤보박스 바인딩
        /// <summary>
        /// 상위품목명과 제품명 콤보박스를 바인딩해온다.
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        private void CBBinding()
        {
            try
            {
                allList = service.GetBOMCBProdName();
                CommonUtil.BOMProdName(cbParent, allList);
                CommonUtil.BOMProdName(cbProd, allList);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 닫기, 취소 버튼
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }
        #endregion

        #region Edit 버튼
        /// <summary>
        /// 팝업폼 제목을 기준으로 등록인지 수정인지 판단
        /// BOMVO에 내용들을 담아서 DAC단의 파라미터로 전달.
        /// 성공여부를 Bool 타입으로 받아서 결과 메세지 출력
        /// 작성자: 최현호 / 작성일: 210210
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                #region 등록버튼
                if (label1.Text == "BOM 등록")
                {
                    BOMVO vo = new BOMVO
                    {
                        prod_parent_name = cbParent.Text,
                        product_name = cbProd.Text,
                        bom_use_count = (int)nuUseCount.Value,
                        bom_level = (int)nuLevel.Value,
                        bom_comment = txtComment.Text
                    };

                    bool result = service.Insert(vo);
                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                    }
                    else
                        MessageBox.Show(Properties.Resources.msgError);
                }
                #endregion

                #region 수정버튼
                else if (label1.Text == "BOM 수정")
                {
                    BOMVO vo = new BOMVO
                    {
                        bom_id = int.Parse(lblBOMID.Text),
                        prod_parent_name = cbParent.Text,
                        product_name = cbProd.Text,
                        bom_use_count = (int)nuUseCount.Value,
                        bom_level = (int)nuLevel.Value,
                        bom_comment = txtComment.Text
                    };

                    bool result = service.Update(vo);
                    if (result)
                    {
                        MessageBox.Show(Properties.Resources.msgOK);
                    }
                    else
                        MessageBox.Show(Properties.Resources.msgError);
                }
                #endregion
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion
    }
}
