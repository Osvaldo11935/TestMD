using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teste.Data.Context;
using Teste.Interfaces.IRepositories.ICommon;

namespace Teste.Data.Repositories.Common
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
    {
        #region Properties and builders

        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        #endregion

        #region Read
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
            => await _dbSet.AnyAsync(predicate);

        public IQueryable<TEntity> Query()
         => _dbSet;

        public IQueryable<TEntity> Query(int pageNumber, int pageSize)
        {
            int nextPgNumber = (pageNumber - 1) * pageSize;

            return _dbSet
                .Skip(nextPgNumber).Take(pageSize)
                .AsNoTracking();
        }

        #endregion

        #region Write

        public async Task InsertAsync(TEntity request)
            => await _dbSet.AddAsync(request);

        public async Task InsertAsync(List<TEntity> request)
            => await _dbSet.AddRangeAsync(request);
        public void Insert(TEntity request)
           => _dbSet.Add(request);

        public void Insert(List<TEntity> request)
           => _dbSet.AddRange(request);

        public void Update(TEntity request)
            => _dbSet.Update(request);

        public void Remove(TEntity request) =>
            _dbSet.Remove(request);

        #endregion
    }
}
