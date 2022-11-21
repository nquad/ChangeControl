using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ChangeMgmt.Common;
using ChangeMgmt.Properties;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;


namespace ChangeMgmt.Modules
{
    public partial class MyTasks : XtraUserControl
    {
        private static MyTasks _instance;
        public static MyTasks Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MyTasks();
                return _instance;
            }
        }
        public MyTasks()
        {
            InitializeComponent();
        }
        private void MyTasks_Load(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            UpdateTable();
            eNG_PRIORTableAdapter.Fill(dS.ENG_PRIOR);
            eNG_CATEGORYTableAdapter.Fill(dS.ENG_CATEGORY);
            eNG_STATUSTableAdapter.Fill(dS.ENG_STATUS);
            splashScreenManager1.CloseWaitForm();
            //timer1.Enabled = checkEdit1.Checked;
            //timer1.Interval = Convert.ToInt32(textEdit1.Text)*60000;
            UpdateTable();
            //timer1.Start();
        }
        private void UpdateTable()
        {
            eNG_PROCTableAdapter.FillByUserId(dS.ENG_PROC, Entry.UserId);
            enG_PROC_TASKSTableAdapter.Fill(dS.ENG_PROC_TASKS);
            eNG_USERSTableAdapter.Fill(dS.ENG_USERS);
            gridView1.ExpandAllGroups();
        }
        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();
                e.Menu.Items.Add(CreateSubMenuCloseCurTask(view, rowHandle));
                if (CreateSubCloseGroupTask(view, rowHandle) != null)
                {
                    e.Menu.Items.Add(CreateSubCloseGroupTask(view, rowHandle));
                    e.Menu.Items.Add(SubMenuCloseSelectedInGroup(view, rowHandle));
                }
                DXMenuItem itemCancel = CreateMenuItemCancel(view, rowHandle);
                itemCancel.BeginGroup = true;
                DXMenuItem itemUpdate = CreateMenuItemUpdateTable(view, rowHandle);
                DXMenuItem itemInfo = CreateMenuItemHrnsInfo(view, rowHandle);
                DXMenuItem itemFileAdd = CreateMenuItemFileAdd(view, rowHandle);
                DXMenuItem itemExport = CreateMenuItemExsportToFile(view);

                e.Menu.Items.Add(itemUpdate);
                //e.Menu.Items.Add(itemCancel);
                e.Menu.Items.Add(itemFileAdd);
                e.Menu.Items.Add(itemInfo);
                e.Menu.Items.Add(itemExport);

            }
        }
        private DXMenuItem CreateMenuItemUpdateTable(GridView view, int rowHandle)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Обновить",
                view.OptionsView.AllowCellMerge, null, OnUpdate);
            checkItem.Tag = new RowInfo(view, rowHandle);
            checkItem.ImageOptions.Image = imageCollection1.Images[4];
            return checkItem;
        }
        private DXMenuItem CreateMenuItemFileAdd(GridView view, int rowHandle)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Добавить документацию",
                view.OptionsView.AllowCellMerge, null, OnAddFiles);
            checkItem.Tag = new RowInfo(view, rowHandle);
            checkItem.ImageOptions.Image = imageCollection1.Images[3];
            return checkItem;
        } //Меню Добавление документации
        private void OnAddFiles(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                int p = Convert.ToInt32(ri.View.GetRowCellValue(ri.RowHandle, "PROC_NO"));
                string subId = ri.View.GetGroupRowValue(ri.RowHandle).ToString();
                if (CheckPermissionsForCloseInitialisation(ri))
                {
                    AddFiles(subId, p);
                }
            }
        }
        void AddFiles(string sub, int id)
        {
            using (XtraOpenFileDialog dialog = new XtraOpenFileDialog())// создание нового OpenFileDialog
            {
                dialog.Multiselect = true;
                var files = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                   foreach (var item in dialog.FileNames)
                    {
                        try
                        {
                            var pathEnd = sub != "" ? new DirectoryInfo(Settings.Default.PathForSaveFile + @"\" + sub + "sub") : new DirectoryInfo(Settings.Default.PathForSaveFile + @"\" + id);
                            Copy(item, pathEnd.ToString(), item.Split('\\')[item.Split('\\').Length - 1]);
                            files += item.Split('\\')[item.Split('\\').Length - 1] + " | ";
                        }
                        catch 
                        {
                            MessageBox.Show(@"Один из документов имеет дубликат");
                        }
                    }

                    EmailAttachment(id, files.TrimEnd(' ').TrimEnd('|'));
                }
            }
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
        DXMenuCheckItem CreateMenuItemHrnsInfo(GridView view, int rowHandle)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Информация о жгуте",
                view.OptionsView.AllowCellMerge, null, OnHrnsInfo);
            checkItem.Tag = new RowInfo(view, rowHandle);
            checkItem.ImageOptions.Image = imageCollection1.Images[2];
            return checkItem;
        } //Меню Инфо о жгуте
        DXMenuCheckItem CreateMenuItemCancel(GridView view, int rowHandle)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Отменить изменение",
                view.OptionsView.AllowCellMerge, null, CancelTask);
            checkItem.Tag = new RowInfo(view, rowHandle);
            checkItem.ImageOptions.Image = imageCollection1.Images[1];
            return checkItem;
        } //Меню отмена изменения
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
        private DXMenuItem CreateSubMenuCloseCurTask(GridView view, int rowHandle)
        {
           // view.ClearSelection();
           //view.SelectRow(rowHandle);
            DXSubMenuItem subMenu = new DXSubMenuItem("Закрыть текущее изменение");
            int p = Convert.ToInt32(view.GetRowCellValue(rowHandle, "PROC_NO"));
            foreach (DataRow ri in Entry.CategoryTable.Rows)
            {
                if (ri["CAT_TYPE_NO"].ToString() == "1" && ChecktaskInProc(p,Convert.ToInt32(ri["CAT_NO"])))
                {
                    var menuItemApprCurRow = new DXMenuItem(ri["CAT_NAME"].ToString().TrimEnd(' '), CloseCurRow, imageCollection1.Images[0])
                    {
                        Tag = new RowInfo(view,
                            rowHandle),
                        Enabled = (view.SelectedRowsCount <2)

                    };
                    subMenu.Items.Add(menuItemApprCurRow);
                }
               
            }
            return subMenu;
        } //Меню закрыть текущее изменение
        bool ChecktaskInProc(int procId,int catId)
        {
            return enG_PROC_TASKSTableAdapter.ScalarCheckTaskInProc(procId, catId) == 1;
        }
        private DXMenuItem CreateSubCloseGroupTask(GridView view, int rowHandle)
        {
            int p = Convert.ToInt32(view.GetRowCellValue(rowHandle, "PROC_NO"));
           
            if (view.GetGroupRowValue(rowHandle).ToString() != "")
            {
                DXSubMenuItem subMenu =
                    new DXSubMenuItem("Закрыть все изменения в группе № " + view.GetGroupRowValue(rowHandle));
                foreach (DataRow ri in Entry.CategoryTable.Rows)
                {
                    if (ri["CAT_TYPE_NO"].ToString() == "1" && ChecktaskInProc(p, Convert.ToInt32(ri["CAT_NO"])))
                    {
                        var menuItemApprCurRow = new DXMenuItem(ri["CAT_NAME"].ToString().TrimEnd(' '),
                            CloseTaskInGroup, imageCollection1.Images[0])
                        {
                            Tag = new RowInfo(view,
                                rowHandle),
                        };
                        subMenu.Items.Add(menuItemApprCurRow);
                    }

                }

                return subMenu;
            }
            else
            {
                return null;
            }
        }  //Меню закрыть текущее изменение в группе
        private DXMenuItem SubMenuCloseSelectedInGroup(GridView view, int rowHandle)
        {
            if (view.GetGroupRowValue(rowHandle).ToString() != "")
            {
                DXSubMenuItem subMenu =
                    new DXSubMenuItem("Закрыть выделенные изменения в группе № " + view.GetGroupRowValue(rowHandle));
                foreach (DataRow ri in Entry.CategoryTable.Rows)
                {
                    if (ri["CAT_TYPE_NO"].ToString() == "1")
                    {
                        var menuItemApprCurRow = new DXMenuItem(ri["CAT_NAME"].ToString().TrimEnd(' '),
                            CloseSelectedrRows, imageCollection1.Images[0])
                        {
                            Tag = new RowInfo(view,
                                rowHandle),
                            Enabled = (view.SelectedRowsCount > 0)
                        };
                        subMenu.Items.Add(menuItemApprCurRow);
                    }

                }

                return subMenu;
            }
            else
            {
                return null;
            }
        } //Меню закрыть выделенные изменения в группе
        void CloseCurRow(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                int p = Convert.ToInt32(ri.View.GetRowCellValue(ri.RowHandle, "PROC_NO"));
                if (CheckPermissionsForCloseInitialisation(ri))
                {
                    if (XtraMessageBox.Show("Закрыть задачу "+menuItem.Caption+" для жгута " + ri.View.GetRowCellValue(ri.RowHandle, "PROC_HRNS_NAME") + " ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        enG_PROC_TASKSTableAdapter.UpdateCloseTaskByProcIDAndCatName(DateTime.Now, true, Entry.UserId,
                            CommentForm(), p, menuItem.Caption);
                        eNG_PROCTableAdapter.UpdateStatus(2, p);
                        if (enG_PROC_TASKSTableAdapter.ScalarCheckAllClose(p) == 0 && ri.View.GetGroupRowValue(ri.RowHandle).ToString() == "")
                        {
                            eNG_PROCTableAdapter.UpdateStatus(3, p);
                            EmailTaskFinishSingle(p);
                        }
                        else if (ri.View.GetGroupRowValue(ri.RowHandle).ToString() != "") //проверка что это мультитаск
                        {
                            if (enG_PROC_TASKSTableAdapter.ScalarCheckAllCloseBySubId(Convert.ToInt32(ri.View.GetGroupRowValue(ri.RowHandle).ToString())) == 0)
                            {
                                eNG_PROCTableAdapter.UpdateStatusBySubId(3, Convert.ToInt32(ri.View.GetGroupRowValue(ri.RowHandle).ToString()));
                                EmailTaskFinishMulti(
                                    Convert.ToInt32(ri.View.GetGroupRowValue(ri.RowHandle).ToString()));
                            }
                        }
                    }
                    UpdateTable();
                }
                else
                {
                    XtraMessageBox.Show("У Вас нету прав для текущей инициализации", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        } //Код закрыть текущее изменение
        void CloseTaskInGroup(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                int p = Convert.ToInt32(ri.View.GetRowCellValue(ri.RowHandle, "PROC_NO"));
                if (CheckPermissionsForCloseInitialisation(ri))
                {
                    int subId = Convert.ToInt32(ri.View.GetGroupRowValue(ri.RowHandle));
                    if (XtraMessageBox.Show("Закрыть задачи " + menuItem.Caption + " в группе " + subId + " ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        enG_PROC_TASKSTableAdapter.UpdateCloseTasksInGroupBySubIDCatName(DateTime.Now, true,
                            Entry.UserId, CommentForm(), subId, menuItem.Caption);
                        eNG_PROCTableAdapter.UpdateStatusBySubId(2,subId);
                        if (enG_PROC_TASKSTableAdapter.ScalarCheckAllClose(p) == 0 && ri.View.GetGroupRowValue(ri.RowHandle).ToString() == "")
                        {
                            eNG_PROCTableAdapter.UpdateStatus(3, p);
                            EmailTaskFinishSingle(p);
                        }
                        else if (enG_PROC_TASKSTableAdapter.ScalarCheckAllCloseBySubId(Convert.ToInt32(ri.View.GetGroupRowValue(ri.RowHandle).ToString())) == 0 && ri.View.GetGroupRowValue(ri.RowHandle).ToString() != "")
                        {
                            eNG_PROCTableAdapter.UpdateStatusBySubId(3, subId);
                            EmailTaskFinishMulti(subId);
                        }
                    }

                    UpdateTable();
                }
                else
                {
                    XtraMessageBox.Show("У Вас нету прав для текущей инициализации", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        } //Код закрыть текущее изменение в группе
        void CloseSelectedrRows(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                
                if (CheckPermissionsForCloseInitialisation(ri))
                {
                    int qtySelected = ri.View.SelectedRowsCount;
                    if (XtraMessageBox.Show("Закрыть " + menuItem.Caption + " для " + qtySelected + " инициализации(й)?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        for (int i = 0; i < ri.View.DataRowCount; i++)
                        {
                            if (ri.View.IsRowSelected(i))
                            {
                               
                                int p = Convert.ToInt32(ri.View.GetRowCellValue(i, "PROC_NO")); //(replace ri.RowHandle to i)
                                enG_PROC_TASKSTableAdapter.UpdateCloseTaskByProcIDAndCatName(DateTime.Now, true, Entry.UserId,
                                    CommentForm(), p, menuItem.Caption);
                                eNG_PROCTableAdapter.UpdateStatus(2, p);
                                if (enG_PROC_TASKSTableAdapter.ScalarCheckAllClose(p) == 0 && ri.View.GetGroupRowValue(ri.RowHandle).ToString() == "")
                                {
                                    eNG_PROCTableAdapter.UpdateStatus(3, p);
                                    EmailTaskFinishSingle(p);
                                }
                                else if (enG_PROC_TASKSTableAdapter.ScalarCheckAllCloseBySubId(Convert.ToInt32(ri.View.GetGroupRowValue(ri.RowHandle).ToString())) == 0 && ri.View.GetGroupRowValue(ri.RowHandle).ToString() != "")
                                {
                                    eNG_PROCTableAdapter.UpdateStatusBySubId(3, Convert.ToInt32(ri.View.GetGroupRowValue(ri.RowHandle).ToString()));
                                    EmailTaskFinishMulti(
                                        Convert.ToInt32(ri.View.GetGroupRowValue(ri.RowHandle).ToString()));
                                }
                            }
                        }
                        
                        
                    }

                    UpdateTable();
                }
                else
                {
                    XtraMessageBox.Show("У Вас нету прав для текущей инициализации", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        } //Код закрыть выделенные изменение
        void CancelTask(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                int p = Convert.ToInt32(ri.View.GetRowCellValue(ri.RowHandle, "PROC_NO"));
                string subId = ri.View.GetGroupRowValue(ri.RowHandle).ToString();
                if (CheckPermissionsForCloseInitialisation(ri))
                {
                    if (subId == "")
                    {
                        if (XtraMessageBox.Show("Отменить инициализацию для жгута " + ri.View.GetRowCellValue(ri.RowHandle, "PROC_HRNS_NAME") + " ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            enG_PROC_TASKSTableAdapter.UpdateCancelByProcId(DateTime.Now, true, Entry.UserId,
                                CommentForm(), p);
                            eNG_PROCTableAdapter.UpdateStatus(6, p);
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
                            UpdateTable();
                        }
                    }
                    
                }
                else
                {
                    XtraMessageBox.Show("У Вас нету прав для текущей инициализации", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
              
            }
        }  //Код отмена изменения
        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateTable();
        }  //Код обновить
        private void OnHrnsInfo(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                var leoniName = ri.View.GetRowCellValue(ri.RowHandle, "PROC_HRNS_NAME").ToString();
                HrnsInfo info = new HrnsInfo()
                {
                    LeoniName = leoniName,
                    Text = Text+@" "+leoniName
                };
                info.Show();
            }
        }  //Код Инфо о жгуте
        bool CheckPermissionsForCloseInitialisation(RowInfo ri)
        {
            int p = Convert.ToInt32(ri.View.GetRowCellValue(ri.RowHandle, "PROC_NO"));
            bool valid = false;
            foreach (string aprTasks in Entry.CategoryList.Split(','))
            {
                foreach (DataRow tasks in enG_PROC_TASKSTableAdapter.GetDataByTaskId(p).Rows)
                {
                    if (aprTasks == tasks["TASK_CAT_NO"].ToString())
                    {

                        valid = true;
                    }
                }
            }

            return valid;
        }
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTable();
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(textEdit1.Text)*60000;
            if(checkEdit1.Checked)
            { timer1.Start();}
            else
            {timer1.Stop();}
            

        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                int p = Convert.ToInt32(ri.View.GetRowCellValue(ri.RowHandle, "PROC_NO"));
                string subId = ri.View.GetGroupRowValue(ri.RowHandle).ToString();
                var openpath = (subId == "")? Settings.Default.PathForSaveFile + @"\" + p: Settings.Default.PathForSaveFile + @"\" + subId + @"sub";
                try
                {
                    Process.Start(openpath);
                }
                catch 
                {
                  //ignored
                }
            }
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
        private DXMenuItem CreateMenuItemExsportToFile(GridView view)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Выгрузить в файл",
                view.OptionsView.AllowCellMerge, null, OnExport);
            checkItem.ImageOptions.Image = imageCollection1.Images[5];
            return checkItem;
        } //импорт в файл
        private void OnExport(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = @"Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    //if(MessageBox.Show("Выгружать детали?","Детали",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    gridView1.OptionsPrint.PrintDetails = MessageBox.Show(@"Выгружать детали?", @"Детали", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    gridView1.OptionsPrint.ExpandAllDetails = true;
                    gridView1.OptionsPrint.AutoWidth = false;
                    gridView1.OptionsPrint.PrintGroupFooter = false;
                    
                    XlsxExportOptionsEx opt =
                        new XlsxExportOptionsEx { ExportType = DevExpress.Export.ExportType.WYSIWYG };


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
        }
        void EmailTaskFinishSingle(int id)
        {
            //var proc = new FinishProcSingle();
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
            //SendEmail.SendEmailFromAccount("Завершение внедрения изменения №: : " + id , reportHtml, EmailList(id,true), Entry.Email);

            //enG_EMAILTableAdapter.InsertNewRecord(id, null, 7, EmailList(id, true), false);

        }
        void EmailAttachment(int id,string file)
        {
            //var proc = new Attachments();
            //proc.InitData(id,file);
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
            //SendEmail.SendEmailFromAccount("Уведомление об изменении №: :" + id, reportHtml, EmailList(id, true), Entry.Email);


           // enG_EMAILTableAdapter.InsertNewRecord(id, file, 1, EmailList(id, true), false);
        }
        void EmailTaskFinishMulti(int subid)
        {
            //var proc = new FinishProcMulti();
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
            //SendEmail.SendEmailFromAccount("Завершение группового изменения №: : " + subid, reportHtml, EmailList(subid,false), Entry.Email);

          //  enG_EMAILTableAdapter.InsertNewRecord(subid, null, 6, EmailList(subid, true), false);

        }
        string EmailList(int id, bool type)
        {
            string recip = "";
            var row = type ? enG_NOTIFICATIONTableAdapter.GetDataByProcNo(id).Rows[0] : enG_NOTIFICATIONTableAdapter.GetDataBySubId(id).Rows[0];
            string[] list = row["NOTIF_CAT_LIST"].ToString().Split(';');
            foreach (var cat in list)
            {
                foreach (DataRow email in eNG_USERSTableAdapter.GetDataByUserCatId(Convert.ToInt32(cat)).Rows)
                {
                    if (!recip.Contains(email["USER_EMAIL"].ToString()))
                    {
                        recip += email["USER_EMAIL"].ToString()+';';
                    }
                }
            }
            //return "artem.sokolov@leoni.com";
           return recip.TrimEnd(';');
        }
    }
}
