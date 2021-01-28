using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;
using UMB_VO.CHH;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmBORPopup : Team6_UMB.frmPopUp
    {
        
        string headName;
        int bor_id;

        private void frmBORPopup_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBinding()
        {
            string[] gubun = { "공정명" };
            ProductService pService = new ProductService();
            List<ComboItemVO> allProcessItem = pService.GetProcessInfoByCodeTypes(gubun);
            List<ProdCBOBindingVO> allProItem = pService.GetProductInfo();
            MachineService mService = new MachineService();
            List<MachineVO> allMachineItem = mService.GetMachineInfo();

            CommonUtil.ComboBinding(cboProcessName, allProcessItem, "공정명");
            CommonUtil.ProdNameBinding(cboProductName, allProItem);
            CommonUtil.MachineNameBinding(cboMachine, allMachineItem);
        }

        public frmBORPopup(string headName)
        {
            InitializeComponent();
            comboBinding();
            this.Text = this.headName = headName;
        }

        public frmBORPopup(string headName, int BOR_id, string product_name, string process_name, string m_name, int bor_tattime, string bor_yn, string bor_comment, string bor_uadmin)
        {
            InitializeComponent();
            comboBinding();
            this.Text = this.headName = headName;
            this.bor_id = BOR_id;            
            cboProductName.SelectedIndex = cboProductName.FindString(product_name);
            cboProcessName.SelectedIndex = cboProcessName.FindString(process_name);
            cboMachine.SelectedIndex = cboMachine.FindString(m_name);
            txtTactTime.Text = bor_tattime.ToString();
            cboYN.SelectedIndex = cboYN.FindString(bor_yn);
            txtComment.Text = bor_comment;
            txtUadmin.Text = bor_uadmin;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(cboProductName.SelectedIndex < 1 && cboMachine.SelectedIndex < 1 && cboProcessName.SelectedIndex < 1
                && txtTactTime.Text.Trim().Length < 1 && cboYN.SelectedIndex < 1 )
            {
                MessageBox.Show("필수항목을 채워주세요");
                return;
            }
            try
            {
                if (headName == "BOR추가")
                {
                    BORVO bor = new BORVO
                    {
                        product_id = cboProductName.SelectedValue.ToString(),
                        process_name = cboProcessName.Text,
                        m_id = Convert.ToInt32(cboMachine.SelectedValue),
                        bor_tacttime = Convert.ToInt32(txtTactTime.Text),
                        bor_yn = cboYN.Text,
                        bor_comment = txtComment.Text,
                        bor_uadmin = txtUadmin.Text
                    };

                    BORService service = new BORService();
                    bool bResult = service.BORInsert(bor);
                    if (bResult)
                    {
                        MessageBox.Show("새로운 BOR를 등록하셨습니다");
                    }
                    else
                    {
                        MessageBox.Show("등록에 실패하셨습니다");
                    }
                }
                else if(headName == "BOR수정")
                {
                    BORVO bor = new BORVO
                    {
                        BOR_id = bor_id,
                        product_id = cboProductName.SelectedValue.ToString(),
                        process_name = cboProcessName.Text,
                        m_id = Convert.ToInt32(cboMachine.SelectedValue),
                        bor_tacttime = Convert.ToInt32(txtTactTime.Text),
                        bor_yn = cboYN.Text,
                        bor_comment = txtComment.Text,
                        bor_uadmin = txtUadmin.Text
                    };

                    BORService service = new BORService();
                    bool bResult = service.BORUpdate(bor);
                    if (bResult)
                    {
                        MessageBox.Show("BOR항목을 수정하셨습니다");
                    }
                    else
                    {
                        MessageBox.Show("수정에 실패하셨습니다");
                    }
                }

                this.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void setBORInfo()
        {

        }


        /// <summary>
        /// TactTime에 숫자만 입력되도록 필터링
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTactTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 닫기버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 취소버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
