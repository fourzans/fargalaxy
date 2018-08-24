using FarGalaxy.Api.Jobs;
using Quartz;
using System;
using System.Threading.Tasks;
using static Quartz.Impl.StdSchedulerFactory;
using static Quartz.JobBuilder;
using static System.TimeSpan;

namespace FarGalaxy.Api.App_Start
{
    public static class JobScheduler
    {
        public static void Start()
        {
            RunJob().GetAwaiter().GetResult();
        }

        private static async Task RunJob()
        {
            IScheduler scheduler = await GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = Create<KeepAliveJob>().Build();

            ITrigger trigger = TriggerBuilder
                .Create()
                .StartAt(DateTimeOffset.Now.AddSeconds(20))
                .WithSimpleSchedule(x => x
                    .WithInterval(FromSeconds(1))
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}