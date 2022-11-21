using ChangeMgmt.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace ChangeMgmt.Modules
{
    public partial class HistoryTask : DevExpress.XtraEditors.XtraUserControl
    {
        private static HistoryTask _instance;
        public static HistoryTask Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HistoryTask();
                return _instance;
            }
        }
        public HistoryTask()
        {
            InitializeComponent();
        }
        private void HistoryTask_Load(object sender, EventArgs e)
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
            eNG_PROCTableAdapter.FillByAllClosedProc(dS.ENG_PROC);
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
                e.Menu.Items.Clear();
                DXMenuItem itemFileAdd = CreateMenuItemExsportToFile(view);
                e.Menu.Items.Add(itemFileAdd);
            }
        }

        private DXMenuItem CreateMenuItemExsportToFile(GridView view)
        {
            DXMenuCheckItem checkItem = new DXMenuCheckItem("Выгрузить в файл",
                view.OptionsView.AllowCellMerge, null, OnExport);
            checkItem.ImageOptions.Image = imageCollection1.Images[4];
            return checkItem;
        }

        private void OnExport(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = @"Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    gridView1.OptionsPrint.PrintDetails = true;
                    gridView1.OptionsPrint.ExpandAllDetails = true;
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
    }
}
