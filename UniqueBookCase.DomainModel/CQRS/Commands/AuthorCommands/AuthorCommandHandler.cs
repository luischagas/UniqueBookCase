using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.CQRS.Communication.Mediator;
using UniqueBookCase.DomainModel.Interfaces.CQRS;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands
{
    public class AuthorCommandHandler :
        IRequestHandler<AddAuthorCommand, bool>,
        IRequestHandler<UpdateAuthorCommand, bool>,
        IRequestHandler<DeleteAuthorCommand, bool>
    {

        private readonly IAuthorCommands _authorCommands;
        private readonly IQueue _queue;

        public AuthorCommandHandler(IAuthorCommands authorCommands, IQueue queue)
        {
            _authorCommands = authorCommands;
            _queue = queue;
        }

        public async Task<bool> Handle(AddAuthorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

             await _authorCommands.AddAuthor(message.Author);

            _queue.Enqueue(message);

            return true;
        }
       
        public async Task<bool> Handle(UpdateAuthorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _authorCommands.UpdateAuthor(message.Author);

            _queue.Enqueue(message);

            return true;
        }

        public async Task<bool> Handle(DeleteAuthorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _authorCommands.DeleteAuthor(message.Author.Id);

            _queue.Enqueue(message);

            return true;
        }

        private bool ValidateCommand(Command message)
        {
            if (message.isValid()) return true;

            return false;
        }
    }
}
