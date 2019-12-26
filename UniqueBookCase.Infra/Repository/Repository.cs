using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.Infra.Context;

namespace UniqueBookCase.Infra.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly UniqueBookCaseContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(UniqueBookCaseContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> Read(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> ReadAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual async Task Delete(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
