using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ChangeMgmt.Common
{
    using Outlook1 = Microsoft.Office.Interop.Outlook;
    class SendEmail
    {
        public static void SendEmailFromAccount(string subject, string body, string to, string smtpAddress)
        {
            var app = GetApplicationObject();
            // Create a new MailItem and set the To, Subject, and Body properties.
            Outlook1.MailItem newMail = (Outlook1.MailItem)app.CreateItem(Outlook1.OlItemType.olMailItem);
            newMail.To = to;
            newMail.Subject = subject;
            newMail.HTMLBody = body;

            // Retrieve the account that has the specific SMTP address.
            Outlook1.Account account = GetAccountForEmailAddress(app, smtpAddress);
            // Use this account to send the e-mail.
            newMail.SendUsingAccount = account;
            newMail.Send();
        }
        public static Outlook1.Account GetAccountForEmailAddress(Outlook1.Application application, string smtpAddress)
        {

            // Loop over the Accounts collection of the current Outlook session.
            Outlook1.Accounts accounts = application.Session.Accounts;
            foreach (Outlook1.Account account in accounts)
            {
                // When the e-mail address matches, return the account.
                if (account.SmtpAddress == smtpAddress)
                {
                    return account;
                }
            }
            throw new System.Exception($"No Account with SmtpAddress: {smtpAddress} exists!");
        }
        public static Outlook1.Application GetApplicationObject()
        {

            Outlook1.Application application;

            // Check whether there is an Outlook process running.
            if (Process.GetProcessesByName("OUTLOOK").Any())
            {

                // If so, use the GetActiveObject method to obtain the process and cast it to an Application object.
                application = Marshal.GetActiveObject("Outlook.Application") as Outlook1.Application;
            }
            else
            {

                // If not, create a new instance of Outlook and log on to the default profile.
                application = new Outlook1.Application();
                Outlook1.NameSpace nameSpace = application.GetNamespace("MAPI");
                nameSpace.Logon("", "", Missing.Value, Missing.Value);
            }

            // Return the Outlook Application object.
            return application;
        }


    }
}
