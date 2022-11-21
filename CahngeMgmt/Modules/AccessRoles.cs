using System;



namespace ChangeMgmt.Modules
{
    public partial class AccessRoles : DevExpress.XtraEditors.XtraUserControl
    {
        private static AccessRoles _instance;
        public static AccessRoles Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AccessRoles();
                return _instance;
            }
        }
        public AccessRoles()
        {
            InitializeComponent();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            rOLLE_ACCESSTableAdapter.Update(dS.ROLLE_ACCESS);
            rOLLE_ACCESSTableAdapter.Fill(dS.ROLLE_ACCESS);
        }

        private void AccessRoles_Load(object sender, EventArgs e)
        {
            rOLLE_ACCESSTableAdapter.Fill(dS.ROLLE_ACCESS);
            eNG_CATEGORY_TYPETableAdapter.Fill(dS.ENG_CATEGORY_TYPE);
        }
     
    }
}
