using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.Interfaces.Services
{
   public interface IAuthorQueries
    {
        Task<Author> GetAuthor(Guid id);
        Task<Author> GetAuthorBook(Guid id);
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<IEnumerable<Author>> GetAuthorBooks();
    }
}
