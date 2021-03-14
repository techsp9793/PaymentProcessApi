using Microsoft.EntityFrameworkCore;
using PaymentProcessApi.Entity.DatabaseContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessApi.Entity.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly PaymentProcessContext _dbContext;

        public GenericRepository(PaymentProcessContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public abstract Task<TEntity> GetById(long id);

        public async Task<TEntity> Create(TEntity entity)
        {
            var value = await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return value.Entity;
        }
        public async Task Update(long id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(long id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
