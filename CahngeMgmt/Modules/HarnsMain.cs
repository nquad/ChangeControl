using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ChangeMgmt.Modules
{
    public partial class HarnsMain : XtraUserControl
    {
        private static HarnsMain _instance;
        public static HarnsMain Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HarnsMain();
                return _instance;
            }
        }
        public HarnsMain()
        {
            InitializeComponent();
        }

        private void HarnsMain_Load(object sender, EventArgs e)
        {
            eNG_HRNSTableAdapter.Fill(dS.ENG_HRNS);
        }

        private void btnLoadXls_Click(object sender, EventArgs e)
        {
            XtraOpenFileDialog od = new XtraOpenFileDialog
            {
                Filter = @"Excel Документ (*.xls, *.xlsx)|*.xls;*.xlsx"
            };
            if (od.ShowDialog() == DialogResult.OK)
            {
                ImportHrns import = new ImportHrns
                {
                    Path = od.FileName
                };
                import.Show();
            }

            eNG_HRNSTableAdapter.Fill(dS.ENG_HRNS);
        }
    }
}
