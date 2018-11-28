using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
namespace HangFireSample
{
    class Program
    {
        private static void ConfigureServer()
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(@"data source=.\MSSQL16; initial catalog=HangfireV1; integrated security=SSPI;");
        }
        private static void FireAndForget()
        {

            using (BackgroundJobServer server = new BackgroundJobServer())
            {
                BackgroundJob.Enqueue(() => Console.WriteLine("Hello Motherfucker!"));
                Console.ReadLine();
            }
            
        }
        private static void DelayedStart()
        {

            using (BackgroundJobServer server = new BackgroundJobServer(new BackgroundJobServerOptions
            {
                ServerName = "CyberSpear",
                SchedulePollingInterval = TimeSpan.FromSeconds(12) //default 15 sec
            }))
            {
                Console.WriteLine($"....Server started at {DateTime.Now}");
                
                BackgroundJob.Schedule(() => Console.WriteLine($".... > Hello Motherfucker {DateTime.Now}!"), TimeSpan.FromMinutes(0.5));
                Console.ReadLine();
            }

        }
        private static void RecurringJobSample()
        {

            using (BackgroundJobServer server = new BackgroundJobServer(new BackgroundJobServerOptions
            {
                ServerName = "CyberSpear",
                SchedulePollingInterval = TimeSpan.FromSeconds(12) //default 15 sec
            }))
            {
                Console.WriteLine($"....Server started at {DateTime.Now}");
                Console.WriteLine($"....Waiting for the job to be executed every minute");
                string id = Guid.NewGuid().ToString();
                RecurringJob.AddOrUpdate(id, () => Console.WriteLine($"....[{DateTime.Now}]"), Cron.Minutely());
                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            ConfigureServer();
            //FireAndForget();
            //DelayedStart();
            RecurringJobSample();
        }
    }
}
