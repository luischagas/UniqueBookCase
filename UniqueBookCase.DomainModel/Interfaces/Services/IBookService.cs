using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.Interfaces.Services
{
    public interface IBookService
    {
        Task<Book> GetBook(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Guid id);
    }
}
