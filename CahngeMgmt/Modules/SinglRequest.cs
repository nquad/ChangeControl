using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ChangeMgmt.Common;
using DevExpress.XtraEditors;


namespace ChangeMgmt.Modules
{
    public partial class SinglRequest : XtraUserControl
    {
        private DataSet _dataSet;
        private readonly DataTable _table = new DataTable("attachment");
        private static SinglRequest _instance;
        public static SinglRequest Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SinglRequest();
                return _instance;
            }
        }
        public SinglRequest()
        {
            InitializeComponent();
        }

        private void SinglRequest_Load(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            CreateTable();
            gridControl1.DataSource = _dataSet.Tables["attachment"];
            eNGPROCBindingSource.AddNew();
            eNG_HRNSTableAdapter.Fill(dS.ENG_HRNS);
            eNG_PRIORTableAdapter.Fill(dS.ENG_PRIOR);
            eNG_USERSTableAdapter.Fill(dS.ENG_USERS);
            eNG_STATUSTableAdapter.Fill(dS.ENG_STATUS);
            splashScreenManager1.CloseWaitForm();
        }
        
        private void PROC_PRIOR_NOLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUp = sender as LookUpEdit;
            if (lookUp?.GetSelectedDataRow() is DataRowView dataRow)
            {
                PROC_DEADLINEDateEdit.DateTime = DateTime.Now.AddDays((int)dataRow["PRIOR_DAYS"]);
                PROC_DATECREDateEdit.DateTime = DateTime.Now;
                PROC_USER_NOTextEdit.EditValue = Entry.UserId;
                PROC_STATUS_NOTextEdit.EditValue = 4;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            using (XtraOpenFileDialog dialog = new XtraOpenFileDialog())// создание нового OpenFileDialog
            {
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DataRow row;
                    foreach (var item in dialog.FileNames)
                    {

                        try
                        {
                            row = _table.NewRow();
                            row["Path"] = item;
                            row["Name"] = item.Split('\\')[item.Split('\\').Length-1];
                            _table.Rows.Add(row);
                        }
                        catch (Exception exception)
                        {
                            XtraMessageBox.Show(@"Один из документов имеет дубликат " +exception.Data );
                        }
                    }
                   
                }
            }
          
        }

        void CreateTable()
        {
           // Create second column.
            var column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Path",
                AutoIncrement = false,
                Caption = "Путь",
                ReadOnly = false,
                Unique = true
            };
            // Add the column to the table.
            _table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Name",
                AutoIncrement = false,
                Caption = "Имя файла",
                ReadOnly = false,
                Unique = false
            };
            // Add the column to the table.
            _table.Columns.Add(column);
            
            // Instantiate the DataSet variable.
            _dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            _dataSet.Tables.Add(_table);

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        try
                        {
                           _table.Rows.RemoveAt(i);
                        }
                        catch (Exception exception)
                        {
                            XtraMessageBox.Show(exception.Message);
                        }
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (PROC_PRIOR_NOLookUpEdit.EditValue.ToString() != "")
            {
                try
                {
                    eNGPROCBindingSource.EndEdit();
                    eNG_PROCTableAdapter.Update(dS.ENG_PROC);
                    eNGPROCBindingSource.AddNew();
                    splashScreenManager1.ShowWaitForm();
                    CopyFiles();
                    Notifications();
                    XtraMessageBox.Show(@"Инициализация изменения отправлена на одобрение");
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show(exception.Message, @"Ошибка записи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show(@"Приоритет не указан");
            }

        }

        void Notifications()
        {
           enG_EMAILTableAdapter.InsertNewRecord((int)eNG_PROCTableAdapter.ScalarLastId(), null, 11, AprList(), false);
        }
        string AprList()
        {
            string list="";
            foreach (DataRow row in eNG_USERSTableAdapter.GetDataByUserCatId(10).Rows)
            {
                list += row["USER_EMAIL"] + ";";
            }
            return list.TrimEnd(';');
        }

        void CopyFiles()
        {
           
            foreach (DataRow row in _table.Rows)
            {
                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    try
                    {
                        
                        DirectoryInfo pathEnd = new DirectoryInfo(Properties.Settings.Default.PathForSaveFile + @"\" + eNG_PROCTableAdapter.ScalarLastId());
                        Copy(row[0].ToString(), pathEnd.ToString(),row[1].ToString());
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            _table.Clear();
            splashScreenManager1.CloseWaitForm();
        }

        private void Copy(string sourceDirectory, string targetDirectory, string filename)
        {
          
            if (Directory.Exists(targetDirectory) == false)
            {
                Directory.CreateDirectory(targetDirectory);
            }
            FileInfo fn = new FileInfo(sourceDirectory);
            fn.CopyTo(targetDirectory+ "\\"+ filename, true);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                string p = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Path").ToString();
                Process.Start(p);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
