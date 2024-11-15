using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Data.Context;
using Teste.Interfaces.IRepositories;
using Teste.Models.Entities;
using Teste.Data.Repositories.Common;

namespace Teste.Data.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
