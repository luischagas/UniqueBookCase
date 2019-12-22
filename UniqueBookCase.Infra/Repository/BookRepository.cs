using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.Infra.Context;

namespace UniqueBookCase.Infra.Repository
{
   public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(UniqueBookCaseContext context) : base(context) { }
    }
}
