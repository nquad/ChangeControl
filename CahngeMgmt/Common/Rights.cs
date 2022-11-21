using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChangeMgmt.Common
{
    class Rights
    {
        public Rights(string login)
        {
            _tableRights = Select(
                "SELECT\r\n\t[ENG_USERS].[USER_NO],\r\n\t[ENG_USERS].[USER_NAME],\r\n\t[ENG_USERS].[USER_LOGIN],\r\n\t[ENG_USERS].[USER_EMAIL],\r\n\t[ENG_USERS].[USER_BLOCK],\r\n\t[ENG_USER_RULES].[USER_RIGHTFROM],\r\n\t[ENG_USER_RULES].[USER_RIGHTTILL],\r\n\t[ENG_CATEGORY].[CAT_NAME],\r\n\t[ENG_CATEGORY_TYPE].[TYPE_NAME] \r\nFROM\r\n\t[DayX].[dbo].[ENG_USER_RULES] [ENG_USER_RULES] \r\n\t\tINNER JOIN [DayX].[dbo].[ENG_CATEGORY] [ENG_CATEGORY] \r\n\t\tON [ENG_USER_RULES].[RULES_USER_CAT] = [ENG_CATEGORY].[CAT_NO] \r\n\t\t\tINNER JOIN [DayX].[dbo].[ENG_USERS] [ENG_USERS] \r\n\t\t\tON [ENG_USERS].[USER_NO] = [ENG_USER_RULES].[RULES_USER_NO] \r\n\t\t\t\tINNER JOIN [DayX].[dbo].[ENG_CATEGORY_TYPE] [ENG_CATEGORY_TYPE] \r\n\t\t\t\tON [ENG_CATEGORY].[CAT_TYPE_NO] = [ENG_CATEGORY_TYPE].[TYPE_NO] \r\nWHERE\r\n\t([ENG_USERS].[USER_LOGIN] = \'" +
                login + "\')");
            if (_tableRights != null)
            {
                try
                {
                    Entry.UserName = _tableRights.Rows[0]["USER_NAME"].ToString();
                    Entry.Login = _tableRights.Rows[0]["USER_LOGIN"].ToString();
                    Entry.Email = _tableRights.Rows[0]["USER_EMAIL"].ToString();
                    Entry.Block = Convert.ToInt32(_tableRights.Rows[0]["USER_BLOCK"]);
                    Entry.UserId = Convert.ToInt32(_tableRights.Rows[0]["USER_NO"]);
                    Entry.Categoryes = _tableRights;
                }
                catch
                {
                    //MessageBox.Show(@"Пользователь не найден!");
                    Entry.UserName = "";
                }
            }
            if (Entry.Login != null)
            {
                _tableCategor = Select(@"SELECT
                        [ENG_USER_RULES].[RULES_NO],

                    [ENG_USER_RULES].[RULES_USER_NO],

                [ENG_USER_RULES].[RULES_USER_CAT],

                [ENG_USER_RULES].[RULES_DATECHG],

                [ENG_USER_RULES].[USER_RIGHTTILL],

                [ENG_USER_RULES].[USER_RIGHTFROM],

                [ENG_USERS].[USER_NO],

                [ENG_USERS].[USER_NAME],

                [ENG_USERS].[USER_LOGIN],

                [ENG_USERS].[USER_EMAIL],

                [ENG_USERS].[USER_BLOCK],

                [ENG_CATEGORY].[CAT_NO],

                [ENG_CATEGORY].[CAT_NAME],

                [ENG_CATEGORY].[CAT_TYPE_NO],

                [ENG_CATEGORY].[CAT_ADD]
            FROM
                [DayX].[dbo].[ENG_USER_RULES][ENG_USER_RULES]

            INNER JOIN[DayX].[dbo].[ENG_USERS][ENG_USERS]

            ON[ENG_USER_RULES].[RULES_USER_NO] = [ENG_USERS].[USER_NO]

            INNER JOIN[DayX].[dbo].[ENG_CATEGORY][ENG_CATEGORY]

            ON[ENG_USER_RULES].[RULES_USER_CAT] = [ENG_CATEGORY].[CAT_NO]
            WHERE
                ([ENG_USERS].[USER_LOGIN] = '" + login + "')");
                Entry.CategoryList = Categoryes().TrimEnd(',');
                Entry.CategoryTable = _tableCategor;
            }
           
        }
        private SqlConnection _connection;
        private static DataTable _tableRights;
        private static DataTable _tableCategor;
        public DataTable TableCategor => _tableCategor;
        public DataTable TableRights => _tableRights;

        private string Categoryes()
        {
            string row=null;
            for (int i = 0; i < _tableCategor.Rows.Count; i++)
            {
                row += _tableCategor.Rows[i]["RULES_USER_CAT"]+",";
            }
            return row;
        }
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
