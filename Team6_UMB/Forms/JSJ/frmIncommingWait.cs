using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms
{
    public partial class frmIncommingWait : Team6_UMB.frmBaseList
    {
        CheckBox headerCheck = new CheckBox();
        List<OrderListVO> OList;

        public frmIncommingWait(bool Authority)
        {
            InitializeComponent();

            if (Authority == false)
            {
                newBtns1.btnWait.Visible = false;
            }
        }

        private void frmIncommingWait_Load(object sender, EventArgs e)
        {
            newBtns1.btnBarCode.Visible = false;
            newBtns1.btnDocument.Visible = false;
            newBtns1.btnSearch.Visible = false;
            newBtns1.btnShipment.Visible = false;
            newBtns1.btnCreate.Visible = false;
            newBtns1.btnDelete.Visible = false;
            newBtns1.btnExcel.Visible = false;
            newBtns1.btnPrint.Visible = false;
            newBtns1.btnUpdate.Visible = false;

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

        public void OrderList()
        {
            IncommingService service = new IncommingService();
            OList = service.OrderList();
            dgvOrder.DataSource = OList;
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

        private void newBtns1_btnWait_Event(object sender, EventArgs e)
        {
                        
        }

        private void newBtns1_btnRefresh_Event(object sender, EventArgs e)
        {
            OrderList();
        }
    }
}
