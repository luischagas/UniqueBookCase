using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniqueBookCase.DomainModel.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task Create(TEntity entity);
        Task<TEntity> Read(Guid id);
        Task<IEnumerable<TEntity>> ReadAll();
        Task Update(TEntity entity);
        Task Delete(Guid id);
    }
}
