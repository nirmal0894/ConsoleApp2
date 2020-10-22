using ConsoleApp2.Config;
using System;

namespace ConsoleApp2.Service
{
    public class FeedFileProcessor : IScheduleFeedFile
    {
        public void Start()
        {
            var envConfig = new EnvironmentConfiguration();
            //var kafkaApiClient  = new KafkaApiClient(envConfig);

            var getFileDetails = new GetFileRecords(envConfig);
            var feedFileManager = new FeedFileManager(getFileDetails);
            feedFileManager.ProcessFeedFile();
        }

        public void Stop()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Service Stopped");
        }
    }
}
