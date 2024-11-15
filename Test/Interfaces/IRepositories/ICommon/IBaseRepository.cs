using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Interfaces.IRepositories.ICommon
{
    public interface IBaseRepository<TEntity>
    {
        #region Read
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(int pageNumber, int pageSize);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);
        #endregion

        #region Write
        void Insert(TEntity request);
        void Insert(List<TEntity> request);
        Task InsertAsync(TEntity request);
        Task InsertAsync(List<TEntity> request);
        void Update(TEntity request);
        void Remove(TEntity request);

        #endregion
    }
}
