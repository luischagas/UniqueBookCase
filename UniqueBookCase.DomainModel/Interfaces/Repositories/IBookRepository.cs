using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksAuthor();
        Task<Book> GetBookAuthor(Guid id);
    }
}
