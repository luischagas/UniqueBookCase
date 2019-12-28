using UniqueBookCase.DomainModel.CQRS;

namespace UniqueBookCase.DomainModel.Interfaces.CQRS
{
    public interface IQueue
    {
        void Enqueue(QueueMessage message);
        string Dequeue(string queueName);
    }
}
