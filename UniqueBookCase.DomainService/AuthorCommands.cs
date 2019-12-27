using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
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
        private readonly IDistributedCache _cache;
        private const string KEY_ALL_EMPLOYEES = "ALL_AUTHORS";

        public AuthorCommands(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IDistributedCache cache)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task AddAuthor(Author author)
        {
            await _authorRepository.Create(author);
            await _unitOfWork.CommitAsync();

            await UpdateCacheAuthor();

        }
        public async Task UpdateAuthor(Author author)
        {
            await _authorRepository.Update(author);
            await _unitOfWork.CommitAsync();

            await UpdateCacheAuthor();
        }

        public async Task DeleteAuthor(Guid id)
        {
            await _authorRepository.Delete(id);
            await _unitOfWork.CommitAsync();

            await UpdateCacheAuthor();
        }

        private async Task UpdateCacheAuthor()
        {
            var cacheSettings = new DistributedCacheEntryOptions();
            cacheSettings.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            var authorsFromDatabase = await _authorRepository.ReadAll();

            var itemsJson = JsonConvert.SerializeObject(authorsFromDatabase);

            await _cache.SetStringAsync(KEY_ALL_EMPLOYEES, itemsJson, cacheSettings);
        }

    }
}
