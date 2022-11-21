using System;
using ChangeMgmt.Common;

namespace ChangeMgmt
{
    public partial class FrmDbSettings : DevExpress.XtraEditors.XtraForm
    {
        public DbInfo Info { get;set; }

        public FrmDbSettings()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTestCon_Click(object sender, EventArgs e)
        {
            string serverName = txtServerName.Text;
            string dbName = txtDbName.Text;
            string userSql = txtUserBd.Text;
            string pswSql = txtPswUser.Text;
            Info.SaveDbConf(serverName, dbName, userSql, pswSql);
            //Properties.Settings.Default.DayXConnectionString =
            //    @"Data Source = " + ServerName + "; Initial Catalog = " + DbName + "; Persist Security Info = True; User ID = " + UserSql + "; Password = " + PswSql;
            //Properties.Settings.Default.Save();
            if(Info.TestConnection())
            {
                btnOk.Enabled = true;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}