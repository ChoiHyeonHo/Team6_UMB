using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UMB_POP
{
    partial class WorkStart : ServiceBase
    {
        frmPOP serverP = null;
        public WorkStart()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serverP = new frmPOP();
            new Thread(new ThreadStart(serverP.ProduceStart)).Start();
        }

        protected override void OnStop()
        {
            
        }
    }
}
