using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.Interfaces.Services
{
    public interface IBookCommands
    {
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Guid id);
    }
}
