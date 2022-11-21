using System.Data;
using System.Data.SqlClient;


namespace ChangeMgmt.Common
{
    class Alert
    {
        private SqlConnection _connection;
        public DataTable AlertTable { get; set; }
        public string ProcId { get; set; }
        public string LeoniNubber { get; set; }
        public string StatusProc { get; set; }
        public string Description { get; set; }
        public Alert()
        {
            AlertTable = Select(@"SELECT
                        [ENG_PROC].[PROC_NO],
                    [ENG_PROC].[PROC_SUB_NO],
                [ENG_PROC].[PROC_HRNS_NAME],
                [ENG_PRIOR].[PRIOR_NAME],
                [ENG_PROC].[PROC_DESC]
            FROM
                [DayX].[dbo].[ENG_PROC][ENG_PROC]
            INNER JOIN[DayX].[dbo].[ENG_PRIOR][ENG_PRIOR]
            ON[ENG_PROC].[PROC_PRIOR_NO] = [ENG_PRIOR].[PRIOR_NO]
            WHERE
                ([ENG_PROC].[PROC_APR_READ] IS NULL) AND
                ([ENG_PROC].[PROC_STATUS_NO] = 4) 
            UNION
                SELECT
            COUNT([ENG_PROC_1].[PROC_NO]),
                [ENG_PROC_1].[PROC_SUB_NO],
            MAX([ENG_PROC_1].[PROC_HRNS_NAME]),
                [ENG_PRIOR_1].[PRIOR_NAME],
                [ENG_PROC_1].[PROC_DESC]
            FROM
                    [DayX].[dbo].[ENG_PROC]
                [ENG_PROC_1]
            INNER JOIN[DayX].[dbo].[ENG_PRIOR]
                [ENG_PRIOR_1]
            ON[ENG_PROC_1].[PROC_PRIOR_NO] = [ENG_PRIOR_1].[PRIOR_NO]
            WHERE
                ([ENG_PROC_1].[PROC_APR_READ] = 0) AND
                ([ENG_PROC_1].[PROC_STATUS_NO] = 4)
            GROUP BY
                    [ENG_PROC_1].[PROC_SUB_NO],
                [ENG_PROC_1].[PROC_DESC],
                [ENG_PRIOR_1].[PRIOR_NAME]");
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
