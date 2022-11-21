using System.Drawing;
using ChangeMgmt.Properties;


namespace ChangeMgmt.Emails
{
    public partial class Attachments : DevExpress.XtraReports.UI.XtraReport
    {
        public Attachments()
        {
            InitializeComponent();
        }

        public void InitData(int id, string filename)
        {
            enG_PROCTableAdapter1.FillById(ds.ENG_PROC, id);
            enG_PRIORTableAdapter1.FillByPriorNo(ds.ENG_PRIOR, (int)ds.ENG_PROC[0]["PROC_PRIOR_NO"]);
            eNG_USERSTableAdapter.FillByUserNo(ds.ENG_USERS, (int)ds.ENG_PROC[0]["PROC_USER_NO"]);
            xrLabel1.Text = filename;
            xrLabel9.Text = @"Добавлено вложение: "+ Settings.Default.PathForSaveFile + @"\" + id;
            ColorChange();
        }

        private void ColorChange()
        {
            switch ((int)ds.ENG_PROC[0]["PROC_PRIOR_NO"])
            {
                case 1:
                    xrLabel10.BackColor = Color.Green;
                    break;
                case 2:
                    xrLabel10.BackColor = Color.Orange;
                    break;
                case 3:
                    xrLabel10.BackColor = Color.Red;
                    break;
            }
        }

    }
}
