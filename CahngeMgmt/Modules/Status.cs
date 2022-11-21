using System;


namespace ChangeMgmt.Modules
{
    public partial class Status : DevExpress.XtraEditors.XtraUserControl
    {
        private static Status _instance;
        public static Status Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Status();
                return _instance;
            }
        }
        public Status()
        {
            InitializeComponent();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            eNG_STATUSTableAdapter.Fill(dS.ENG_STATUS);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            eNG_STATUSTableAdapter.Update(dS.ENG_STATUS);
            eNG_STATUSTableAdapter.Fill(dS.ENG_STATUS);
        }
    }
}
