using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Team6_UMB.Forms.CHH
{
    public partial class frmAddressAPI : Team6_UMB.frmPopUp
    {
        string zip, address1, address2;
        public string ZipCode
        {
            get { return zip; }
        }

        public string Address1
        {
            get { return address1; }
        }

        
        public string Address2
        {
            get { return address2; }
        }

        

        public frmAddressAPI()
        {
            InitializeComponent();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSearch.PerformClick();
            }
        }

        private void dgvRoadAPI_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtRoadZipcode.Text = dgvRoadAPI["zipNo", e.RowIndex].Value.ToString();
                txtRoadAddr1.Text = dgvRoadAPI["roadAddrPart1", e.RowIndex].Value.ToString();
                txtRoadAddr2.Text = dgvRoadAPI["roadAddrPart2", e.RowIndex].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    MessageBox.Show("검색하실 주소를 입력하세요.");
                    return;
                }
                string url = "http://www.juso.go.kr/addrlink/addrLinkApi.do";
                string apiKey = ConfigurationManager.AppSettings["RoadAPIKey"].ToString();

                string apiUrl = $"{url}?confmKey={apiKey}&currentPage=1&countPerPage=1000&keyword={txtSearch.Text.Trim()}";
                WebClient wc = new WebClient();
                XmlReader reader = new XmlTextReader(wc.OpenRead(apiUrl));
                DataSet ds = new DataSet();
                ds.ReadXml(reader);

                if (ds.Tables.Count > 1)
                    dgvRoadAPI.DataSource = ds.Tables[1];
                else
                    MessageBox.Show(ds.Tables[0].Rows[0]["errorMessage"].ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void btnRoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRoadAddr1.Text.Length > 0)
                {
                    this.zip = txtRoadZipcode.Text;
                    this.address1 = txtRoadAddr1.Text;
                    this.address2 = txtRoadAddr2.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("주소를 검색하여 선택해주세요.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
