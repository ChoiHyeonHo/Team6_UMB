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
    public partial class frmSalesStatus : Team6_UMB.BaseForm.frmList
    {
        List<SalesVO> list = new List<SalesVO>();
        public frmSalesStatus()
        {
            InitializeComponent();
        }

        public void SalesList()
        {
            SalesService service = new SalesService();
            list = service.SalesList();
            dgvSales.DataSource = list;
        }

        private void frmSalesStatus_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvSales);
            CommonUtil.AddGridTextColumn(dgvSales, "업체명", "company_name", 200);
            CommonUtil.AddGridTextColumn(dgvSales, "품목명", "product_name", 200);
            CommonUtil.AddGridTextColumn(dgvSales, "출하수량", "ship_count", 200, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSales, "매출액", "sales_price", 200, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSales, "출하일", "sales_date", 200);

            SalesList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
