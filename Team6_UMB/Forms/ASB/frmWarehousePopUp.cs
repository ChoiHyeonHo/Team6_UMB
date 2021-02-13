using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms.ASB
{
    public partial class frmWarehousePopUp : Team6_UMB.frmPopUp
    {
        WarehouseVO vo = null;

        public frmWarehousePopUp()
        {
            InitializeComponent();
        }

        public frmWarehousePopUp(WarehouseVO vo)
        {
            InitializeComponent();
            this.vo = vo;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("창고명을 입력해 주십시오.");
            }
            else if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("창고주소를 입력해 주십시오.");
            }
            else if (cboType.Text.Trim() == "")
            {
                MessageBox.Show("창고구분을 선택해 주십시오.");
            }
            else
            {
                if (label1.Text == "창고 정보")
                {
                    WarehouseVO vo = new WarehouseVO()
                    {
                        w_name = txtName.Text,
                        w_address = txtAddress.Text,
                        w_type = cboType.Text
                    };
                    WarehouseService service = new WarehouseService();
                    if(service.InsertWH(vo) == 1)
                    {
                        MessageBox.Show("창고정보 입력 완료");
                        this.Close();
                    }
                }
                else
                {
                    WarehouseVO vo = new WarehouseVO()
                    {
                        w_id = this.vo.w_id,
                        w_name = txtName.Text,
                        w_address = txtAddress.Text,
                        w_type = cboType.Text
                    };
                    WarehouseService service = new WarehouseService();
                    if (service.UpdateWH(vo) == 1)
                    {
                        MessageBox.Show("창고정보 수정 완료");
                        this.Close();
                    }
                }
            }
        }

        private void frmWarehousePopUp_Load(object sender, EventArgs e)
        {
            WarehouseService service = new WarehouseService();
            CommonUtil.ComboBinding(cboType, service.WType(), "창고구분");
            if (vo != null)
            {
                label1.Text = "창고 정보 수정";
                txtName.Text = vo.w_name;
                txtAddress.Text = vo.w_address;
                cboType.Text = vo.w_type;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
