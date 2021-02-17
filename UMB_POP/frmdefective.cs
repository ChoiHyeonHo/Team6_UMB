using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team6_UMB;
using Team6_UMB.Service;
using UMB_POP.Service;
using UMB_VO;

namespace UMB_POP
{
    public partial class frmdefective : Form
    {
        int performance_id, common_id ,count;
        public frmdefective(int performance_id)
        {
            lblper.Text = performance_id.ToString();

            InitializeComponent();
        }

        private void frmdefective_Load(object sender, EventArgs e)
        {
            string[] gubun = { "불량유형" };
            CheckListService cService = new CheckListService();
            List<ComboItemVO> allCheckType = cService.GetCheckTypeInfoByCodeTypes(gubun);

            CommonUtil.ComboBinding(cboDef, allCheckType, "불량유형");
        }

        private void btnCreat_Click(object sender, EventArgs e)
        {
            performance_id = int.Parse(lblper.Text);
            common_id = Convert.ToInt32(cboDef.SelectedValue);
            count = int.Parse(txtngcount.Text);
            POPService service = new POPService();
            this.Close();

        }
    }
}
