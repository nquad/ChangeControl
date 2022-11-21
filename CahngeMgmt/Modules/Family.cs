namespace ChangeMgmt.Modules
{
    public partial class Family : DevExpress.XtraEditors.XtraUserControl
    {
        private static Family _instance;
        public static Family Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Family();
                return _instance;
            }
        }
        public Family()
        {
            InitializeComponent();
           
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            eNG_FAMILYTableAdapter.Update(dS.ENG_FAMILY);
            eNG_FAMILYTableAdapter.Fill(dS.ENG_FAMILY);
        }

        private void Family_Load(object sender, System.EventArgs e)
        {
            eNG_FAMILYTableAdapter.Fill(dS.ENG_FAMILY);
            eNG_PROJECTTableAdapter.Fill(dS.ENG_PROJECT);
        }
    }
}
