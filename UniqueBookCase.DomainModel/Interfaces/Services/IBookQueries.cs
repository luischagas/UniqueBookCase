using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.Interfaces.Services
{
    public interface IBookQueries
    {
        Task<Book> GetBook(Guid id);
        Task<Book> GetBookAuthor(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<IEnumerable<Book>> GetBooksAuthor();
    }
}
