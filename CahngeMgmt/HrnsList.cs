using System;
using System.Data;
using System.Windows.Forms;


namespace ChangeMgmt
{
    public partial class HrnsList : DevExpress.XtraEditors.XtraForm
    {
        public DataTable Hrns;
        public DataTable SelectedHrns = new DataTable("SelectedHrns");
        public HrnsList()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedHrns = Hrns.Clone();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    try
                    {
                        DataRow row = gridView1.GetDataRow(i);
                        SelectedHrns.ImportRow(row);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.HelpLink);
                    }
                }
            }
        }

        private void HrnsList_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = Hrns;
        }
    }
}