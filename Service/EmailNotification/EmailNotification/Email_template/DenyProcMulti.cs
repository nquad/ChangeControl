using System.Drawing;


namespace EmailNotification.Email_template
{
    public partial class DenyProcMulti : DevExpress.XtraReports.UI.XtraReport
    {
        public DenyProcMulti()
        {
            InitializeComponent();
        }
        public void InitData(int subId)
        {
            enG_PROCTableAdapter1.FillBySubId(ds.ENG_PROC, subId);
            enG_PRIORTableAdapter1.FillByPriorNo(ds.ENG_PRIOR, (int)ds.ENG_PROC[0]["PROC_PRIOR_NO"]);
            eNG_USERSTableAdapter.FillByUserNo(ds.ENG_USERS, (int)ds.ENG_PROC[0]["PROC_USER_NO"]);
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
