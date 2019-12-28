using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniqueBookCase.DomainModel.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Create(TEntity entity);
        Task<TEntity> Read(Guid id);
        Task<IEnumerable<TEntity>> ReadAll();
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
