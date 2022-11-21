using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils.Commands;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;


namespace ChangeMgmt
{
    public partial class Category : DevExpress.XtraEditors.XtraForm
    {
        public DataTable CategoryTable = new DataTable("Category");
        public Category()
        {
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            eNG_CATEGORY_TYPETableAdapter.Fill(dS.ENG_CATEGORY_TYPE);
            eNG_CATEGORYTableAdapter.Fill(dS.ENG_CATEGORY);
           
        }

        private void DefaultValues()
        {
            foreach (DataRow row in dS.ENG_CATEGORY.Rows)
            {
                if (row["CAT_DEF_VALUE"].ToString() == "True")
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, colCAT_NAME).ToString() == row["CAT_NAME"].ToString())
                        {
                            gridView1.SelectRow(i);
                        }
                    }
                }
            }
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            CategoryTable = dS.ENG_CATEGORY.Clone();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    try
                    {
                        DataRow row = gridView1.GetDataRow(i);
                        CategoryTable.ImportRow(row);
                    }
                    catch (Exception exception)
                    {
                        XtraMessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void gridView1_RowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            DefaultValues();
        }
    }
}