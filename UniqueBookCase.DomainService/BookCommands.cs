using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.DomainModel.Interfaces.Services;
using UniqueBookCase.DomainModel.Interfaces.UoW;

namespace UniqueBookCase.DomainService
{
    public class BookCommands : IBookCommands
    {
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;

        public BookCommands(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
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

    }
}
