using System.Drawing;


namespace EmailNotification.Email_template
{
    public partial class CancelProcSingle : DevExpress.XtraReports.UI.XtraReport
    {
        public CancelProcSingle()
        {
            InitializeComponent();
        }
        public void InitData(int id)
        {
            enG_PROCTableAdapter1.FillById(ds.ENG_PROC, id);
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
