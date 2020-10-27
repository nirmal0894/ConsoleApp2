using Confluent.Kafka;
using ConsoleApp2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Service
{
    public interface IManager
    {
        Task<KafkaProcesStatus> ProcessFeedFile();
    }
}
