using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.DomainModel.Interfaces.Services;
using UniqueBookCase.DomainModel.Interfaces.UoW;

namespace UniqueBookCase.DomainService
{
    public class BookQueries : IBookQueries
    {
        private IBookRepository _bookRepository;
        private readonly IDistributedCache _cache;
        private const string KEY_ALL_AUTHORS = "ALL_AUTHORS";

        public BookQueries(IBookRepository bookRepository, IDistributedCache cache)
        {
            _bookRepository = bookRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.ReadAll();
        }

        public async Task<IEnumerable<Book>> GetBooksAuthor()
        {
            var dataCache = await _cache.GetStringAsync(KEY_ALL_AUTHORS);

            if (string.IsNullOrWhiteSpace(dataCache))
            {
                return await _bookRepository.GetBooksAuthor();

            }

            var authorsFromCache = JsonConvert.DeserializeObject<IEnumerable<Author>>(dataCache);

            return await _bookRepository.GetBooksAuthorFromCache(authorsFromCache);
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await _bookRepository.Read(id);
        }

        public async Task<Book> GetBookAuthor(Guid id)
        {
            var dataCache = await _cache.GetStringAsync(KEY_ALL_AUTHORS);

            if (string.IsNullOrWhiteSpace(dataCache))
            {
                return await _bookRepository.GetBookAuthor(id);

            }

            var authorsFromCache = JsonConvert.DeserializeObject<IEnumerable<Author>>(dataCache);

            return await _bookRepository.GetBookAuthorFromCache(id, authorsFromCache);
        }

    }
}
