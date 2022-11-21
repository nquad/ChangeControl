using ChangeMgmt.Common;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Text;
using ChangeMgmt.Emails;
using ChangeMgmt.Properties;

namespace ChangeMgmt.Modules
{
    public partial class MultyRequest : XtraUserControl
    {
        private readonly DataSet _dataSet = new DataSet();
        private DataTable _hrnsMulti = new DataTable("ENG_HRNS");
        private readonly DataTable _table = new DataTable("attachment");
        private static MultyRequest _instance;
        public static MultyRequest Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MultyRequest();
                return _instance;
            }
        }
        public MultyRequest()
        {
            InitializeComponent();
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

            // Add the new DataTable to the DataSet.
            _dataSet.Tables.Add(_table);

        }
        void CreateTableMulti()
        {
            _hrnsMulti = dS.ENG_HRNS.Clone();
            _dataSet.Tables.Add(_hrnsMulti);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            DateTime datecreate = DateTime.Now;
            DateTime deadline = PROC_DEADLINEDateEdit.DateTime;
            int prior = PROC_PRIOR_NOLookUpEdit.ItemIndex+1;
            int owner = Entry.UserId;
            int status = PROC_STATUS_NOTextEdit.ItemIndex+1;
            string desc = PROC_DESCMemoExEdit.Text;
            int idSub = eNG_PROCTableAdapter.ScalarMaxSubNo().GetValueOrDefault()+1;
            if (prior != 0)
            {
                foreach (DataRow row in _hrnsMulti.Rows)
                {
                    eNG_PROCTableAdapter.InsertMultiRow(idSub, row["HRNS_NAME"].ToString(), prior, deadline, datecreate, owner, desc,
                        status);
                    // enG_APPROVTableAdapter.InsertNewRow(Convert.ToInt32(eNG_PROCTableAdapter.ScalarLastId()), datecreate, idSub);
                }
                splashScreenManager1.ShowWaitForm();
                CopyFiles(idSub.ToString());
                _hrnsMulti.Clear();
                eNGPROCBindingSource.CancelEdit();
                eNGPROCBindingSource.AddNew();
                Notifications();
                MessageBox.Show(@"Инициализация изменения отправлена на одобрение");
            }
            else
            {
                MessageBox.Show(@"Отсутствует приоритет!");
            }
            
        }
        void Notifications()
        {
            //var proc = new NewProcAprMulti();
            //proc.InitData();
            //proc.CreateDocument();
            //string reportHtml;

            //using (Stream stream = new MemoryStream())
            //{
            //    proc.ExportToHtml(stream);
            //    stream.Position = 0;
            //    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            //    {
            //        reportHtml = reader.ReadToEnd();
            //    }
            //}
            //SendEmail.SendEmailFromAccount("Уведомление на одобрение группы изменений №: " + eNG_PROCTableAdapter.ScalarMaxSubNo(), reportHtml, AprList(), Entry.Email);
            enG_EMAILTableAdapter.InsertNewRecord(eNG_PROCTableAdapter.ScalarMaxSubNo()??default(int), null, 10, AprList(), false);
        }
        string AprList()
        {
            string list = "";
            foreach (DataRow row in eNG_USERSTableAdapter.GetDataByUserCatId(10).Rows)
            {
                list += row["USER_EMAIL"] + ";";
            }
            return list.TrimEnd(';');
        }
        void CopyFiles(string sub)
        {

            foreach (DataRow row in _table.Rows)
            {
                if (!string.IsNullOrEmpty(row[0].ToString()))
                {
                    try
                    {

                        DirectoryInfo pathEnd = new DirectoryInfo(Properties.Settings.Default.PathForSaveFile + @"\" + sub+"sub");
                        Copy(row[0].ToString(), pathEnd.ToString(), row[1].ToString());

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
            fn.CopyTo(targetDirectory + "\\" + filename, true);
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteCheckedRow(gridView1, _table);
            }
        }

        private void MultyRequest_Load(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            CreateTable();
            CreateTableMulti();
            gridControl1.DataSource = _dataSet.Tables["attachment"];
            gridControl2.DataSource = _dataSet.Tables["ENG_HRNS"];
            eNGPROCBindingSource.AddNew();
            eNG_HRNSTableAdapter.Fill(dS.ENG_HRNS);
            eNG_PRIORTableAdapter.Fill(dS.ENG_PRIOR);
            eNG_USERSTableAdapter.Fill(dS.ENG_USERS);
            eNG_STATUSTableAdapter.Fill(dS.ENG_STATUS);
            splashScreenManager2.CloseWaitForm();
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
                            row["Name"] = item.Split('\\')[item.Split('\\').Length - 1];
                            _table.Rows.Add(row);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(@"Один из документов имеет дубликат " + exception.Data);
                        }
                    }

                }
            }
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
                MessageBox.Show(exception.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPickUpHrns_Click(object sender, EventArgs e)
        {
            HrnsList pickUpHrnsList = new HrnsList
            {
                Hrns = dS.ENG_HRNS
            };
            if (pickUpHrnsList.ShowDialog() == DialogResult.OK)
            {
                _hrnsMulti.Merge(pickUpHrnsList.SelectedHrns);
            }
            
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

        private void gridControl2_KeyUp(object sender, KeyEventArgs e)
        {
           
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))

            {
                Paste();
            }
            if (e.KeyCode == Keys.Delete)
            {
                DeleteCheckedRow(gridView2,_hrnsMulti);
            }
        }

        void DeleteCheckedRow(GridView gv, DataTable dt)
        {
            for (int i = 0; i < gv.DataRowCount; i++)
            {
                if (gv.IsRowSelected(i))
                {
                    try
                    {
                        dt.Rows.RemoveAt(i);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.HelpLink);
                    }
                }
            }
        }
        void Paste()
        {
            char[] rowSplitter = { '\r', '\n' };

            //get the text from clipboard

            IDataObject dataInClipboard = Clipboard.GetDataObject();

            if (dataInClipboard != null)
            {
                string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

                //split it into lines
                string[] rowsInClipboard;
                try
                {
                    rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
                }
                catch
                {
                    rowsInClipboard = null;
                }

                //get the row and column of selected cell in grid


                // loop through the lines, split them into cells and place the values in the corresponding cell.
                DataRow row;
                if (rowsInClipboard != null)
                {
                    foreach (var t in rowsInClipboard)
                    {
                        try
                        {
                            if (eNG_HRNSTableAdapter.ScalarCheckHrns(t) == 1)
                            {
                                row = _hrnsMulti.NewRow();
                                row["HRNS_NAME"] = t;
                                _hrnsMulti.Rows.Add(row);
                            }
                            else
                            {
                                MessageBox.Show(t + @" Отсутствует в базе");
                            }

                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }


                    }
                }
                else
                {
                    MessageBox.Show(@"Буфер пустой");
                }
                
            }
        }
        private void btnPasteClip_Click(object sender, EventArgs e)
        {
            Paste();
        }
    }
}
