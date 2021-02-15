using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Team6_UMB;
using Team6_UMB.Service;
using UMB_POP.Back;
using UMB_POP.Service;
using UMB_VO;
using UMB_VO.ASB;

namespace UMB_POP
{
    public partial class frmPOP : Form
    {
        //전역변수
        List<PerformanceVO> waitList;
        List<PerformanceVO> workList;
        List<PerformanceVO> endList;
        int performance_id, production_id, wo_id, performance_qtyimport, performance_qty_ok, performance_qty_ng;
        int tacttime;
        string production_state;
        System.Timers.Timer timer;        
        POPClient client;

        public PerformanceVO WorkInfo { get; set; }

        public frmPOP()
        {
            InitializeComponent();            
        }        

        private void Form1_Load(object sender, EventArgs e)
        {            
            //공정명 콤보박스
            string[] gubun = { "공정명" };
            ProductService processService = new ProductService();
            List<ComboItemVO> allProcessItem = processService.GetProcessInfoByCodeTypes(gubun);
            CommonUtil.ComboBinding(cboProcessname, allProcessItem, "공정명");

            //작업대기DGV
            CommonUtil.SetInitGridView(dgvWaitWork);
            CommonUtil.AddGridTextColumn(dgvWaitWork, "작업지시ID", "wo_id", 200);
            CommonUtil.AddGridTextColumn(dgvWaitWork, "생산실적ID", "performance_id", 200);
            CommonUtil.AddGridTextColumn(dgvWaitWork, "생산ID", "production_id", 120);
            CommonUtil.AddGridTextColumn(dgvWaitWork, "품목ID", "product_id", 180);
            CommonUtil.AddGridTextColumn(dgvWaitWork, "품목명", "product_name", 250);
            CommonUtil.AddGridTextColumn(dgvWaitWork, "공정명", "process_name", 320);            
            CommonUtil.AddGridTextColumn(dgvWaitWork, "생산요청수량", "performance_qtyimport", 250);
            CommonUtil.AddGridTextColumn(dgvWaitWork, "설비명", "m_name", 250);
            CommonUtil.AddGridTextColumn(dgvWaitWork, "상태", "production_state", 180);
            CommonUtil.AddGridTextColumn(dgvWaitWork, "생산시작일", "production_sdate", 250);
            
            //작업진행중DGV
            CommonUtil.SetInitGridView(dgvWorking);
            CommonUtil.AddGridTextColumn(dgvWorking, "작업지시ID", "wo_id", 200);            
            CommonUtil.AddGridTextColumn(dgvWorking, "생산ID", "production_id", 120);
            CommonUtil.AddGridTextColumn(dgvWorking, "생산실적ID", "performance_id", 200);
            CommonUtil.AddGridTextColumn(dgvWorking, "품목ID", "product_id", 180);
            CommonUtil.AddGridTextColumn(dgvWorking, "품목명", "product_name", 250);
            CommonUtil.AddGridTextColumn(dgvWorking, "공정명", "process_name", 320);
            CommonUtil.AddGridTextColumn(dgvWorking, "양품수량", "performance_qty_ok", 150);
            CommonUtil.AddGridTextColumn(dgvWorking, "불량수량", "performance_qty_ng", 150);
            CommonUtil.AddGridTextColumn(dgvWorking, "생산요청수량", "performance_qtyimport", 250);
            CommonUtil.AddGridTextColumn(dgvWorking, "설비명", "m_name", 250);
            CommonUtil.AddGridTextColumn(dgvWorking, "상태", "production_state", 180);
            CommonUtil.AddGridTextColumn(dgvWorking, "생산시작일", "production_sdate", 250);

            //작업종료DGV
            CommonUtil.SetInitGridView(dgvEndWork);
            CommonUtil.AddGridTextColumn(dgvEndWork, "작업지시ID", "wo_id", 200);            
            CommonUtil.AddGridTextColumn(dgvEndWork, "생산ID", "production_id", 120);
            CommonUtil.AddGridTextColumn(dgvEndWork, "생산실적ID", "performance_id", 200);
            CommonUtil.AddGridTextColumn(dgvEndWork, "품목ID", "product_id", 180);
            CommonUtil.AddGridTextColumn(dgvEndWork, "품목명", "product_name", 250);
            CommonUtil.AddGridTextColumn(dgvEndWork, "공정명", "process_name", 320);
            CommonUtil.AddGridTextColumn(dgvEndWork, "양품수량", "performance_qty_ok", 150);
            CommonUtil.AddGridTextColumn(dgvEndWork, "불량수량", "performance_qty_ng", 150);
            CommonUtil.AddGridTextColumn(dgvEndWork, "생산요청수량", "performance_qtyimport", 250);
            CommonUtil.AddGridTextColumn(dgvEndWork, "설비명", "m_name", 250);
            CommonUtil.AddGridTextColumn(dgvEndWork, "상태", "production_state", 180);
            CommonUtil.AddGridTextColumn(dgvEndWork, "생산시작일", "production_sdate", 250);
            CommonUtil.AddGridTextColumn(dgvEndWork, "생산종료일", "production_edate", 250);

            DGV_Binding();
            changePeriod();
            GetTime();
        }

        private void GetTime()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (!this.IsDisposed && timer.Enabled)
                {
                    this.Invoke(new Action(delegate ()
                    { lb_time.Text = DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss"); }
                    ));
                }
            }
            catch (Exception ex)
            {
                // 시간관련하여 컨트롤에 에러가 발생한 경우 
                //CustomMessageBox.ShowDialog("에러", ex.Message, MessageBoxIcon.Error);
                if (timer.Enabled)
                {
                    timer.Stop();
                    timer.Enabled = false;
                    timer.Close();
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void DGV_Binding()
        {
            POPService serviceWa = new POPService();
            waitList = serviceWa.GetWaitPerList();
            dgvWaitWork.DataSource = waitList;

            POPService serviceW = new POPService();
            workList = serviceW.GetWorkPerList();
            dgvWorking.DataSource = workList;

            POPService serviceE = new POPService();
            endList = serviceE.GetEndPerList();
            dgvEndWork.DataSource = endList;

        }

        //작업대기dgv클릭
        private void dgvWaitWork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                
                production_state = dgvWaitWork.Rows[e.RowIndex].Cells[8].Value.ToString();
                performance_id = Convert.ToInt32(dgvWaitWork.Rows[e.RowIndex].Cells[1].Value);
                production_id = Convert.ToInt32(dgvWaitWork.Rows[e.RowIndex].Cells[2].Value);
                wo_id = Convert.ToInt32(dgvWaitWork.Rows[e.RowIndex].Cells[0].Value);
                txtProductID.Text = dgvWaitWork.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtProductName.Text = dgvWaitWork.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtMachineName.Text = dgvWaitWork.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtProcessName.Text = dgvWaitWork.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtcount.Text = dgvWaitWork.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtpcount.Text = txtok.Text = txtng.Text = "0";
                
            }                 
        }

        //작업중dgv클릭
        private void dgvWorking_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEndWork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            performance_id = Convert.ToInt32(dgvWaitWork.Rows[e.RowIndex].Cells[2].Value);
            production_id = Convert.ToInt32(dgvWaitWork.Rows[e.RowIndex].Cells[1].Value);
        }

        // 생산을 시작하는 경우
        public void ProduceStart()
        {
            try
            {                
                if (production_state == "작업대기")
                {
                    POPService service = new POPService();
                    bool bresult = service.updatePOP(wo_id);
                    if (!bresult) return;
                    DGV_Binding();                                        
                    //서버와 연결되어있지 않은경우
                    if (!client.Connected)
                    {
                        bool bConnect = client.Connected;

                        if (!bConnect)
                        {
                            MessageBox.Show("서버와 다시 연결합니다");
                            ConnectServer();
                        }
                    }
                    //서버와 연결된 경우 (정상실행)
                    else
                    {
                        MessageBox.Show("서버와 연결되었습니다.");
                        
                    }
                }                
                else
                {
                    
                }

            }
            catch (Exception ex)
            {
                WriteLog(ex);
                
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(dgvWaitWork.SelectedRows.Count < 1)
            {
                MessageBox.Show("시작할데이터를 선택하여 주세요");
                return;
            }
            // 처음 접속인 경우
            if (client == null)
            {
                // 서버와 연결함
                ConnectServer();
                Thread.Sleep(100);
                ProduceStart();
            }
            else
            {
                // 기존 서버와 연결을 끊고 다시 생산시작을 가동
                client = null;
                btnStart.PerformClick();
            }

        }

        // 서버에 연결하는 코드
        private void ConnectServer()
        {
            POPService service = new POPService();
            client = new POPClient()
            {
                performance_id = WorkInfo.performance_id
            };
            if (client.Connect())
            {
                client.performance_id = performance_id;
                client.production_id = production_id;
                client.performance_qtyimport = Convert.ToInt32(txtcount.Text);
                client.time = service.setTacttime(txtProductID.Text);
                client.Certification();
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void btnNg_Click(object sender, EventArgs e)
        {

        }

        private void btnPeriodSearch_Click(object sender, EventArgs e)
        {
            changePeriod();
            MessageBox.Show($"{dtpstart.Value.ToShortDateString()}로 조회합니다.");
        }

        private void changePeriod()
        {
            if (dgvWaitWork.DataSource != null)
            {
                string FromDate = dtpstart.Value.ToShortDateString();

                List<PerformanceVO> list = (from wa in waitList
                                                     where FromDate == wa.production_sdate
                                                     select wa).ToList();
                dgvWaitWork.DataSource = list;
            }
            if (dgvWorking.DataSource != null)
            {
                string FromDate = dtpstart.Value.ToShortDateString();

                List<PerformanceVO> list = (from wa in workList
                                                     where FromDate == wa.production_sdate
                                                     select wa).ToList();
                dgvWorking.DataSource = list;
            }
            if (dgvEndWork.DataSource != null)
            {
                string FromDate = dtpstart.Value.ToShortDateString();

                List<PerformanceVO> list = (from wa in endList
                                                     where FromDate == wa.production_sdate
                                                     select wa).ToList();
                dgvEndWork.DataSource = list;
            }
        }

        private void WriteLog(Exception ex)
        {
            Program.Log.WriteError(ex.Message, ex);
        }
    }
}
