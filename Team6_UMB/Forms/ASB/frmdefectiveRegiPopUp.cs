using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team6_UMB.Service;
using UMB_VO;

namespace Team6_UMB.Forms.BMN
{
    public partial class frmdefectiveRegiPopUp : Form
    {
        string headName;
        string common_name;
        string common_value;
        int common_id;

        public frmdefectiveRegiPopUp(string headName)
        {
            InitializeComponent();
            this.headName = headName;
        }        

        public frmdefectiveRegiPopUp(string headName, string common_name, string common_value)
        {
            InitializeComponent();
            DefService service = new DefService();
            this.headName = headName;
            this.common_name = common_name;
            this.common_value = common_value;
            this.common_id = service.GetDefID(common_name);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(txtdefname.Text.Trim().Length < 1 || txtdefcomment.Text.Trim().Length < 1)
            {
                MessageBox.Show("필수항목을 채워주세요");
                return;
            }
            try
            {
                if(headName == "불량유형추가")
                {
                    ComboItemVO def = new ComboItemVO
                    {
                        common_name = txtdefname.Text,
                        common_value = txtdefcomment.Text
                    };

                    
                    DefService service = new DefService();
                    bool bResult = service.DefInsert(def);
                    if (bResult)
                    {
                        MessageBox.Show("새로운 불량유형 등록하였습니다");
                    }
                    else
                    {
                        MessageBox.Show("등록에 실패하셨습니다");
                    }
                }
                else if(headName == "불량유형수정")
                {
                    ComboItemVO def = new ComboItemVO
                    {
                        common_id = common_id,
                        common_name = txtdefname.Text,
                        common_value = txtdefcomment.Text
                    };
                    DefService service = new DefService();
                    bool bResult = service.DefUpdate(def);
                    if (bResult)
                    {
                        MessageBox.Show("불량유형을 수정하였습니다");
                    }
                    else
                    {
                        MessageBox.Show("수정에 실패하셨습니다");
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
