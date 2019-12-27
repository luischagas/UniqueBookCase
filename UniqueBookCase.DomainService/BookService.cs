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
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _cache;
        private const string KEY_ALL_AUTHORS = "ALL_AUTHORS";

        public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork, IDistributedCache cache)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task AddBook(Book book)
        {
            await _bookRepository.Create(book);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateBook(Book book)
        {
            await _bookRepository.Update(book);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteBook(Guid id)
        {
            await _bookRepository.Delete(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.ReadAll();
        }

        public async Task<IEnumerable<Book>> GetBooksAuthor()
        {
            return await _bookRepository.GetBooksAuthor();
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await _bookRepository.Read(id);
        }

        public async Task<Book> GetBookAuthor(Guid id)
        {
            return await _bookRepository.GetBookAuthor(id);
        }

    }
}
