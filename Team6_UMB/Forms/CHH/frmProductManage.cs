using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO.CHH;

namespace Team6_UMB.Forms
{
    public partial class frmProductManage : Team6_UMB.frmBaseList
    {
        ProdStatusService service;
        List<ProdStatusVO> allList;
        int product_lorder_count, product_safety_count, company_id, w_id;
        string product_id, product_name, product_type, product_unit, w_name, company_name, product_exam, product_stnd, product_comment, product_deleted;

        

        public frmProductManage()
        {
            InitializeComponent();
            newBtns.btnShipment.Visible = newBtns.btnWait.Visible = newBtns.btnSearch.Visible = newBtns.btnDocument.Visible = false;
        }

        private void frmProductManage_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvProduct);
            CommonUtil.AddGridTextColumn(dgvProduct, "번호", "product_id", 60);                   //0
            CommonUtil.AddGridTextColumn(dgvProduct, "품목명", "product_name", 150);              //1
            CommonUtil.AddGridTextColumn(dgvProduct, "제품분류", "product_type", 100);            //2
            CommonUtil.AddGridTextColumn(dgvProduct, "단위", "product_unit", 100);                //3
            CommonUtil.AddGridTextColumn(dgvProduct, "창고명", "w_name", 150);                    //4
            CommonUtil.AddGridTextColumn(dgvProduct, "최소발주량", "product_lorder_count", 100);  //5
            CommonUtil.AddGridTextColumn(dgvProduct, "안전재고량", "product_safety_count", 100);  //6
            CommonUtil.AddGridTextColumn(dgvProduct, "업체명", "company_name", 170);              //7
            CommonUtil.AddGridTextColumn(dgvProduct, "검사여부", "product_exam", 90);             //8
            CommonUtil.AddGridTextColumn(dgvProduct, "규격", "product_stnd", 130);               //9
            CommonUtil.AddGridTextColumn(dgvProduct, "비고", "product_comment", 10, false);      //10
            CommonUtil.AddGridTextColumn(dgvProduct, "삭제여부", "product_deleted", 90);          //11
            CommonUtil.AddGridTextColumn(dgvProduct, "거래처id", "company_id", 10, false);        //12
            CommonUtil.AddGridTextColumn(dgvProduct, "창고id", "w_id", 10, false);                //13


            DGV_Binding();
        }

        private void DGV_Binding()
        {
            service = new ProdStatusService();
            allList = service.GetProdInfo();
            dgvProduct.DataSource = allList;
        }

        private void newBtns_btnRefresh_Event(object sender, EventArgs e)
        {
            DGV_Binding();
        }

        private void newBtns_btnCreate_Event(object sender, EventArgs e)
        {
            string headerName = "품목 등록";
            frmProductManagePopUp frm = new frmProductManagePopUp(headerName);
            frm.Show();
        }

        private void newBtns_btnUpdate_Event(object sender, EventArgs e)
        {
            string headerName = "품목 수정";
            frmProductManagePopUp frm = new frmProductManagePopUp(headerName, product_id, product_name, product_type, product_unit, w_name, product_lorder_count, product_safety_count, company_name, product_exam, company_id, w_id, product_stnd, product_comment, product_deleted);
            frm.Show();
        }

        private void newBtns_btnDelete_Event(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.msgDelete, "삭제확인 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                service = new ProdStatusService();
                bool result = service.Delete(product_id);

                if (result)
                {
                    MessageBox.Show(Properties.Resources.msgOK);
                    DGV_Binding();
                }
                else
                    MessageBox.Show(Properties.Resources.msgError);
            }
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            product_id = dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            product_name = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            product_type = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            product_unit = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            w_name = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            product_lorder_count = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString());
            product_safety_count = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString());
            company_name = dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString();
            product_exam = dgvProduct.Rows[e.RowIndex].Cells[8].Value.ToString();
            product_stnd = dgvProduct.Rows[e.RowIndex].Cells[9].Value.ToString();
            product_comment = dgvProduct.Rows[e.RowIndex].Cells[10].Value.ToString();
            company_id = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[12].Value.ToString());
            w_id = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[13].Value.ToString());
            product_deleted = dgvProduct.Rows[e.RowIndex].Cells[11].Value.ToString();
        }
    }
}
