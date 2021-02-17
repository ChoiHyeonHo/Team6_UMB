using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using UMB_POP.Back;

namespace UMB_POP
{
    partial class WorkStart : ServiceBase
    {
        public int performance_id { get; set; }
        public string product_id { get; set; }
        public int production_id { get; set; }
        public int performance_qtyimport { get; set; }
        public int okcount { get; set; }
        public int ngcount { get; set; }
        public int count { get; set; }
        public int time { get; set; }
        frmPOP serverP = null;
        System.Timers.Timer timer1;
        TcpListener listener;
        TcpClient tc;
        POPClient client;
        NetworkStream stream;
        string host = ConfigurationManager.AppSettings["serverIP"];
        int port = 5000;
        string readData = "";
        public WorkStart()
        {
            InitializeComponent();
            okcount = 0;
            ngcount = 0;
            count = 0;
        }

        protected override void OnStart(string[] args)
        {
            serverP = new frmPOP();
            new Thread(new ThreadStart(serverP.ProduceStart)).Start();

            Console.WriteLine("서비스 시작");
            if(listener == null)
            {
                listener = new TcpListener(IPAddress.Parse(host), port);
            }
            AsyncEchoServerAsync();

        }

        private async void AsyncEchoServerAsync()
        {
            listener.Start();
            StreamReader reader = new StreamReader(stream);
            
            tc = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
            stream = tc.GetStream();

            byte[] rcvTmp = new byte[client.client.Available];
            stream.Read(rcvTmp, 0, rcvTmp.Length);
            string[] msg = (await reader.ReadLineAsync()).Split(',');

            performance_id = Convert.ToInt32(msg[0]);
            product_id = msg[2];
            performance_qtyimport = Convert.ToInt32(msg[1]);//1
            time = Convert.ToInt32(msg[3]);//3
            count = 0;
            okcount = 0;
            ngcount = 0;

            timer1 = new System.Timers.Timer(time*1000);
            timer1.Elapsed += new ElapsedEventHandler(Timer1_Elapsed);
            timer1.Start();

        }

        private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(count == performance_qtyimport)
            {
                timer1.Stop();
            }
            else if(count < performance_qtyimport)
            {
                count++;
                okcount++;
            }
        }

        protected override void OnStop()
        {
            serverP.CompleteProduction();
        }


    }
}
