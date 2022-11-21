using System.Drawing;

namespace ChangeMgmt
{
    public partial class NewProc : DevExpress.XtraReports.UI.XtraReport
    {
        public NewProc()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            enG_PROCTableAdapter1.FillById(ds.ENG_PROC, (int)enG_PROCTableAdapter1.ScalarLastId());
            enG_PRIORTableAdapter1.FillByPriorNo(ds.ENG_PRIOR, (int)ds.ENG_PROC[0]["PROC_PRIOR_NO"]);
            eNG_USERSTableAdapter.FillByUserNo(ds.ENG_USERS, (int)ds.ENG_PROC[0]["PROC_USER_NO"]);
            
            ColorChange();
        }

        private void ColorChange()
        {
            if ((int) ds.ENG_PROC[0]["PROC_PRIOR_NO"] == 1)
            {
                xrLabel10.BackColor = Color.Green;
            }
            if ((int)ds.ENG_PROC[0]["PROC_PRIOR_NO"] == 2)
            {
                xrLabel10.BackColor = Color.Orange;
            }
            if ((int)ds.ENG_PROC[0]["PROC_PRIOR_NO"] == 3)
            {
                xrLabel10.BackColor = Color.Red;
            }

        }
      
    }
}
