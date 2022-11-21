using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;



namespace ChangeMgmt.Modules
{
    public partial class Users : XtraUserControl
    {
        private static Users _instance;
        public static Users Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Users();
                return _instance;
            }
        }
        public Users()
        {
            InitializeComponent();
            eNG_USERSTableAdapter.Fill(dS.ENG_USERS);
            eNG_CATEGORY_TYPETableAdapter.Fill(dS.ENG_CATEGORY_TYPE);
            eNG_CATEGORYTableAdapter.Fill(dS.ENG_CATEGORY);
            eNG_USER_RULESTableAdapter.Fill(dS.ENG_USER_RULES);
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
           UserSearch userSearch = new UserSearch();
            if (userSearch.ShowDialog() == DialogResult.OK)
            {
                eNGUSERSBindingSource.AddNew();
                if (eNGUSERSBindingSource.Current is DataRowView row)
                {
                    row["USER_LOGIN"] = userSearch.AdName.TrimEnd(' ');
                    row["USER_NAME"] = userSearch.DisplayName.TrimEnd(' ');
                    row["USER_EMAIL"] = userSearch.EMail.TrimEnd(' ');
                    row["USER_BLOCK"] = false;
                }

                eNGUSERSBindingSource.EndEdit();
                eNG_USERSTableAdapter.Update(dS.ENG_USERS);
                eNG_USERSTableAdapter.Fill(dS.ENG_USERS);
            }
           
        }
        
        private void gridView3_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                eNG_CATEGORY_TYPETableAdapter.Update(dS.ENG_CATEGORY_TYPE);
                eNG_CATEGORY_TYPETableAdapter.Fill(dS.ENG_CATEGORY_TYPE);
            }
            catch
            {
                //ignored
            }
        }

        private void gridView4_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                eNG_CATEGORYTableAdapter.Update(dS.ENG_CATEGORY);
                eNG_CATEGORYTableAdapter.Fill(dS.ENG_CATEGORY);
            }
            catch 
            {
              //ignored
            }
        }

        private void gridView5_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                eNG_USER_RULESTableAdapter.Update(dS.ENG_USER_RULES);
                eNG_USER_RULESTableAdapter.Fill(dS.ENG_USER_RULES);
            }
            catch
            { 
                //ignored
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                eNG_USERSTableAdapter.Update(dS.ENG_USERS);
                eNG_USERSTableAdapter.Fill(dS.ENG_USERS);
            }
            catch
            {
               //ignored
            }
        }

       private void gridView5_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView5.SetRowCellValue(e.RowHandle, colRULES_DATECHG1, DateTime.Now);
            gridView5.SetRowCellValue(e.RowHandle, colUSER_RIGHTTILL1, DateTime.Now.AddYears(10));
            gridView5.SetRowCellValue(e.RowHandle, colUSER_RIGHTFROM1, DateTime.Now);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
            if (XtraMessageBox.Show("Удалить права у пользователя?","Удаление прав",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                eNGUSERRULESBindingSource.RemoveCurrent();
                eNG_USER_RULESTableAdapter.Update(dS.ENG_USER_RULES);
            }
            
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (XtraMessageBox.Show("Удалить пользователя?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                eNGUSERSBindingSource.RemoveCurrent();
                eNG_USERSTableAdapter.Update(dS.ENG_USERS);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Migration frm = new Migration();
            frm.Show();
        }
    }
}
