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

namespace Team6_UMB.Forms.JSJ
{
    public partial class frmIncommingStatus : Team6_UMB.BaseForm.frmList
    {
        List<IncommingStatusVO> list = new List<IncommingStatusVO>();

        public frmIncommingStatus()
        {
            InitializeComponent();
        }

        private void frmIncommingStatus_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvIncomming);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고번호", "incomming_ID", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고상태", "incomming_state", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고일", "incomming_date", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "담당자", "incomming_rep", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "업체명", "company_name", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "품목명", "product_name", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "입고수량", "incomming_count", 200);
            CommonUtil.AddGridTextColumn(dgvIncomming, "검사결과", "orderexam_result", 200);

            Incomming();
        }

        public void Incomming()
        {
            IncommingService service = new IncommingService();
            list = service.IncommingStatus();
            dgvIncomming.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvIncomming.DataSource = SearchIncomming();
        }

        public List<IncommingStatusVO> SearchIncomming()
        {
            var SearchList = (from item in list
                        where item.company_name.Contains(txtCompany.Text) && item.product_name.Contains(txtProduct.Text)
                        && Convert.ToDateTime(periodSearchControl.dtFrom) <= Convert.ToDateTime(item.incomming_date) && Convert.ToDateTime(periodSearchControl.dtTo) >= Convert.ToDateTime(item.incomming_date)
                        select item).ToList();
            return SearchList;
        }
    }
}
