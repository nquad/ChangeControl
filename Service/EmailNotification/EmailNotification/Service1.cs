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

namespace EmailNotification
{
    public partial class Service1 : ServiceBase
    {
        readonly Emails _em = new Emails();
        private readonly Thread _workerThread;
        public Service1()
        {
            InitializeComponent();
            _workerThread = new Thread(DoWork);
            _workerThread.SetApartmentState(ApartmentState.MTA);
        }

        public void Start()
        {
            _workerThread.Start();
        }

        public void Stop_()
        {
            _workerThread.Abort();
        }
        protected override void OnStart(string[] args)
        {
            Start();
        }

        protected override void OnStop()
        {
            Stop();
        }

        private void DoWork()
        {
            
            _em.Send();
        }
    }
}
