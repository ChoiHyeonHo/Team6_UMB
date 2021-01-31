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
    public partial class frmSOPopUP : Team6_UMB.frmPopUp
    {
        List<SOPListVO> list = new List<SOPListVO>();
        List<SOVO> soList;
        int so_id = 0;
        int rowindex;

        public frmSOPopUP()
        {
            InitializeComponent();
        }

        public frmSOPopUP(int so_id)
        {
            InitializeComponent();
            this.so_id = so_id;
        }

        private void frmSOPopUP_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvCompany);
            CommonUtil.AddGridTextColumn(dgvCompany, "업체명", "company_name", 200);
            CommonUtil.SetInitGridView(dgvProd);
            CommonUtil.AddGridTextColumn(dgvProd, "업체명", "company_name", 200);
            CommonUtil.AddGridTextColumn(dgvProd, "업체번호", "company_id", 0, false);
            CommonUtil.AddGridTextColumn(dgvProd, "품목명", "product_name", 200);
            CommonUtil.AddGridTextColumn(dgvProd, "품목번호", "product_id", 0, false);
            CommonUtil.AddGridTextColumn(dgvProd, "현재고", "", 120);
            //CommonUtil.AddGridTextColumn(dgvProduct, "발주수량", "", 120);
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = "";
            col.HeaderText = "수주수량";
            col.Width = 120;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProd.Columns.Add(col);

            SOService service = new SOService();
            list = service.OrderPList();
            dgvCompany.DataSource = service.CompanyList();
            if (so_id != 0)
            {
                label1.Text = "발주 수정";
            }
        }

        private void dgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvProd.DataSource = SearchProd(list, dgvCompany[0, e.RowIndex].Value.ToString());
            }
        }

        public List<SOPListVO> SearchProd(List<SOPListVO> SearchList, string company_name)
        {
            var list = (from item in SearchList
                        where item.company_name.Contains(company_name)
                        select item).ToList();
            return list;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SOService service = new SOService();
            if (so_id == 0)
            {
                soList[0].so_edate = dtpEdate.Text;
                soList[0].so_rep = txtRep.Text;
                soList[0].so_comment = txtComment.Text;
                if (service.RegistSO(soList) != 0)
                {
                    MessageBox.Show("수주 완료");
                    this.Close();
                }
            }
            else
            {

            }
        }

        private void dgvProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = e.RowIndex;
        }

        private void dgvProd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvProd[5, rowindex].Value.ToString().Trim() != "")
                {
                    if (soList == null)
                        soList = new List<SOVO>();

                    string prodID = dgvProd[3, rowindex].Value.ToString();
                    int idx = soList.FindIndex(p => p.product_id == prodID);
                    if (idx > -1)
                    {
                        soList[idx].so_ocount = Convert.ToInt32(dgvProd[5, rowindex].Value);
                    }
                    else
                    {
                        SOVO newItem = new SOVO();
                        newItem.product_id = dgvProd[3, rowindex].Value.ToString();
                        newItem.company_id = Convert.ToInt32(dgvProd[1, rowindex].Value);
                        newItem.so_ocount = Convert.ToInt32(dgvProd[5, rowindex].Value);
                        soList.Add(newItem);
                    }
                }
            }
        }
    }
}
