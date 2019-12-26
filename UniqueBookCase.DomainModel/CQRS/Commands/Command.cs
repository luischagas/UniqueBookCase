using FluentValidation.Results;
using MediatR;
using System;

namespace UniqueBookCase.DomainModel.CQRS.Commands
{
    public abstract class Command : QueueMessage, IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool isValid()
        {
            throw new NotImplementedException();
        }
    }
}
