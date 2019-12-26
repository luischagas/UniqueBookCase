using System;
using System.Collections.Generic;
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

        public BookQueries(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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
