namespace ChangeMgmt.Modules
{
    public partial class Project : DevExpress.XtraEditors.XtraUserControl
    {
        private static Project _instance;
        public static Project Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Project();
                return _instance;
            }
        }
        public Project()
        {
            InitializeComponent();
            
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            eNG_PROJECTTableAdapter.Update(dS.ENG_PROJECT);
            eNG_PROJECTTableAdapter.Fill(dS.ENG_PROJECT);
        }

        private void Project_Load(object sender, System.EventArgs e)
        {
            eNG_PROJECTTableAdapter.Fill(dS.ENG_PROJECT);
        }
    }
}
