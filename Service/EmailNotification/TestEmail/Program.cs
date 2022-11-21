using System;
using System.ServiceProcess;


namespace TestEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new EmailNotification.Service1();
            ServiceBase[] serviceToRun = new ServiceBase[] { service };
            if (Environment.UserInteractive)
            {
                Console.CancelKeyPress += (x, y) => service.Stop();

                service.Start();
                Console.Write(@"Служба запущена. Нажмите любую кнопку для его остановки!");
                Console.ReadKey();
                service.Stop_();
                Console.Write(@"Служба остановлена.");
            }
            else
            {
                ServiceBase.Run(serviceToRun);
            }

        }
    }
}
