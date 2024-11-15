using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Interfaces.IRepositories.ICommon;
using Teste.Models.Entities;

namespace Teste.Interfaces.IRepositories
{
    public interface IProductRepository: IBaseRepository<Product>
    {
    }
}
