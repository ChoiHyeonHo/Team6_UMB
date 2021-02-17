using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace UMB_POP.Back
{
    public delegate void ReceiveEventHandler(object sender, ReceiveEventArgs e);

    
    public class POPClient
    {
        //프로퍼티 생산실적ID, 요구수량
        public int performance_id { get; set; }
        public string product_id { get; set; }
        public int production_id { get; set; }
        public int performance_qtyimport { get; set; }
        public int time { get; set; }
        

        public bool Connected { get; set; }

        public event ReceiveEventHandler Received;

        // 이벤트발생이 필요함(생산완료 or 생산실패)
        // 어떤 라인인지 필요
        // 서버에 접속할 client 필요  (AppConfig에 추가할 목록)
        string host = ConfigurationManager.AppSettings["serverIP"];
        int port = 5000;

        IPAddress clientIPInfo = 
            Dns.GetHostEntry(Dns.GetHostName()).AddressList.ToList().Find(i => i.AddressFamily == AddressFamily.InterNetwork);        
        public NetworkStream netStream;
        
        System.Timers.Timer timer;
        public TcpClient client;
        

        // 빈 생성자
        public POPClient()
        {
            timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        // 매초 서버로부터 메세지를 수신받는 이벤트
        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (Connected && timer.Enabled)
                {
                    await Read();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
                //DisConnected();
            }
        }

        public void Start()
        {
            try
            {
                if (Connected && timer.Enabled)
                {
                    Writer(netStream, new object[] { performance_id, performance_qtyimport, product_id, time });
                }
                else if (Connected)
                {
                    timer.Enabled = true;
                    timer.Start();
                    Writer(netStream, new object[] { performance_id, performance_qtyimport, product_id, time });

                }
                else
                {
                    Connect();
                    Start();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
                
            }
        }

        // 서버 연결
        public bool Connect()
        {

            IPEndPoint clientIP = new IPEndPoint(IPAddress.Parse(host), port);
            client = new TcpClient(clientIP);
            try
            {
                client.ConnectAsync(IPAddress.Parse(host), port).Wait();
                client.NoDelay = true;

                netStream = client.GetStream();


                if (client.Connected)
                {
                    Connected = client.Connected;
                }

                return client.Connected;
            }
            catch (Exception ex)
            {
                WriteLog(ex);
                return client.Connected;
            }
        }

        public void DisConnected()
        {
            try
            {
                Connected = false;
                Task.Delay(2000);

                if (client != null)
                {

                    Writer(netStream, new object[] { 9 });
                    Task.Delay(1000);
                    timer.Stop();
                    timer.Enabled = false;
                    timer.Dispose();

                    Task.Delay(1000);
                    netStream.Close();
                    client.Close();
                    client.Dispose();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        // 서버에 송신메서드
        public void Writer(Stream stream, object[] objArr)
        {
            try
            {
                if (stream == null) return;

                if (!stream.CanWrite)
                    return;

                string ProductionInstruction = string.Join(",", objArr);
                StreamWriter writer = new StreamWriter(stream);

                writer.AutoFlush = true;
                writer.Write(ProductionInstruction);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        public void Certification()
        {
            try
            {
                Writer(netStream, new object[] { performance_id, product_id, performance_qtyimport, time});
            }
            catch (Exception ex)
            {
                WriteLog(ex);
                DisConnected();
            }
        }

        // 서버 수신메서드
        public async Task Read()
        {
            if (!netStream.CanRead) return;

            try
            {
                StreamReader reader = new StreamReader(netStream);

                string[] msg = (await reader.ReadLineAsync()).Split(',');

                if (msg.Length > 1)
                {
                    FormCollection frms = Application.OpenForms;

                    for (int i = 0; i < frms.Count; i++)
                    {
                        if (frms[i] == null)
                        {
                            continue;
                        }

                        if (frms[i] is frmPOP)
                        {
                            frmPOP pop = (frmPOP)frms[i];                            
                            if (pop.WorkInfo.performance_id == Convert.ToInt32(msg[0]))
                            {                                
                                ReceiveEventArgs e = new ReceiveEventArgs();
                                if (msg.Length == 5)
                                {
                                    e.LineID = int.Parse(msg[0]);
                                    e.Message = msg[1];
                                    e.PerformanceID = msg[2];
                                    e.IsCompleted = bool.Parse(msg[3]);
                                    e.QtyImport = int.Parse(msg[4]);
                                }
                                else if (msg.Length == 3)
                                {
                                    e.LineID = int.Parse(msg[0]);
                                    e.Message = msg[1];
                                    e.IsCompleted = bool.Parse(msg[2]);
                                }

                                if (e.Message != null)
                                {

                                    if (Received != null)
                                        Received?.Invoke(this, e);
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                WriteLog(ex);               
            }
        }        

        private void WriteLog(Exception ex)
        {
            Program.Log.WriteError(ex.Message, ex);
        }
    }
}
