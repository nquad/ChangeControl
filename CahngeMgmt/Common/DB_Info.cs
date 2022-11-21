using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChangeMgmt.Common
{
    public class DbInfo
    {
        private readonly IniFiles _ini = new IniFiles("config.ini");

        private SqlConnection _connection;
        public bool Status { get; set; }
        private string UserSql { get; set; }
        private string PswSql { get; set; }
        private string ServerName { get; set; }
        private string DbName { get; set; }

        public bool TestConnection()
        {
            if (Properties.Settings.Default.DayXConnectionString=="")
            {
                try
                {
                    ReadSettingsFromFile();
                }
                catch 
                {
                    //ignored
                }
            }
            string connectionString = Properties.Settings.Default.DayXConnectionString;
            _connection = new SqlConnection(connectionString);
            try
            {
               _connection.Open();

                Status = _connection.State == ConnectionState.Open;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message,
                    @"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Status = false;
                //throw;
                
            }
            return Status;
        }

        private void ReadSettingsFromFile()
        {

            if (_ini.KeyExists("UserSql", "UserSql"))
            {
                UserSql = _ini.ReadIni("UserSql", "UserSql");
            }
            if (_ini.KeyExists("PswSql", "PswSql"))
            {
                PswSql = _ini.ReadIni("PswSql", "PswSql");
            }
            if (_ini.KeyExists("ServerName", "ServerName"))
            {
                ServerName = _ini.ReadIni("ServerName", "ServerName");
            }
            if (_ini.KeyExists("DbName", "DbName"))
            {
                DbName = _ini.ReadIni("DbName", "DbName");
            }

            Properties.Settings.Default.DayXConnectionString =
                @"Data Source = "+ ServerName + "; Initial Catalog = "+DbName+"; Persist Security Info = True; User ID = "+UserSql+"; Password = "+PswSql;
            Properties.Settings.Default.Save();
        }

        public void SaveDbConf(string serverName, string dbName, string userSql, string pswSql)
        {
            _ini.Write("UserSql", "UserSql", userSql);
            _ini.Write("PswSql", "PswSql", pswSql);
            _ini.Write("ServerName", "ServerName", serverName);
            _ini.Write("DbName", "DbName", dbName);
        }

    }
}
