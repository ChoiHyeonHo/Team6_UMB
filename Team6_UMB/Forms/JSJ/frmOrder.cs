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
    public partial class frmOrder : Team6_UMB.frmPopUp
    {
        List<OrderPlistVO> list = new List<OrderPlistVO>();
        List<OrderVO> orderList;
        int order_id = 0;
        int rowindex;
        public frmOrder()
        {
            InitializeComponent();
        }

        public frmOrder(int order_id)
        {
            InitializeComponent();
            this.order_id = order_id;
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvCompany);
            CommonUtil.AddGridTextColumn(dgvCompany, "업체명", "company_name", 200);
            CommonUtil.SetInitGridView(dgvProduct);
            CommonUtil.AddGridTextColumn(dgvProduct, "업체명", "company_name", 200);
            CommonUtil.AddGridTextColumn(dgvProduct, "업체번호", "company_id", 0, false);
            CommonUtil.AddGridTextColumn(dgvProduct, "품목명", "product_name", 200);
            CommonUtil.AddGridTextColumn(dgvProduct, "품목번호", "product_id", 0, false);
            CommonUtil.AddGridTextColumn(dgvProduct, "현재고", "", 120);
            //CommonUtil.AddGridTextColumn(dgvProduct, "발주수량", "", 120);
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = "";
            col.HeaderText = "발주수량";
            col.Width = 120;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProduct.Columns.Add(col);

            OrderService service = new OrderService();
            list = service.OrderPList();
            dgvCompany.DataSource = service.CompanyList();
            if(order_id != 0)
            {
                label1.Text = "발주 수정";
            }
        }

        private void dgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                dgvProduct.DataSource = SearchProd(list, dgvCompany[0, e.RowIndex].Value.ToString());
            }
        }

        public List<OrderPlistVO> SearchProd(List<OrderPlistVO> SearchList, string company_name)
        {
            var list = (from item in SearchList
                        where item.company_name.Contains(company_name)
                        select item).ToList();
            return list;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OrderService service = new OrderService();
            if (order_id == 0)
            {
                orderList[0].order_edate = dtpEdate.Text;
                if(service.RegistOrder(orderList) != 0)
                {
                    MessageBox.Show("발주 완료");
                    this.Close();                    
                }              
            }
            else
            {

            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = e.RowIndex;
        }

        private void dgvProduct_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvProduct[5, rowindex].Value.ToString().Trim() != "")
                {
                    if (orderList == null)
                        orderList = new List<OrderVO>();

                    string prodID = dgvProduct[3, rowindex].Value.ToString();
                    int idx = orderList.FindIndex(p => p.product_id == prodID);
                    if (idx > -1)
                    {
                        orderList[idx].order_count = Convert.ToInt32(dgvProduct[5, rowindex].Value);
                    }
                    else
                    {
                        OrderVO newItem = new OrderVO();
                        newItem.product_id = dgvProduct[3, rowindex].Value.ToString();
                        newItem.company_id = Convert.ToInt32(dgvProduct[1, rowindex].Value);
                        newItem.order_count = Convert.ToInt32(dgvProduct[5, rowindex].Value);
                        orderList.Add(newItem);
                    }
                }
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
