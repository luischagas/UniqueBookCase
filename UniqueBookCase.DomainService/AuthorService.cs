using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.DomainModel.Interfaces.Services;
using UniqueBookCase.DomainModel.Interfaces.UoW;

namespace UniqueBookCase.DomainService
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        private IUnitOfWork _unitOfWork;


        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAuthor(Author author)
        {
            _authorRepository.Create(author);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAuthor(Guid id)
        {
            _authorRepository.Delete(id);
            await _unitOfWork.CommitAsync();
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
