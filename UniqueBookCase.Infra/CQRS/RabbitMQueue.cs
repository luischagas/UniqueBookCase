using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.CQRS;
using UniqueBookCase.DomainModel.Interfaces.CQRS;

namespace UniqueBookCase.Infra.CQRS
{
    public class RabbitMQueue : IQueue
    {
        public Task<string> DequeueAsync(string queueName)
        {
            throw new NotImplementedException();
        }

        public Task EnqueueAsync(QueueMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
