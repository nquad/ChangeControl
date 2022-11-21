using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace ChangeMgmt
{
    public partial class ImportHrns : DevExpress.XtraEditors.XtraForm
    {
        public string Path { get; set; }

        public ImportHrns()
        {
            InitializeComponent();
        }

        private void btnLoad_Click()
        {
           
            if (!string.IsNullOrWhiteSpace(Path))
            {
                DataSet ds = ImportExcel(Path);
                int update = 0;
                int newrow = 0;
                int miss = 0;
                for (int i = 5; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    if (!string.IsNullOrEmpty(row[4].ToString()))
                    {
                        DateTime? dat;
                        try
                        {
                            dat = (DateTime?)row[0];
                        }
                        catch
                        {
                            dat = DateTime.Now;
                        }

                        try
                        {
                            eNG_HRNSTableAdapter.InsertNewRow(row[4].ToString(), dat, row[1].ToString(),
                                row[2].ToString(),
                                row[3].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(),
                                row[8].ToString(),
                                row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString(),
                                row[13].ToString(),
                                row[14].ToString(), row[15].ToString(), row[16].ToString(), row[17].ToString(), null,row[18].ToString());
                            newrow = newrow + 1;
                        }
                        catch
                        {
                            try
                            {
                                eNG_HRNSTableAdapter.UpdateExistRow(dat, row[1].ToString(),
                                    row[2].ToString(),
                                    row[3].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(),
                                    row[8].ToString(),
                                    row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString(),
                                    row[13].ToString(),
                                    row[14].ToString(), row[15].ToString(), row[16].ToString(), row[17].ToString(), null,row[18].ToString(), row[4].ToString());
                                update = update + 1;
                            }
                            catch
                            {
                                miss = miss + 1;
                            }
                        }
                    }
                }
                MessageBox.Show(@"Добавлено новых строк: " + newrow + "\r\n" + @"Обновлено строк: " + update + "\r\n" +@"Пропущенно(ошибки): " + miss);
                 eNG_HRNSTableAdapter.Fill(dS.ENG_HRNS);
            }

        }

        public static DataSet ImportExcel(string fileName)
        {
            Stream stream = null;
            try
            {
                using (stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx)
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            // Choose one of either 1 or 2:

                            // 1. Use the reader methods
                            do
                            {
                                while (reader.Read())
                                {
                                    // reader.GetDouble(0);
                                }
                            } while (reader.NextResult());

                            // 2. Use the AsDataSet extension method
                            //var result = reader.AsDataSet();
                            return reader.AsDataSet();
                            // The result of each spreadsheet is in result.Tables
                        }
                }
            }
            finally
            {
                stream?.Dispose();
            }
        }

        private void ImportHrns_Load(object sender, EventArgs e)
        {
            eNG_HRNSTableAdapter.Fill(dS.ENG_HRNS);
            btnLoad_Click();

        }
    }
}