using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailNotification.Common
{
    class SendEmail
    {
        public static void SendEmailFromAccount(string body,string recip, string Subject)
        {
            SmtpClient Smtp = new SmtpClient("svru1exchange01.prettl.local", 25);
            //Smtp.Credentials = new NetworkCredential("login", "pass");
            Smtp.EnableSsl = false;
            //Формирование письма
            MailMessage message = new MailMessage();
            message.From = new MailAddress("ChangeManagement@prettl.ru");
            string[] list = recip.Split(';');
            foreach (var addr in list)
            {
                if(addr!="")
                message.To.Add(new MailAddress(addr));
            }
           
            message.Subject = Subject;

            message.IsBodyHtml = true;

            message.Body = body;

            Smtp.Send(message); //отправка письма
        }
    }
}
