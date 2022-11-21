using ChangeMgmt.Properties;
using ChangeMgmt.Common;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using ChangeMgmt.Emails;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors;
using System.Data;
using DevExpress.XtraGrid;
using System.Data.SqlClient;

namespace ChangeMgmt.Modules
{
    public partial class AllTasks : XtraUserControl
    {
        private static AllTasks _instance;
        public static AllTasks Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AllTasks();
                return _instance;
            }
        }
        public AllTasks()
        {
            InitializeComponent();
        }
        private void AllTasks_Load(object sender, EventArgs e)
        {
            UpdateTable();
            eNG_PRIORTableAdapter.Fill(dS.ENG_PRIOR);
            eNG_CATEGORYTableAdapter.Fill(dS.ENG_CATEGORY);
            eNG_STATUSTableAdapter.Fill(dS.ENG_STATUS);
            timer1.Enabled = true;
            timer1.Interval = Convert.ToInt32(textEdit1.Text) * 60000;
            timer1.Start();
        }
        private void UpdateTable()
        {
            eNG_PROCTableAdapter.FillByAllOpenProc(dS.ENG_PROC);
            enG_PROC_TASKSTableAdapter.Fill(dS.ENG_PROC_TASKS);
            eNG_USERSTableAdapter.Fill(dS.ENG_USERS);
            gridView1.ExpandAllGroups();
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(textEdit1.Text) * 60000;
            if (checkEdit1.Checked)
            { timer1.Start(); }
            else
            { timer1.Stop(); }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTable();
        }
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var subId = gridView1.GetFocusedDataRow()["PROC_SUB_NO"].ToString();
            var p = gridView1.GetFocusedDataRow()["PROC_NO"].ToString();
            var openpath = (subId == "") ? Settings.Default.PathForSaveFile + @"\" + p : Settings.Default.PathForSaveFile + @"\" + subId + @"sub";
            try
            {
                Process.Start(openpath);
            }
            catch
            {
                //ignored
            }
        }
        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                DXMenuItem itemCancel = CreateMenuItemCancel(view, rowHandle);
                itemCancel.BeginGroup = true;

                e.Menu.Items.Clear();
                DXMenuItem itemFileAdd = CreateMenuItemExsportToFile(view);
                DXMenuItem itemFileReport = CreateMenuItemExsportToFileReport(view);
                DXMenuItem itemFileInfo = CreateMenuItemFileInfo(view, rowHandle);
                e.Menu.Items.Add(itemFileAdd);
                e.Menu.Items.Add(itemFileReport);
                e.Menu.Items.Add(itemFileInfo);
                e.Menu.Items.Add(itemCancel);

            }
        }

        private DXMenuItem CreateMenuItemExsportToFileReport(GridView view)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Выгрузить в файл Отчет (Eng only)",
                view.OptionsView.AllowCellMerge, null, OnExportReport);
            checkItem.ImageOptions.Image = imageCollection1.Images[4];
            return checkItem;
        }

        private void OnExportReport(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DayXConnectionString))
            {
                
                string query =
                    "SELECT\r\n\t[ENG_PROC].[PROC_NO],\r\n\t[ENG_PROC].[PROC_SUB_NO],\r\n\t[ENG_PROC].[PROC_HRNS_NAME],\r\n\t[ENG_HRNS].[HRNS_PROJECT],\r\n\t[ENG_HRNS].[HRNS_CAP_TYPE],\r\n\t[ENG_HRNS].[HRNS_FAMILY],\r\n\t[ENG_PROC].[PROC_DESC],\r\n\t[ENG_STATUS].[STATUS_NAME],\r\n\t[ENG_CATEGORY].[CAT_NAME],\r\n\t[ENG_PROC_TASKS].[TASK_STATUS] \r\nFROM\r\n\t[DayX].[dbo].[ENG_PROC] [ENG_PROC] \r\n\t\tINNER JOIN [DayX].[dbo].[ENG_PROC_TASKS] [ENG_PROC_TASKS] \r\n\t\tON [ENG_PROC].[PROC_NO] = [ENG_PROC_TASKS].[TASK_PROC_NO] \r\n\t\t\tINNER JOIN [DayX].[dbo].[ENG_CATEGORY] [ENG_CATEGORY] \r\n\t\t\tON [ENG_PROC_TASKS].[TASK_CAT_NO] = [ENG_CATEGORY].[CAT_NO] \r\n\t\t\t\tINNER JOIN [DayX].[dbo].[ENG_STATUS] [ENG_STATUS] \r\n\t\t\t\tON [ENG_PROC].[PROC_STATUS_NO] = [ENG_STATUS].[STATUS_NO] \r\n\t\t\t\t\tINNER JOIN [DayX].[dbo].[ENG_HRNS] [ENG_HRNS] \r\n\t\t\t\t\tON [ENG_PROC].[PROC_HRNS_NAME] = [ENG_HRNS].[HRNS_NAME] \r\nWHERE\r\n\t([ENG_PROC].[PROC_STATUS_NO] = 1) OR\r\n\t([ENG_PROC].[PROC_STATUS_NO] = 2) OR\r\n\t([ENG_PROC].[PROC_STATUS_NO] = 4)";
                con.Open();
                using (SqlCommand command =
                    new SqlCommand(query, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                     dt.Load(reader);
                    }       
                }
                con.Close();
            }
            gridControl1.DataSource = dt;
            gridControl1.MainView = gridView3;
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = @"Excel (2010) (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                   
                        XlsxExportOptionsEx opt =
                            new XlsxExportOptionsEx { ExportType = DevExpress.Export.ExportType.WYSIWYG };
                       gridView3.ExportToXlsx(exportFilePath, opt);

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            gridControl1.MainView = gridView1;
            gridControl1.DataSource = eNGPROCBindingSource;
            
            UpdateTable();
        }

        private DXMenuItem CreateMenuItemExsportToFile(GridView view)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Выгрузить в файл",
                view.OptionsView.AllowCellMerge, null, OnExport);
            checkItem.ImageOptions.Image = imageCollection1.Images[4];
            return checkItem;
        }
        private DXMenuItem CreateMenuItemFileInfo(GridView view, int rowHandle)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Информация о жгуте",
                view.OptionsView.AllowCellMerge, null, OnHrnsInfo);
            checkItem.Tag = new RowInfo(view, rowHandle);
            checkItem.ImageOptions.Image = imageCollection1.Images[2];
            return checkItem;
        }
        DXMenuCheckItem CreateMenuItemCancel(GridView view, int rowHandle)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Отменить изменение",
                view.OptionsView.AllowCellMerge, null, CancelTask);
            checkItem.Tag = new RowInfo(view, rowHandle);
            checkItem.ImageOptions.Image = imageCollection1.Images[1];
            return checkItem;
        } //Меню отмена изменения
        void CancelTask(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                int p = Convert.ToInt32(ri.View.GetRowCellValue(ri.RowHandle, "PROC_NO"));
                string subId = ri.View.GetGroupRowValue(ri.RowHandle).ToString();
                if (CheckPermissionsForCloseInitialisation())
                {
                    if (subId == "")
                    {
                        if (XtraMessageBox.Show("Отменить инициализацию для жгута " + ri.View.GetRowCellValue(ri.RowHandle, "PROC_HRNS_NAME") + " ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            enG_PROC_TASKSTableAdapter.UpdateCancelByProcId(DateTime.Now, true, Entry.UserId,
                                CommentForm(), p);
                            eNG_PROCTableAdapter.UpdateStatus(6, p);
                            CancelEmailSingle(p);
                            UpdateTable();
                        }
                        //тут рассылка о завершении
                    }
                    else if (subId != "")
                    {
                        if (XtraMessageBox.Show("Отменить инициализацию для группы " + subId + " ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            enG_PROC_TASKSTableAdapter.UpdateCancelBySubId(DateTime.Now, true, Entry.UserId,
                                CommentForm(),Convert.ToInt32(subId));
                            eNG_PROCTableAdapter.UpdateStatusBySubId(6, Convert.ToInt32(subId));
                            CancelEmailMulti(Convert.ToInt32(subId));
                            UpdateTable();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("У Вас нету прав для этого действия", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

            }
        }  //Код отмена изменения
        void CancelEmailSingle(int id)
        {
            //var proc = new CancelProcSingle();
            //proc.InitData(id);
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
            //SendEmail.SendEmailFromAccount("Уведомление на отмену изменения №: : " + id, reportHtml, EmailTasksList(id,true), Entry.Email);
            enG_EMAILTableAdapter.InsertNewRecord(id, null, 3, EmailTasksList(id, false), false);
        }
        string EmailTasksList(int id, bool type)
        {
            string list = "";
            if (type)
            {
                foreach (DataRow row in eNG_USERSTableAdapter.GetDataByIdProcForCancel(id).Rows)
                {
                    list += row["USER_EMAIL"] + ";";
                }
            }
            else
            {
                foreach (DataRow row in eNG_USERSTableAdapter.GetDataBySubIdProcForCancel(id).Rows)
                {
                    list += row["USER_EMAIL"] + ";";
                }
            }
        
        
            return list.TrimEnd(';');
        } //список адресов участников процесса
        void CancelEmailMulti(int subid)
        {
            //var proc = new CancelProcMulti();
            //proc.InitData(subid);
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
            //SendEmail.SendEmailFromAccount("Уведомление на отмену группы изменений №: : " + subid, reportHtml, EmailTasksList(subid,false), Entry.Email);
            enG_EMAILTableAdapter.InsertNewRecord(subid, null, 2, EmailTasksList(subid, false), false);
        }
        bool CheckPermissionsForCloseInitialisation()
        {
            return Entry.CategoryList.Contains("10");
        }
        private static string CommentForm()
        {
            XtraDialogForm form = new XtraDialogForm
            {
                Size = new Size(300, 100),
                StartPosition = FormStartPosition.CenterParent,
                Text = @"Примечание"
            };

            MemoEdit me = new MemoEdit
            {
                Name = "meText",
                Dock = DockStyle.Fill

            };
            SimpleButton btOk = new SimpleButton
            {
                Name = "btOK",
                Text = @"OK",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom
            };
            form.Controls.Add(me);
            form.Controls.Add(btOk);
            if (form.ShowDialog() == DialogResult.OK)
            {
                return me.Text;
            }
            else
            {
                return "";
            }
        }  //Коммент форма
        private void OnHrnsInfo(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                var leoniName = ri.View.GetRowCellValue(ri.RowHandle, "PROC_HRNS_NAME").ToString();
                HrnsInfo info = new HrnsInfo()
                {
                    LeoniName = leoniName,
                    Text = Text + @" " + leoniName
                };
                info.Show();
            }
        }  //Код Инфо о жгуте
        private void OnExport(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = @"Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    gridView1.OptionsPrint.PrintDetails = MessageBox.Show(@"Выгружать детали?", @"Детали", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes; ;
                    gridView1.OptionsPrint.ExpandAllDetails = true;
                    gridView1.OptionsPrint.AutoWidth = false;
                    gridView1.OptionsPrint.PrintGroupFooter = false;

                    XlsxExportOptionsEx opt =
                        new XlsxExportOptionsEx {ExportType = DevExpress.Export.ExportType.WYSIWYG};


                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridControl1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControl1.ExportToXlsx(exportFilePath, opt);
                            break;
                        case ".rtf":
                            gridControl1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControl1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControl1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControl1.ExportToMht(exportFilePath);
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        } //импорт в Excel
        private class RowInfo
        {
            public RowInfo(GridView view, int rowHandle)
            {
                RowHandle = rowHandle;
                View = view;
            }
            public readonly GridView View;
            public readonly int RowHandle;
        }
    }
}
