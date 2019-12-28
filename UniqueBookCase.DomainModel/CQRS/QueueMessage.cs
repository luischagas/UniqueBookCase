
namespace UniqueBookCase.DomainModel.CQRS
{
    public abstract class QueueMessage : Message
    {
        public abstract string QueueName { get; }
    }
}
