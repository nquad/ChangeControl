
namespace ChangeMgmt.Emails
{
    public partial class FinishProcSingle : DevExpress.XtraReports.UI.XtraReport
    {
        public FinishProcSingle()
        {
            InitializeComponent();
        }
        public void InitData(int id)
        {
            enG_PROCTableAdapter1.FillById(ds.ENG_PROC, id);
            enG_PRIORTableAdapter1.FillByPriorNo(ds.ENG_PRIOR, (int)ds.ENG_PROC[0]["PROC_PRIOR_NO"]);
            eNG_USERSTableAdapter.FillByUserNo(ds.ENG_USERS, (int)ds.ENG_PROC[0]["PROC_USER_NO"]);
        }

    }
}
