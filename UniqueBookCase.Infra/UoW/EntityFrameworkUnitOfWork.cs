using System.Threading.Tasks;
using UniqueBookCase.DomainModel.Interfaces.UoW;
using UniqueBookCase.Infra.Context;

namespace UniqueBookCase.Infra.UoW
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly UniqueBookCaseContext _context;

        public EntityFrameworkUnitOfWork(UniqueBookCaseContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

      
    }
}
