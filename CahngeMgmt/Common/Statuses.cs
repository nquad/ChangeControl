using System;
using System.Data;
using System.Data.SqlClient;

namespace ChangeMgmt.Common
{
    class Statuses
    {

        public Statuses()
        {
            _tableStatus = Select(
                "SELECT\r\n\t[ENG_STATUS].[STATUS_NO],\r\n\t[ENG_STATUS].[STATUS_NAME] \r\nFROM\r\n\t[DayX].[dbo].[ENG_STATUS] [ENG_STATUS]");
            if (_tableStatus != null)
            {
                Entry.Status = _tableStatus;
            }
        }

        private SqlConnection _connection;

        private static DataTable _tableStatus;

        public DataTable TableStatus => _tableStatus;
        private DataTable Select(string query)
        {
            string connectionString = Properties.Settings.Default.DayXConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            SqlCommand cmd = new SqlCommand(query, _connection);
            SqlDataReader Reader;
            DataTable dt = new DataTable();
            Reader = cmd.ExecuteReader();
            if (Reader.HasRows)
            {
                dt.Load(Reader);
            }
            _connection.Close();
            return dt;
        }
    }
}
