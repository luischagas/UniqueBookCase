using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.Infra.Context;

namespace UniqueBookCase.Infra.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(UniqueBookCaseContext context) : base(context) { }
    }
}
