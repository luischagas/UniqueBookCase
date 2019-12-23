using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<Author> GetAuthor(Guid id);
        Task<Author> GetAuthorBook(Guid id);
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<IEnumerable<Author>> GetAuthorBooks();
        Task AddAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(Guid id);
    }
}
