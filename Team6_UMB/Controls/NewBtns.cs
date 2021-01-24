using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team6_UMB.Controls
{
    public partial class NewBtns : UserControl
    {
        public event EventHandler btnBarCode_Event;
        public event EventHandler btnShipment_Event;
        public event EventHandler btnDocument_Event;
        public event EventHandler btnSearch_Event;
        public event EventHandler btnWait_Event;
        public event EventHandler btnRefresh_Event;
        public event EventHandler btnCreate_Event;
        public event EventHandler btnUpdate_Event;
        public event EventHandler btnDelete_Event;
        public event EventHandler btnExcel_Event;
        public event EventHandler btnPrint_Event;

        public NewBtns()
        {
            InitializeComponent();
            btnBarCode.Click += BtnBarCode_Click;
            btnShipment.Click += BtnShipment_Click;
            btnDocument.Click += BtnDocument_Click;
            btnSearch.Click += BtnSearch_Click;
            btnWait.Click += BtnWait_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnExcel.Click += BtnExcel_Click;
            btnPrint.Click += BtnPrint_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (this.btnRefresh_Event != null)
                btnRefresh_Event(sender, e);
        }

        private void BtnWait_Click(object sender, EventArgs e)
        {
            if (this.btnWait_Event != null)
                btnWait_Event(sender, e);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (this.btnSearch_Event != null)
                btnSearch_Event(sender, e);
        }

        private void BtnDocument_Click(object sender, EventArgs e)
        {
            if (this.btnDocument_Event != null)
                btnDocument_Event(sender, e);
        }

        private void BtnShipment_Click(object sender, EventArgs e)
        {
            if (this.btnShipment_Event != null)
                btnShipment_Event(sender, e);
        }

        private void BtnBarCode_Click(object sender, EventArgs e)
        {
            if (this.btnBarCode_Event != null)
                btnBarCode_Event(sender, e);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (this.btnPrint_Event != null)
                btnPrint_Event(sender, e);
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (this.btnExcel_Event != null)
                btnExcel_Event(sender, e);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.btnDelete_Event != null)
                btnDelete_Event(sender, e);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.btnUpdate_Event != null)
                btnUpdate_Event(sender, e);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (this.btnCreate_Event != null)
                btnCreate_Event(sender, e);
        }
        // 
        //BC => 바코드버튼 (btnBarCode)
        //출하 => 출하버튼 (btnShipment)
        //명세서 => 거래명세서 (btnDocument)
        //조회 => 이력조회 (btnSearch)
        //대기 => 입고대기 (btnWait)
        //Re => 새로고침 (btnRefresh)
        //등록 => 등록 (btnCreate)
        //수정 => 수정 (btnUpdate)
        //삭제 => 삭제 (btnDelete)
        //엑셀 => 엑셀 (btnExcel)
        //출력 => 출력 (btnPrint)
    }
}
