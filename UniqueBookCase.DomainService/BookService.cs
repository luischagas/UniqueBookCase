using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.DomainService
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddBook(Book book)
        {
            await _bookRepository.Create(book);
        }
        public async Task UpdateBook(Book book)
        {
            await _bookRepository.Update(book);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.ReadAll();
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await _bookRepository.Read(id);
        }

        public async Task DeleteBook(Guid id)
        {
            await _bookRepository.Delete(id);
        }

    }
}
