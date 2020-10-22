using Confluent.Kafka;
using ConsoleApp2.Model;
using Newtonsoft.Json;

namespace ConsoleApp2.Service
{
    public class FeedFileManager : IManager
    {
        //private IProducer<string, string> _producer;
        private readonly IGetFileRecords getFileDetails;

        public FeedFileManager(IGetFileRecords getFileDetails)
        {
            // this.kafkaApiClient = kafkaApiClient;
            //this._producer = producer;
            this.getFileDetails = getFileDetails;
        }
        public async void ProcessFeedFile()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
           // var producer = new Producer<string,srin>
            //var getFileDetails = new GetFileRecords(environmentConfig);
            var feedFileRecords = getFileDetails.GetFileDetails();
            foreach (Profile record in feedFileRecords)
            {
                var producer = new ProducerWrapper(config, "kafkaservice");
                string serializedOrder = JsonConvert.SerializeObject(record);
                await producer.writeMessage(serializedOrder);
                //kafkaApiClient.CallKafkaProducerAPI(record);
            }
        }
        
    }
}
