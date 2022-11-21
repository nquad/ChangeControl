using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ChangeMgmt.Common;
using ChangeMgmt.Emails;
using ChangeMgmt.Properties;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace ChangeMgmt.Modules
{
    public partial class ApprovalList : XtraUserControl
    {
        private static DataTable _categoriesTable = new DataTable("Categories"); 
        private static ApprovalList _instance;
        private string _typeofproc;
        public static ApprovalList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApprovalList();
                return _instance;
            }
        }
        public ApprovalList()
        {
            InitializeComponent();
        }
        private void ApprovalList_Load(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            UpdateTable();
            eNG_STATUSTableAdapter.Fill(dS.ENG_STATUS);
            eNG_PRIORTableAdapter.Fill(dS.ENG_PRIOR);
            splashScreenManager1.CloseWaitForm();
            timer1.Enabled = true;
            timer1.Interval = Convert.ToInt32(textEdit1.Text) * 60000;
            timer1.Start();
        }
        void UpdateTable()
        {
            gridControl1.DataSource = eNG_PROCTableAdapter.GetDatabyApproval(4);
            eNG_HRNSTableAdapter.Fill(dS.ENG_HRNS);
            eNG_USERSTableAdapter.Fill(dS.ENG_USERS);
            gridView1.ExpandAllGroups();
        }
        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                //MessageBox.Show(view.GetGroupRowValue(e.HitInfo.RowHandle).ToString());
                
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();
                // Add the Rows submenu with the 'Delete Row' command
                e.Menu.Items.Add(CreateSubMenuApr(view, rowHandle));
               
                e.Menu.Items.Add(CreateSubMenuDeny(view, rowHandle));
                DXMenuItem itemInfo = CreateMenuItemHrnsInfo(view, rowHandle);
                e.Menu.Items.Add(itemInfo);
            }
        }
        DXMenuCheckItem CreateMenuItemHrnsInfo(GridView view, int rowHandle)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Информация о жгуте",
                view.OptionsView.AllowCellMerge, null, OnHrnsInfo);
            checkItem.Tag = new RowInfo(view, rowHandle);
            checkItem.ImageOptions.Image = imageCollection1.Images[2];
            return checkItem;
        } //Меню Инфо о жгуте
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
        private DXMenuItem CreateSubMenuApr(GridView view, int rowHandle)
        {
            DXSubMenuItem subMenu = new DXSubMenuItem("Одобрение");
            string aprCurRow = "&Одобрить текущее изменение";
            string aprSelectedRows = "&Одобрить отмеченные изменения";
            string aprGroup = "&Одобрить группу изменений № " + view.GetGroupRowValue(rowHandle.GetHashCode());

            DXMenuItem menuItemApprCurRow =
                new DXMenuItem(aprCurRow, OnAprCurRowsClick, imageCollection1.Images[1])
                {
                    Tag = new RowInfo(view,
                        rowHandle),
                    Enabled = (view.SelectedRowsCount == 0)
                };
            DXMenuItem menuItemAprSelectedeRow =
                new DXMenuItem(aprSelectedRows, OnAprSelectedRowsClick, imageCollection1.Images[1])
                {
                    Tag = new RowInfo(view,
                    rowHandle),
                    Enabled = (view.SelectedRowsCount > 0)
                };
            DXMenuItem menuItemAprGroup =
                new DXMenuItem(aprGroup, OnAprGroupRowsClick, imageCollection1.Images[1])
                {
                    Tag = new RowInfo(view, rowHandle),
                    Enabled = (view.GetGroupRowValue(rowHandle.GetHashCode()).ToString() != "")
                };
                subMenu.Items.Add(menuItemApprCurRow);
                subMenu.Items.Add(menuItemAprSelectedeRow);
                subMenu.Items.Add(menuItemAprGroup);
            return subMenu;
        }
        private DXMenuItem CreateSubMenuDeny(GridView view, int rowHandle)
        {
            DXSubMenuItem subMenu = new DXSubMenuItem("Отклонение");
            var denyCurRow = "&Отклонить текущее изменение";
            var denySelectedRows = "&Отклонить отмеченные изменения";
            var denyGroup = "&Отклонить группу изменений № "+ view.GetGroupRowValue(rowHandle.GetHashCode());


            DXMenuItem menuItemDenyCurentRow =
                new DXMenuItem(denyCurRow, OnDenyCurRowsClick, imageCollection1.Images[0])
                {
                    Tag = new RowInfo(view, rowHandle),
                    Enabled = (view.SelectedRowsCount==0)
                };

            DXMenuItem menuItemDenySelectedeRow =
                new DXMenuItem(denySelectedRows, OnDenySelectedRowsClick, imageCollection1.Images[0])
                {
                    Tag = new RowInfo(view, rowHandle),
                    Enabled = (view.SelectedRowsCount > 0)
                };
            DXMenuItem menuItemDenyGroup =
                new DXMenuItem(denyGroup, OnDenyGroupRowsClick, imageCollection1.Images[0])
                {
                    Tag = new RowInfo(view, rowHandle),
                    Enabled = (view.GetGroupRowValue(rowHandle.GetHashCode()).ToString() != "")
                };
                subMenu.Items.Add(menuItemDenyCurentRow);
                subMenu.Items.Add(menuItemDenySelectedeRow);
                subMenu.Items.Add(menuItemDenyGroup);
           
            return subMenu;
        }
        void OnAprCurRowsClick(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                _typeofproc = "task";
                if (Categories())
                {
                    string p = ri.View.GetRowCellValue(ri.RowHandle, "PROC_NO").ToString();
                    eNG_PROCTableAdapter.UpdateAprStatusByID(1, Entry.UserId, CommentForm(), DateTime.Now,
                       Convert.ToInt32(p), Convert.ToInt32(p));
                    CreateTasks(Convert.ToInt32(p),0,_typeofproc);
                    EmailAprSingl(Convert.ToInt32(p));
                
                }
                else
                {
                    XtraMessageBox.Show(@"Категории не выбраны",@"Предупреждение",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                UpdateTable();
            }
        }
        private void EmailAprSingl(int id)
        {
            //var proc = new Initialisation();
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
            //SendEmail.SendEmailFromAccount("Инициализация процесса № : " + id, reportHtml, EmailTasksList(), Entry.Email);
            enG_EMAILTableAdapter.InsertNewRecord(id, "Инициализация процесса № : " + id, 8, EmailTasksList(), false);
        }
        private void EmailAprMulti(int idSub)
        {
            //var proc = new InitialisationMulti();
            //proc.InitData(idSub);
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
            //SendEmail.SendEmailFromAccount("Инициализация группы изменений № : " + idSub, reportHtml, EmailTasksList(), Entry.Email);
            enG_EMAILTableAdapter.InsertNewRecord(idSub, null, 9, EmailTasksList(), false);
        }
        private void EmailВDenySingl(int id)
        {
            //var proc = new Initialisation();
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
            //SendEmail.SendEmailFromAccount("В изменении №: "+ id + " отказано", reportHtml, EmailDenyList(id,"id"), Entry.Email);
            enG_EMAILTableAdapter.InsertNewRecord(id, "В изменении №: " + id + " отказано", 8, EmailDenyList(id, "id"), false);
        }
        private void EmailВDenyMulti(int SubId)
        {
            //var proc = new Initialisation();
            //proc.InitData(SubId);
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
            //SendEmail.SendEmailFromAccount("В группе изменений №: " + SubId + " отказано", reportHtml, EmailDenyList(SubId,"sub"), Entry.Email);
            enG_EMAILTableAdapter.InsertNewRecord(SubId, "В группе изменений №: " + SubId + " отказано", 8, EmailDenyList(SubId, "sub"), false);
        }
        string EmailTasksList()
        {
            string list = "";
            foreach (DataRow cat in _categoriesTable.Rows)
            {
                if (cat["CAT_TYPE_NO"].ToString() == "1" || cat["CAT_TYPE_NO"].ToString() == "2")
                {
                    foreach (DataRow row in eNG_USERSTableAdapter.GetDataByUserCatId((int)cat["CAT_NO"]).Rows)
                    {
                        if((string)row["USER_EMAIL"] != "")
                        {
                            if(!list.Contains((string)row["USER_EMAIL"]))
                            {
                                list += row["USER_EMAIL"] + ";";
                            }
                        }
                        
                    }
                }
            }
            return list.TrimEnd(';');
        } //список адресов участников процесса
        string EmailDenyList(int ownerId, string type) 
        {
            if (type == "id")
            {
                return eNG_PROCTableAdapter.ScalarEmailOwnerSingle(ownerId);
            }
            else
            {
                return eNG_PROCTableAdapter.ScalarEmailOwnerMulti(ownerId);
            }
           
        } //почта владельца процесса
        void OnAprSelectedRowsClick(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                _typeofproc = "task";
                if (Categories())
                {
                    for (int i = 0; i < ri.View.DataRowCount; i++)
                    {
                        if (ri.View.IsRowSelected(i))
                        {
                            string p = ri.View.GetRowCellValue(i, "PROC_NO").ToString();
                            eNG_PROCTableAdapter.UpdateAprStatusByID(1, Entry.UserId, CommentForm(), DateTime.Now,
                                Convert.ToInt32(p), Convert.ToInt32(p));
                            CreateTasks(Convert.ToInt32(p),0, _typeofproc);
                            EmailAprSingl(Convert.ToInt32(p));
                        }
                    }
                    
                }
                UpdateTable();
            }
        }
        void OnAprGroupRowsClick(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                _typeofproc = "multi";
                if (Categories())
                {
                    string p = ri.View.GetGroupRowValue(ri.RowHandle).ToString();
                    eNG_PROCTableAdapter.UpdateAprStatusBySubId(1, Entry.UserId, CommentForm(), DateTime.Now,
                        Convert.ToInt32(p), Convert.ToInt32(p));
                    CreateTasks(0, Convert.ToInt32(p), _typeofproc);
                    EmailAprMulti(Convert.ToInt32(p));
                }
                UpdateTable();
            }
        }
        void OnDenyCurRowsClick(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
              string p = ri.View.GetRowCellValue(ri.RowHandle, "PROC_NO").ToString();
                DialogResult dialogResult = MessageBox.Show(@"Отклонить?", @"Подтверждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    eNG_PROCTableAdapter.UpdateAprStatusByID(5, Entry.UserId, CommentForm(), DateTime.Now,
                        Convert.ToInt32(p), Convert.ToInt32(p));
                    EmailВDenySingl(Convert.ToInt32(p));
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            UpdateTable();
        }
        void OnDenySelectedRowsClick(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                for (int i = 0; i < ri.View.DataRowCount; i++)
                {
                    if (ri.View.IsRowSelected(i))
                    {
                        string p = ri.View.GetRowCellValue(i, "PROC_NO").ToString();
                        DialogResult dialogResult = MessageBox.Show(@"Отклонить?", @"Подтверждение", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            eNG_PROCTableAdapter.UpdateAprStatusByID(5, Entry.UserId, CommentForm(), DateTime.Now,
                            Convert.ToInt32(p), Convert.ToInt32(p));
                        EmailВDenySingl(Convert.ToInt32(p));
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                    }
                }
            }
            UpdateTable();
        }
        void OnDenyGroupRowsClick(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem?.Tag is RowInfo ri)
            {
                string p = ri.View.GetGroupRowValue(ri.RowHandle).ToString();
                DialogResult dialogResult = MessageBox.Show(@"Отклонить?", @"Подтверждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    eNG_PROCTableAdapter.UpdateAprStatusBySubId(5, Entry.UserId, CommentForm(), DateTime.Now,
                    Convert.ToInt32(p), Convert.ToInt32(p));
                EmailВDenyMulti(Convert.ToInt32(p));
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            UpdateTable();
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
        private static string CommentForm()
        {
            XtraDialogForm form = new XtraDialogForm
            {
                Size = new Size(300,100),
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
            SimpleButton btNok = new SimpleButton
            {
                Name = "btNok",
                Text = @"Cancel",
                DialogResult = DialogResult.No,
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
                form.Close();
                return "";
            }
           
        }
        void CreateTasks(int procId, int procSubid, string value)
        {
            if (value == "task")
            {
                string catList = "";
                foreach (DataRow unused in _categoriesTable.Rows)
                {
                    if (unused["CAT_TYPE_NO"].ToString() == "1")
                    {
                        enG_PROC_TASKSTableAdapter.Insert(Convert.ToInt32(unused["CAT_NO"]), null, false, null, null, procId);
                        catList += unused["CAT_NO"] + ";";
                    }
                }

                enG_NOTIFICATIONTableAdapter.Insert(procId, catList.TrimEnd(';'), Entry.UserId, null);

            }
            else if (value == "multi")
            {
                string catList = "";
                foreach (DataRow unused in _categoriesTable.Rows)
                {
                    if (unused["CAT_TYPE_NO"].ToString() == "1")
                    {
                        foreach (DataRow proc in eNG_PROCTableAdapter.GetDataBySubId(procSubid).Rows)
                        {
                            enG_PROC_TASKSTableAdapter.Insert(Convert.ToInt32(unused["CAT_NO"]), null, false, null, null, Convert.ToInt32(proc["PROC_NO"]));
                        }
                        catList += unused["CAT_NO"] + ";";
                    }
                }
                enG_NOTIFICATIONTableAdapter.Insert(null, catList.TrimEnd(';'), Entry.UserId, procSubid);
            }
           
        }
        bool Categories()
        {
            Category cat = new Category();
            if (cat.ShowDialog() == DialogResult.OK)
            {
                _categoriesTable = cat.CategoryTable;
            }
            return (_categoriesTable.Rows.Count > 0);
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
    }
}
