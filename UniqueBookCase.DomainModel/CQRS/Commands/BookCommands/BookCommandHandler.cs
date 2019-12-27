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

        private readonly IBookService _bookCommands;
        private readonly IQueue _queue;

        public BookCommandHandler(IBookService bookCommands, IQueue queue)
        {
            _bookCommands = bookCommands;
            _queue = queue;
        }

        public async Task<bool> Handle(AddBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            //Repository
            await _bookCommands.AddBook(message.Book);

            //Queue
            _queue.Enqueue(message);

            return true;
        }

        public async Task<bool> Handle(UpdateBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            //Repository
            await _bookCommands.UpdateBook(message.Book);

            //Queue
            _queue.Enqueue(message);

            return true;
        }

        public async Task<bool> Handle(DeleteBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            //Repository
            await _bookCommands.DeleteBook(message.Book.Id);

            //Queue
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
