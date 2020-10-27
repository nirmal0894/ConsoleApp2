using Confluent.Kafka;
using ConsoleApp2.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ConsoleApp2.Service
{
    public class FeedFileManager : IManager
    {
        //private IProducer<string, string> _producer;
        private readonly IGetFileRecords getFileDetails;
       

        public FeedFileManager(IGetFileRecords getFileDetails)
        {
            //this._producer = producer;
            this.getFileDetails = getFileDetails;
        }
        public async Task<KafkaProcesStatus> ProcessFeedFile()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            var response = new DeliveryResult<string, string>();
            var feedFileRecords = getFileDetails.GetFileDetails();
            if (feedFileRecords != null)
            {
                foreach (Profile record in feedFileRecords)
                {
                    var producer = new ProducerWrapper(config, "kafkaservice");
                    string serializedOrder = JsonConvert.SerializeObject(record);
                    response = await producer.writeMessage(serializedOrder);
                }
            }
            if(response.Status.ToString().Equals("Persisted"))
            {
                return KafkaProcesStatus.completed;
            }
            return KafkaProcesStatus.error;
        }
        
    }
}
