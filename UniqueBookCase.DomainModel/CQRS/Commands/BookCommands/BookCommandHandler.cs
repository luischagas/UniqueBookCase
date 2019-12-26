using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.DomainModel.CQRS.Commands.BookCommands
{
    public class BookCommandHandler :
        IRequestHandler<AddBookCommand, bool>,
        IRequestHandler<UpdateBookCommand, bool>,
        IRequestHandler<DeleteBookCommand, bool>
    {

        private readonly IBookCommands _bookCommands;

        public BookCommandHandler(IBookCommands bookCommands)
        {
            _bookCommands = bookCommands;
        }

        public async Task<bool> Handle(AddBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _bookCommands.AddBook(message.Book);

            return true;
        }

        public async Task<bool> Handle(UpdateBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _bookCommands.UpdateBook(message.Book);

            return true;
        }

        public async Task<bool> Handle(DeleteBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _bookCommands.DeleteBook(message.Book.Id);

            return true;
        }

        private bool ValidateCommand(Command message)
        {
            if (message.isValid()) return true;

            return false;
        }
    }
}
