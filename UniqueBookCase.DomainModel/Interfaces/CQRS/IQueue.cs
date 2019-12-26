using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.CQRS;

namespace UniqueBookCase.DomainModel.Interfaces.CQRS
{
    public interface IQueue
    {
        void Enqueue(QueueMessage message);
        string Dequeue(string queueName);
    }
}
