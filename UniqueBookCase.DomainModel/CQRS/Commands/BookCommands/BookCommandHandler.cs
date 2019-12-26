using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.Interfaces.CQRS;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.DomainModel.CQRS.Commands.BookCommands
{
    public class BookCommandHandler :
        IRequestHandler<AddBookCommand, bool>,
        IRequestHandler<UpdateBookCommand, bool>,
        IRequestHandler<DeleteBookCommand, bool>
    {

        private readonly IBookCommands _bookCommands;
        private readonly IQueue _queue;

        public BookCommandHandler(IBookCommands bookCommands, IQueue queue)
        {
            _bookCommands = bookCommands;
            _queue = queue;
        }

        public async Task<bool> Handle(AddBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _bookCommands.AddBook(message.Book);

            _queue.Enqueue(message);

            return true;
        }

        public async Task<bool> Handle(UpdateBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _bookCommands.UpdateBook(message.Book);

            _queue.Enqueue(message);

            return true;
        }

        public async Task<bool> Handle(DeleteBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _bookCommands.DeleteBook(message.Book.Id);

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
