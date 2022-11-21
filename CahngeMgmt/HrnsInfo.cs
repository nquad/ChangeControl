using ChangeMgmt.Properties;
using System;
using System.Diagnostics;


namespace ChangeMgmt
{
    public partial class HrnsInfo : DevExpress.XtraEditors.XtraForm
    {
        public string LeoniName { get; set; }

        public HrnsInfo()
        {
            InitializeComponent();
        }
     
        private void HrnsInfo_Load(object sender, EventArgs e)
        {
            eNG_HRNSTableAdapter.FillByLeoniName(dS.ENG_HRNS, LeoniName);

            eNG_PROCTableAdapter.FillByLeoniName(dS.ENG_PROC,LeoniName);
            enG_PROC_TASKSTableAdapter.Fill(dS.ENG_PROC_TASKS);
            eNG_USERSTableAdapter.Fill(dS.ENG_USERS);
            
            eNG_PRIORTableAdapter.Fill(dS.ENG_PRIOR);
            eNG_CATEGORYTableAdapter.Fill(dS.ENG_CATEGORY);
            eNG_STATUSTableAdapter.Fill(dS.ENG_STATUS);
            gridView1.ExpandAllGroups();
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