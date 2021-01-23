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
            btnBarCode_Event += NewBtns_btnBarCode_Event;
            btnShipment_Event += NewBtns_btnShipment_Event;
            btnDocument_Event += NewBtns_btnDocument_Event;
            btnSearch_Event += NewBtns_btnSearch_Event;
            btnWait_Event += NewBtns_btnWait_Event;
            btnRefresh_Event += NewBtns_btnRefresh_Event;
            btnCreate_Event += NewBtns_btnCreate_Event;
            btnUpdate_Event += NewBtns_btnUpdate_Event;
            btnDelete_Event += NewBtns_btnDelete_Event;
            btnExcel_Event += NewBtns_btnExcel_Event;
            btnPrint_Event += NewBtns_btnPrint_Event;
        }

        private void NewBtns_btnPrint_Event(object sender, EventArgs e)
        {
            if (this.btnPrint_Event != null)
                btnPrint_Event(sender, e);
        }

        private void NewBtns_btnExcel_Event(object sender, EventArgs e)
        {
            if (this.btnExcel_Event != null)
                btnExcel_Event(sender, e);
        }

        private void NewBtns_btnDelete_Event(object sender, EventArgs e)
        {
            if (this.btnDelete_Event != null)
                btnDelete_Event(sender, e);
        }

        private void NewBtns_btnUpdate_Event(object sender, EventArgs e)
        {
            if (this.btnUpdate_Event != null)
                btnUpdate_Event(sender, e);
        }

        private void NewBtns_btnCreate_Event(object sender, EventArgs e)
        {
            if (this.btnCreate_Event != null)
                btnCreate_Event(sender, e);
        }

        private void NewBtns_btnRefresh_Event(object sender, EventArgs e)
        {
            if (this.btnRefresh_Event != null)
                btnRefresh_Event(sender, e);
        }

        private void NewBtns_btnWait_Event(object sender, EventArgs e)
        {
            if (this.btnWait_Event != null)
                btnWait_Event(sender, e);
        }

        private void NewBtns_btnSearch_Event(object sender, EventArgs e)
        {
            if (this.btnSearch_Event != null)
                btnSearch_Event(sender, e);
        }

        private void NewBtns_btnDocument_Event(object sender, EventArgs e)
        {
            if (this.btnDocument_Event != null)
                btnDocument_Event(sender, e);
        }

        private void NewBtns_btnShipment_Event(object sender, EventArgs e)
        {
            if (this.btnShipment_Event != null)
                btnShipment_Event(sender, e);
        }

        private void NewBtns_btnBarCode_Event(object sender, EventArgs e)
        {
            if (this.btnBarCode_Event != null)
                btnBarCode_Event(sender, e);
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
