using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.DomainService
{
    public class AuthorQueries : IAuthorQueries
    {
        private IAuthorRepository _authorRepository;

        public AuthorQueries(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _authorRepository.ReadAll();
        }

        public async Task<IEnumerable<Author>> GetAuthorBooks()
        {
            return await _authorRepository.GetAuthorBooks();
        }

        public async Task<Author> GetAuthor(Guid id)
        {
            return await _authorRepository.Read(id);
        }

        public async Task<Author> GetAuthorBook(Guid id)
        {
            return await _authorRepository.GetAuthorBook(id);
        }

    }
}
