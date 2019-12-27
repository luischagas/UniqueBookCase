using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.Interfaces.Services
{
    public interface IBookService
    {
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Guid id);
        Task<Book> GetBook(Guid id);
        Task<Book> GetBookAuthor(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<IEnumerable<Book>> GetBooksAuthor();
    }
}
