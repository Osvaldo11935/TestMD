using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Teste.Data.Context;
using Teste.Interfaces.IRepositories.ICommon;

namespace Teste.Data.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties and builders
        private ApplicationDbContext Context { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }

        #endregion

        #region Repositories
        public IBaseRepository<T> AsyncRepository<T>()
            where T : class => new BaseRepository<T>(Context);

        #endregion

        #region SaveChange

        public int SaveChange()
        {
            return Context.ChangeTracker.HasChanges() ? Context.SaveChanges() : default;
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {

            if (Context.ChangeTracker.HasChanges())
            {
                return await Context.SaveChangesAsync(cancellationToken);
            }
            return default;
        }
        #endregion
    }
}
