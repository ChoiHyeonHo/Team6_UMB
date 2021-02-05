using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms
{
    public partial class frmOrderStatus : Team6_UMB.BaseForm.frmList
    {
        List<OrderListVO> list = new List<OrderListVO>();
        CheckBox headerCheck = new CheckBox();
        int Order_id;

        public frmOrderStatus()
        {
            InitializeComponent();
        }

        private void newBtns1_btnCreate_Event(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            frm.ShowDialog();
            OrderList();
        }

        private void newBtns1_btnDelete_Event(object sender, EventArgs e)
        {
            OrderService service = new OrderService();
            if(service.DeleteOrder(Order_id) != 0)
            {
                MessageBox.Show(Properties.Resources.msgDelete, "삭제확인", MessageBoxButtons.YesNo);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int orderid;
            if(txtOrderID.Text == "")
            {
                orderid = 0;
            }
            else
            {
                orderid = int.Parse(txtOrderID.Text);
            }

            dgvOrder.DataSource = SearchOrder(list, orderid, txtCompany.Text);
        }

        public List<OrderListVO> SearchOrder(List<OrderListVO> SearchList, int OrderID, string Company)
        {
            var list = (from item in SearchList
                        where (OrderID != 0) ? item.order_id == OrderID && item.company_name.Contains(Company) : item.company_name.Contains(Company)
                        select item).ToList();
            return list;
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Order_id = Convert.ToInt32(dgvOrder[0, e.RowIndex].Value);
        }

        private void frmOrderStatus_Load(object sender, EventArgs e)
        {
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnSearch.Visible = false;
            newBtns1.btnShipment.Visible = false;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvOrder.Columns.Add(chk);

            //Header체크 속성추가
            Point point = dgvOrder.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheck.Location = new Point(point.X + 8, point.Y + 2);
            headerCheck.BackColor = Color.White;
            headerCheck.Size = new Size(18, 18);
            headerCheck.Click += HeaderCheck_Click;
            dgvOrder.Controls.Add(headerCheck);

            CommonUtil.SetInitGridView(dgvOrder);
            CommonUtil.AddGridTextColumn(dgvOrder, "발주번호", "order_id", 200);
            CommonUtil.AddGridTextColumn(dgvOrder, "업체명", "company_name", 300);
            CommonUtil.AddGridTextColumn(dgvOrder, "품목명", "product_name", 300);
            CommonUtil.AddGridTextColumn(dgvOrder, "발주수량", "order_count", 200);
            CommonUtil.AddGridTextColumn(dgvOrder, "발주일", "order_date", 200);
            CommonUtil.AddGridTextColumn(dgvOrder, "납기일", "order_edate", 200);
            CommonUtil.AddGridTextColumn(dgvOrder, "담당자", "user_name", 200);

            OrderList();
        }

        private void HeaderCheck_Click(object sender, EventArgs e)
        {
            dgvOrder.EndEdit(); //현재 포커스가 있는 셀의 편집을 종료 (다른 셀로 이동시킨 것과 같은 효과)

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                chk.Value = headerCheck.Checked;
            }
        }

        public void OrderList()
        {
            OrderService service = new OrderService();
            list = service.OrderList();
            dgvOrder.DataSource = list;
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            OrderList();
        }

        private void newBtns1_btnWait_Event(object sender, EventArgs e)
        {
            IncommingService service = new IncommingService();
            List<IncommingVO> list = new List<IncommingVO>();
            IncommingVO vo;

            foreach(DataGridViewRow row in dgvOrder.Rows)
            {
                bool bCheck = (bool)row.Cells["chk"].EditedFormattedValue;
                if(bCheck)
                {
                    vo = new IncommingVO();
                    vo.incomming_count = Convert.ToInt32(row.Cells["order_count"].Value);
                    vo.incomming_rep = row.Cells["user_name"].Value.ToString();
                    vo.order_id = Convert.ToInt32(row.Cells["order_id"].Value);
                    list.Add(vo);
                }
            }
            if (list.Count == 0)
            {
                MessageBox.Show("입고대기 목록을 선택해주십시오.");
            }
            else
            {
                if (service.IncommingWait(list) == 1)
                {
                    MessageBox.Show("입고대기 처리완료");
                    OrderList();
                }
            }
        }
    }
}
