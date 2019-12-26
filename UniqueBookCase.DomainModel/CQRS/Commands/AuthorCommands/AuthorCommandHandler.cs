using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.CQRS.Communication.Mediator;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands
{
    public class AuthorCommandHandler :
        IRequestHandler<AddAuthorCommand, bool>,
        IRequestHandler<UpdateAuthorCommand, bool>,
        IRequestHandler<DeleteAuthorCommand, bool>
    {

        private readonly IAuthorCommands _authorService;

        public AuthorCommandHandler(IAuthorCommands authorService)
        {
            _authorService = authorService;
        }

        public async Task<bool> Handle(AddAuthorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

             await _authorService.AddAuthor(message.Author);

            return true;
        }
       
        public async Task<bool> Handle(UpdateAuthorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _authorService.UpdateAuthor(message.Author);

            return true;
        }

        public async Task<bool> Handle(DeleteAuthorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _authorService.DeleteAuthor(message.Author.Id);

            return true;
        }

        private bool ValidateCommand(Command message)
        {
            if (message.isValid()) return true;

            return false;
        }
    }
}
