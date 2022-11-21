using System;
using System.Data;
using System.Windows.Forms;
using System.DirectoryServices;

namespace ChangeMgmt
{
    public partial class UserSearch : DevExpress.XtraEditors.XtraForm
    {

        /// <summary>
        /// Active Directory Name 
        /// </summary>
        public string AdName { get; set; }
        /// <summary>
        /// Имя пользователя (загружается из AD)
        /// </summary>
        public string I { get; set; }
        /// <summary>
        /// Фамилия пользователя (загружается из AD)
        /// </summary>
        public string F { get; set; }
        /// <summary>
        /// Выводимое имя (загружается из AD)
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// EMail пользователя (загружается из AD)
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// Отдел пользователя (загружается из AD)
        /// </summary>
        public string Department { get; set; }

        public DataRow[] Row;
        public UserSearch()
        {
            InitializeComponent();
        }

        private void UserList(string filtr)
        {
            string strrootdse = "LDAP://DC=prettl,DC=local";
            
            DirectoryEntry objdirentry = new DirectoryEntry(strrootdse);
            DirectorySearcher objsearch = new DirectorySearcher(objdirentry);
            objsearch.Filter = filtr;
            objsearch.PropertiesToLoad.Add("SamAccountName"); // Общее имя (ADName ?)
            objsearch.PropertiesToLoad.Add("displayName"); // Отображаемое имя
            objsearch.PropertiesToLoad.Add("givenName"); // Имя
            objsearch.PropertiesToLoad.Add("sn"); // Фамилия
            objsearch.PropertiesToLoad.Add("mail"); // Емаил
            objsearch.PropertiesToLoad.Add("department"); // Отдел     
            objsearch.PropertyNamesOnly = true;

            try
            {
                var objresult = objsearch.FindOne();

                AdName = (objresult.GetDirectoryEntry().Properties["SamAccountName"].Value).ToString();
                I = (objresult.GetDirectoryEntry().Properties["givenName"].Value).ToString();
                F = (objresult.GetDirectoryEntry().Properties["sn"].Value).ToString();
                DisplayName = (objresult.GetDirectoryEntry().Properties["displayName"].Value).ToString();
                EMail = (objresult.GetDirectoryEntry().Properties["mail"].Value).ToString();
                //Department = (objresult.GetDirectoryEntry().Properties["department"].Value).ToString();


                lbFio.Text = DisplayName;
                lbLogin.Text = AdName;
                lbDep.Text = Department;
                lbEmail.Text = EMail;


                btnOK.Enabled = true;

            }
            catch(Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string loginFilter = "(&(objectCategory=user)(objectClass=user)(userPrincipalName=" + txtSearch.Text + "*))";
            string emailFilter = "(&(objectCategory=user)(objectClass=user)(mail=" + txtSearch.Text + "*))";
            UserList(txtSearch.Text.Contains("@") ? emailFilter : loginFilter);
        }
    }
   
}