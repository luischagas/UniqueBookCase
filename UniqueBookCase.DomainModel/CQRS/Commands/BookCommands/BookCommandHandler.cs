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

        private readonly IBookCommands _bookService;

        public BookCommandHandler(IBookCommands bookService)
        {
            _bookService = bookService;
        }

        public async Task<bool> Handle(AddBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _bookService.AddBook(message.Book);

            return true;
        }

        public async Task<bool> Handle(UpdateBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _bookService.UpdateBook(message.Book);

            return true;
        }

        public async Task<bool> Handle(DeleteBookCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            await _bookService.DeleteBook(message.Book.Id);

            return true;
        }

        private bool ValidateCommand(Command message)
        {
            if (message.isValid()) return true;

            return false;
        }
    }
}
