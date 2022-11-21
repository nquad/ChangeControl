using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ChangeMgmt
{
    public class DB_con
    {
        private MySqlConnection connection;
        private string server;
        private string uid;
        private string password;
        public string queryString = null;
        
        //Constructor
        public DB_con()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = Properties.Settings.Default.DB_IP;
            uid = Properties.Settings.Default.DB_Login;
            password = Properties.Settings.Default.DB_Pass;
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Select statement
        public DataTable Select(string query, string db)
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
             db + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "CHARACTER SET= utf8";
            connection = new MySqlConnection(connectionString);
            this.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader Reader;
            DataTable dt = new DataTable();
            Reader = cmd.ExecuteReader();
            if (Reader.HasRows)
            {
                dt.Load(Reader);
            }
            this.CloseConnection();
            return dt;
        }
        //Insert statement
        public void Insert(string query, string db)
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            db + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "CHARACTER SET= utf8";
            connection = new MySqlConnection(connectionString);
            this.OpenConnection();
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //Execute command
            cmd.ExecuteNonQuery();
            //MessageBox.Show(query, "Выполнено");

            //close connection
            this.CloseConnection();
        }
        //Delete statement
        public void Delete(string query, string db)
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
           db + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "CHARACTER SET= utf8";
            connection = new MySqlConnection(connectionString);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string query, string db)
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
           db + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "CHARACTER SET= utf8";
            connection = new MySqlConnection(connectionString);
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand()
                { 
                //Assign the query using CommandText
                CommandText = query,
                //Assign the connection using Connection
                Connection = connection,
                };
                //Execute query
                cmd.ExecuteNonQuery();
                

            //close connection
                this.CloseConnection();
            }
        }

        public AutoCompleteStringCollection namesCollection(string query, string db, string name)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
           db + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "CHARACTER SET= utf8";
            connection = new MySqlConnection(connectionString);
            this.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader rr = cmd.ExecuteReader();

            while (rr.Read())
            {
                namesCollection.Add(rr[name].ToString());

            }
            rr.Close();
            return namesCollection;
        }
    }
}