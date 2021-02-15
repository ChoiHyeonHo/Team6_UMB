using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms.JSJ
{
    public partial class frmShipment : Team6_UMB.BaseForm.frmList
    {
        List<ShipSOVO> SOList;
        List<ShipmentVO> ShipList;
        ShipWaitVO ShipWaitVO = new ShipWaitVO();
        ShipmentVO ShipmentVO = new ShipmentVO();

        public frmShipment(bool Authority)
        {
            InitializeComponent();

            if (Authority == false)
            {
                newBtns1.btnShipment.Visible = false;
                newBtns1.btnWait.Visible = false;
            }
        }

        private void frmShipment_Load(object sender, EventArgs e)
        {
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnCreate.Visible = false;
            newBtns1.btnDelete.Visible = false;
            newBtns1.btnExcel.Visible = false;
            newBtns1.btnSearch.Visible = false;
            newBtns1.btnUpdate.Visible = false;
            newBtns1.btnPrint.Visible = false;

            CommonUtil.SetInitGridView(dgvList);
            CommonUtil.AddGridTextColumn(dgvList, "수주번호", "so_id", 200);
            CommonUtil.AddGridTextColumn(dgvList, "업체명", "company_name", 300);
            CommonUtil.AddGridTextColumn(dgvList, "품목명", "product_name", 300);
            CommonUtil.AddGridTextColumn(dgvList, "납기일", "so_edate", 250);
            CommonUtil.AddGridTextColumn(dgvList, "주문수량", "so_ocount", 250);
            CommonUtil.AddGridTextColumn(dgvList, "담당자", "so_rep", 250);
            CommonUtil.AddGridTextColumn(dgvList, "상태", "so_state", 250);

            CommonUtil.SetInitGridView(dgvShipment);
            CommonUtil.AddGridTextColumn(dgvShipment, "출하번호", "ship_id", 150);
            CommonUtil.AddGridTextColumn(dgvShipment, "업체명", "company_name", 200);
            CommonUtil.AddGridTextColumn(dgvShipment, "품목명", "product_name", 200);
            CommonUtil.AddGridTextColumn(dgvShipment, "출하수량", "ship_count", 200);
            CommonUtil.AddGridTextColumn(dgvShipment, "출하일", "ship_edate", 200);
            CommonUtil.AddGridTextColumn(dgvShipment, "상태", "ship_state", 200);

            SOListBind();
            ShipListBind();
        }

        public void SOListBind()
        {
            ShipmentService service = new ShipmentService();
            SOList = service.ShipmentSOList();
            dgvList.DataSource = SOList;
        }

        public void ShipListBind()
        {
            ShipmentService service = new ShipmentService();
            ShipList = service.ShipmentList();
            dgvShipment.DataSource = ShipList;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShipWaitVO.so_id = Convert.ToInt32(dgvList[0, e.RowIndex].Value);
                ShipWaitVO.ship_count = Convert.ToInt32(dgvList[4, e.RowIndex].Value);
                ShipWaitVO.ship_state = dgvList[6, e.RowIndex].Value.ToString();
                if(dgvList[2, e.RowIndex].Value.ToString() == "L_UMB1")
                {
                    ShipWaitVO.product_id = "P1001";
                }
                else
                {
                    ShipWaitVO.product_id = "P1002";
                }
            }
        }

        private void newBtns1_btnShipment_Event(object sender, EventArgs e)
        {
            if(ShipmentVO.ship_state == "출하가능")
            {
                ShipmentService service = new ShipmentService();
                if(service.Shipment(ShipmentVO) == 1)
                {
                    MessageBox.Show("출하완료");
                }
            }
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            SOListBind();
            ShipListBind();
        }

        private void newBtns1_btnWait_Event(object sender, EventArgs e)
        {
            ShipmentService service = new ShipmentService();
            if (ShipWaitVO.ship_state == "출하대기 가능")
            {
                if (service.ShipWait(ShipWaitVO) != 0)
                {
                    MessageBox.Show("출하대기 완료");
                }
            }
            else
            {
                MessageBox.Show("재고가 부족합니다.");
            }
        }

        private void newBtns1_btnDocument_Event(object sender, EventArgs e)
        {

        }

        private void dgvShipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShipmentVO.ship_id = Convert.ToInt32(dgvShipment[0, e.RowIndex].Value);
                ShipmentVO.ship_state = dgvShipment[5, e.RowIndex].Value.ToString();
                ShipmentVO.ship_count = Convert.ToInt32(dgvShipment[3, e.RowIndex].Value);
                if (dgvShipment[2, e.RowIndex].Value.ToString() == "L_UMB1")
                {
                    ShipmentVO.product_id = "P1001";
                }
                else
                {
                    ShipmentVO.product_id = "P1002";
                }
            }
        }
    }
}
