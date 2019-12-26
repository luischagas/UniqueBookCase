using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.DomainModel.Interfaces.Services;
using UniqueBookCase.DomainModel.Interfaces.UoW;

namespace UniqueBookCase.DomainService
{
    public class AuthorCommands : IAuthorCommands
    {
        private IAuthorRepository _authorRepository;
        private IUnitOfWork _unitOfWork;

        public AuthorCommands(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAuthor(Author author)
        {
            await _authorRepository.Create(author);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateAuthor(Author author)
        {
            await _authorRepository.Update(author);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAuthor(Guid id)
        {
            await _authorRepository.Delete(id);
            await _unitOfWork.CommitAsync();
        }

    }
}
