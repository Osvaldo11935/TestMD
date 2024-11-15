using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models.Entities;

namespace Test.Models.Responses
{
    public class SalesResponse
    {
        public Guid Id { get; set; }
        public CustomerResponse Customer { get; set; }

        public SalesResponse(Sale sale)
        {
            Id = sale.Id.Value;
            if (sale.Customer != null)
            {
                Customer = new CustomerResponse(sale.Customer);
            }
        }
    }
}
