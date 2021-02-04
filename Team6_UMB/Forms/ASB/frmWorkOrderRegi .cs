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
using UMB_VO.ASB;

namespace Team6_UMB.Forms
{
    public partial class frmWorkOrderRegi : Form
    {
        // wo_id, so_id, product_id, product_name, m_id, m_name, wo_pcount, wo_count, wo_date, wo_sdate, wo_state, wo_uadmin, wo_udate
        List<WorkOrderVO> woList = null;
        CheckBox headerCheck = new CheckBox();

        public frmWorkOrderRegi()
        {
            InitializeComponent();
        }

        private void frmWorkOrderRegi_Load(object sender, EventArgs e)
        {
            //데이터그리드뷰 컬럼 추가
            dgvOrder.AutoGenerateColumns = false;
            dgvOrder.AllowUserToAddRows = false;
            dgvOrder.MultiSelect = false;
            dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
            CommonUtil.AddGridTextColumn(dgvOrder, "WO_NUM", "wo_id", 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "수주번호", "so_id", 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "제품ID", "product_id", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "제품명", "product_name", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "설비ID", "m_id", 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "설비명", "m_name", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "수주량", "wo_pcount", 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "지시량", "wo_count", 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "지시일", "wo_date", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업시작일", "wo_sdate", 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "상태", "wo_state", 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "수정자", "wo_uadmin", 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "수정일", "wo_udate", 120);

            DGV_Binding();
        }

        private void DGV_Binding()
        {
            WorkOrderService service = new WorkOrderService();
            woList = service.GetWoList();
            dgvOrder.DataSource = woList;
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
    }
}
