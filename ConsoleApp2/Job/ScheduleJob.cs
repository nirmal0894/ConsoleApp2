using ConsoleApp2.Config;
using ConsoleApp2.Model;
using ConsoleApp2.Service;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Job
{
    public class ScheduleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            //var lastRun = context.PreviousFireTimeUtc?.DateTime.ToString() ?? string.Empty;
            //Log.Warning("Greetings from HelloJob!   Previous run: {lastRun}", lastRun);
            var envConfig = new EnvironmentConfiguration();
            

            var getFileDetails = new GetFileRecords(envConfig);
            var feedFileManager = new FeedFileManager(getFileDetails);
            var result = feedFileManager.ProcessFeedFile();

            if(result.Equals(KafkaProcesStatus.completed))
            {
                File.Delete(envConfig.FeedFileAbsolutePath);
            }
            
            return Task.CompletedTask;
        }
    }
}
