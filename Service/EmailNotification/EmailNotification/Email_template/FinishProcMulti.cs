
namespace EmailNotification.Email_template
{
    public partial class FinishProcMulti : DevExpress.XtraReports.UI.XtraReport
    {
        public FinishProcMulti()
        {
            InitializeComponent();
        }
        public void InitData(int subId)
        {
            enG_PROCTableAdapter1.FillBySubId(ds.ENG_PROC, subId);
            enG_PRIORTableAdapter1.FillByPriorNo(ds.ENG_PRIOR, (int)ds.ENG_PROC[0]["PROC_PRIOR_NO"]);
            eNG_USERSTableAdapter.FillByUserNo(ds.ENG_USERS, (int)ds.ENG_PROC[0]["PROC_USER_NO"]);
        }
    }
}
