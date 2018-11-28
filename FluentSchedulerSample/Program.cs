using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentScheduler;
using static System.Console;
using System.Threading;

namespace FluentSchedulerSample
{
    public class MyJob : IJob
    {
        public void Execute()
        {
            WriteLine($"....<<HELLO WORLD>>");
        }
    }
    public class My2ndJob : IJob
    {
        public void Execute()
        {
            WriteLine($"....<<<HELLO MIRZA>>>");
        }
    }
    class Program
    {
        static void Sample1()
        {
            Registry registry = new Registry();
            registry.Schedule<MyJob>()
                .AndThen<My2ndJob>().WithName("__0x123__")
                .ToRunNow().AndEvery(5).Seconds();
            JobManager.JobStart += JobManager_JobStart;
            JobManager.JobEnd += JobManager_JobEnd;
            JobManager.Initialize(registry);
            ReadLine();
            JobManager.Stop();

        }

        private static void JobManager_JobEnd(JobEndInfo obj)
        {
            WriteLine($"....Task [{obj.Name}] stopped at {DateTime.Now} with duration of {obj.Duration.TotalSeconds} seconds\n\n");

        }

        private static void JobManager_JobStart(JobStartInfo obj)
        {
            WriteLine($"....Task [{obj.Name}] started at {obj.StartTime}");
        }

        static void Main(string[] args)
        {
            Sample1();
            ReadLine();
        }
    }
}
