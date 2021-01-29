using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;
using UMB_VO.ASB;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmCheckListPopUp : Team6_UMB.frmPopUp
    {
        string headName;
        int cl_id;

        /// <summary>
        /// 등록
        /// </summary>
        /// <param name="headName"></param>
        public frmCheckListPopUp(string headName)
        {
            InitializeComponent();
            comboBinding();
            this.Text = this.headName = headName;
        }

        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="headName"></param>
        /// <param name="cl_id"></param>
        /// <param name="cl_name"></param>
        /// <param name="product_id"></param>
        /// <param name="product_name"></param>
        /// <param name="cl_stnd"></param>
        /// <param name="cl_comment"></param>
        /// <param name="cl_uadmin"></param>
        /// <param name="cl_type"></param>
        public frmCheckListPopUp(string headName, int cl_id, string cl_name, string product_id,
            string product_name, string cl_stnd, string cl_comment, string cl_uadmin, string cl_type)
        {
            InitializeComponent();
            comboBinding();
            this.Text = this.headName = headName;
            this.cl_id = cl_id;
            txtCheckListName.Text = cl_name;
            cboProductName.SelectedIndex = cboProductName.FindString(product_name);
            cboCheckType.SelectedIndex = cboCheckType.FindString(cl_type);
            txtStd.Text = cl_stnd;
            txtComment.Text = cl_comment;
            txtUadmin.Text = cl_uadmin;
        }

        /// <summary>
        /// 콤보박스바인딩 이벤트
        /// </summary>
        private void comboBinding()
        {
            string[] gubun = { "검사구분" };
            CheckListService cService = new CheckListService();
            List<ComboItemVO> allCheckType = cService.GetCheckTypeInfoByCodeTypes(gubun);
            ProductService pService = new ProductService();            
            List<ProdCBOBindingVO> allProItem = pService.GetProductInfo();
            
            CommonUtil.ComboBinding(cboCheckType, allCheckType, "검사구분");
            CommonUtil.ProdNameBinding(cboProductName, allProItem);            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboProductName.SelectedIndex < 1 && cboCheckType.SelectedIndex < 1 && txtCheckListName.Text.Trim().Length < 1)
            {
                MessageBox.Show("필수항목을 채워주세요");
                return;
            }
            try
            {
                if (headName == "검사항목등록")
                {
                    CheckListVO chk = new CheckListVO
                    {
                        cl_name = txtCheckListName.Text,
                        product_id = cboProductName.SelectedValue.ToString(),
                        cl_type = cboCheckType.Text,
                        cl_stnd = txtStd.Text,                                          
                        cl_comment = txtComment.Text,
                        cl_uadmin = txtUadmin.Text
                    };

                    CheckListService service = new CheckListService();
                    bool bResult = service.ChkInsert(chk);
                    if (bResult)
                    {
                        MessageBox.Show("새로운 검사항목을 등록하셨습니다");
                    }
                    else
                    {
                        MessageBox.Show("등록에 실패하셨습니다");
                    }
                }
                else if (headName == "검사항목수정")
                {
                    CheckListVO chk = new CheckListVO
                    {
                        cl_id = cl_id,
                        cl_name = txtCheckListName.Text,
                        product_id = cboProductName.SelectedValue.ToString(),
                        cl_type = cboCheckType.Text,
                        cl_stnd = txtStd.Text,
                        cl_comment = txtComment.Text,
                        cl_uadmin = txtUadmin.Text
                    };

                    CheckListService service = new CheckListService();
                    bool bResult = service.ChkUpdate(chk);
                    if (bResult)
                    {
                        MessageBox.Show("검사항목을 수정하셨습니다");
                    }
                    else
                    {
                        MessageBox.Show("수정에 실패하셨습니다");
                    }
                }

                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
