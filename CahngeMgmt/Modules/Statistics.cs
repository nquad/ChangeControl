using System;


namespace ChangeMgmt.Modules
{
    public partial class Statistics : DevExpress.XtraEditors.XtraUserControl
    {
        private static Statistics _instance;
        public static Statistics Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Statistics();
                return _instance;
            }
        }
        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            try
            {
                eNG_PROC_TASKSTableAdapter.FillByOverdue(dS.ENG_PROC_TASKS);
            }
            catch 
            {
               //ignored
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                eNG_PROC_TASKSTableAdapter.FillByOverdue(dS.ENG_PROC_TASKS);
            }
            catch
            {
                //ignored
            }
        }
    }
}
