using System.IO;
using System.Text;
using System.Timers;
using EmailNotification.Common;
using EmailNotification.Email_template;

namespace EmailNotification
{
    class Emails
    {
        //Comment
        //type_of_email
        //1 - Attachment
        //2 - CancelProcMulti
        //3 - CancelProcSingle
        //4 - DenyProcMulti
        //5 - DenyProcSingle
        //6 - FinishProcMulti
        //7 - FinishProcSingle
        //8 - Initialisation
        //9 - InitialisationMulti
        //10 - NewProcAprMulti
        //11 - NewProcSingle

        private DS _ds;
        private DSTableAdapters.ENG_EMAILTableAdapter enG_EMAILableAdapter1;
        private readonly Timer _t1 = new Timer();
        private string _reportHtml;
        public void EmailAttachment()
        {
            
            foreach (DS.ENG_EMAILRow row in _ds.ENG_EMAIL)
            {
                switch ((int)row["type_email"])
                {
                    case 1:
                        
                        Attachment proc = new Attachment();
                        proc.InitData((int)row["id_proc"], row["comment"].ToString());
                        proc.CreateDocument();
                        
                        using (Stream stream = new MemoryStream())
                        {
                            proc.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml,row["recip"].ToString(), "Уведомление об изменении №: :" + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int) row["id"]);
                        }
                        catch 
                        {
                            //ignore
                        }
                        break;
                    case 2:
                        CancelProcMulti proc2 = new CancelProcMulti();
                        proc2.InitData((int)row["id_proc"]);
                        proc2.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc2.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), "Уведомление на отмену группы изменений №: : " + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;
                    case 3:
                        CancelProcSingle proc3 = new CancelProcSingle();
                        proc3.InitData((int)row["id_proc"]);
                        proc3.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc3.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), "Уведомление на отмену изменения №: : " + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;
                    case 4:
                        DenyProcMulti proc4 = new DenyProcMulti();
                        proc4.InitData((int)row["id_proc"]);
                        proc4.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc4.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), "Уведомление на отмену изменения №: : " + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;
                    case 5:
                        DenyProcSingle proc5 = new DenyProcSingle();
                        proc5.InitData((int)row["id_proc"]);
                        proc5.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc5.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), "Уведомление на отмену изменения №: : " + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;
                    case 6:
                        FinishProcMulti proc6 = new FinishProcMulti();
                        proc6.InitData((int)row["id_proc"]);
                        proc6.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc6.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), "Завершение группового изменения №: : " + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;
                    case 7:
                        FinishProcSingle proc7 = new FinishProcSingle();
                        proc7.InitData((int)row["id_proc"]);
                        proc7.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc7.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), "Завершение внедрения изменения №: : " + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;
                    case 8:
                        Initialisation proc8 = new Initialisation();
                        proc8.InitData((int)row["id_proc"]);
                        proc8.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc8.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), row["comment"].ToString());
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;
                    case 9:
                        InitialisationMulti proc9 = new InitialisationMulti();
                        proc9.InitData((int)row["id_proc"]);
                        proc9.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc9.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), "Инициализация группы изменений № : " + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;
                    case 10:
                        NewProcAprMulti proc10 = new NewProcAprMulti();
                        proc10.InitData();
                        proc10.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc10.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), "Уведомление на одобрение группы изменений №: " + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;
                    case 11:
                        NewProcAprSingle proc11 = new NewProcAprSingle();
                        proc11.InitData((int)row["id_proc"]);
                        proc11.CreateDocument();
                        using (Stream stream = new MemoryStream())
                        {
                            proc11.ExportToHtml(stream);
                            stream.Position = 0;
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                _reportHtml = reader.ReadToEnd();
                            }
                        }

                        try
                        {
                            SendEmail.SendEmailFromAccount(_reportHtml, row["recip"].ToString(), "Уведомление на одобрение изменения №: " + row["id_proc"]);
                            enG_EMAILableAdapter1.UpdateRecord(true, (int)row["id"]);
                        }
                        catch
                        {
                            //ignore
                        }
                        break;

                }
            }
            
        }

        void CheckOpen()
        {
            this._ds = new EmailNotification.DS();
            this.enG_EMAILableAdapter1 = new EmailNotification.DSTableAdapters.ENG_EMAILTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._ds)).BeginInit();
            // 
            // ds
            // 
            this._ds.DataSetName = "DS";
            this._ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ENG_EMAILTableAdapter
            // 
            this.enG_EMAILableAdapter1.ClearBeforeFill = true;

            enG_EMAILableAdapter1.FillByOpen(_ds.ENG_EMAIL);
            EmailAttachment();

        }

        public void Send()
        {
            _t1.Interval = 20000;
            _t1.Elapsed += _t1_Elapsed;
            _t1.Enabled = true;
            
        }

        private void _t1_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckOpen();
        }
    }
}
