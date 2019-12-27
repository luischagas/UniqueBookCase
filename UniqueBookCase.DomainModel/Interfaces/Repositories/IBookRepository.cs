using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksAuthor();
        Task<IEnumerable<Book>> GetBooksAuthorFromCache(IEnumerable<Author> authors);
        Task<Book> GetBookAuthor(Guid id);
        Task<Book> GetBookAuthorFromCache(Guid id, IEnumerable<Author> authors);
    }
}
