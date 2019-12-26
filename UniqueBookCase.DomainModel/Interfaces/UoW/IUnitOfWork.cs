using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UniqueBookCase.DomainModel.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
