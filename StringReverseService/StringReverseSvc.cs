using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using FluentScheduler;
using System.IO;

namespace StringReverseService
{
    public class StringReverseExecutor
    {
        public StringReverseExecutor() { }
        public void Start()
        {
            JobManager.RemoveAllJobs();
            Registry registry = new Registry();
            registry.Schedule<StringReverseJob>().ToRunNow().AndEvery(1).Minutes();
            JobManager.Initialize(registry);
        }
        public void Stop()
        {
            JobManager.Stop();
        }
    }
    public class StringReverseSvc
    {
        public static void Run()
        {
            var code = HostFactory.Run((svc) =>
            {
                svc.Service<StringReverseExecutor>(obj =>
                {
                    obj.ConstructUsing(x => new StringReverseExecutor());
                    obj.WhenStarted(x => x.Start());
                    obj.WhenStopped(x => x.Stop());
                    obj.WhenShutdown(x => x.Stop());
                });

                svc.SetDescription("StringReverse service");
                svc.SetDisplayName("StrRevSvc");
                svc.SetServiceName("StrRevSvc");
                svc.EnableShutdown();
                svc.RunAsLocalSystem();
                svc.OnException((x) =>
                {
                    File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "svc_log.txt"), $"\n{x.ToString()}");
                });
                svc.StartAutomatically();
            });
        }
    }
}
