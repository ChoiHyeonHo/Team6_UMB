using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team6_UMB.Forms
{
    public partial class frmCompanyPopUp : Team6_UMB.frmPopUp
    {
        public frmCompanyPopUp()
        {
            InitializeComponent();
        }
        public frmCompanyPopUp(int company_id, string company_name, string company_type, string company_ceo, string company_cnum, string company_btype, string company_gtype, string company_email, string company_phone, string company_fax, string company_address, string company_uadmin, string company_udate, string company_comment)
        {
            InitializeComponent();

        }
    }
}
