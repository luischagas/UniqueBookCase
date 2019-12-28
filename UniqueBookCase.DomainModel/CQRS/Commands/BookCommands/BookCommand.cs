using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.CQRS.Commands.BookCommands
{
    public abstract class BookCommand : Command
    {
        public Book Book { get; set; }

        public BookCommand(Book book)
        {
            Book = book;
        }
    }
}
