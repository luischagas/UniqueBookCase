using System.Threading.Tasks;

namespace UniqueBookCase.DomainModel.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
