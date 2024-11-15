using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Teste.Interfaces.IRepositories.ICommon
{
    public interface IUnitOfWork
    {
        #region SavaChenge
        int SaveChange();
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
        #endregion

        #region Repositories
        IBaseRepository<T> AsyncRepository<T>()
            where T : class;
        #endregion
    }
}
