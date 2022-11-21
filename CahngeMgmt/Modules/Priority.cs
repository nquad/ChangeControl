using System;

namespace ChangeMgmt.Modules
{
    public partial class Priority : DevExpress.XtraEditors.XtraUserControl
    {
        private static Priority _instance;
        public static Priority Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Priority();
                return _instance;
            }
        }
        public Priority()
        {
            InitializeComponent();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            eNG_PRIORTableAdapter.Update(dS.ENG_PRIOR);
            eNG_PRIORTableAdapter.Fill(dS.ENG_PRIOR);
        }

        private void Priority_Load(object sender, EventArgs e)
        {
            eNG_PRIORTableAdapter.Fill(dS.ENG_PRIOR);
        }
    }
}
