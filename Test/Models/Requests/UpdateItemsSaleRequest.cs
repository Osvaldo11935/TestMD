using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Models.Requests
{
    public class UpdateItemsSaleRequest
    {
        public Guid? SaleId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }

        #region Construtores
        public UpdateItemsSaleRequest() { }

        public UpdateItemsSaleRequest(Guid? saleId, Guid? productId, int? quantity)
        {
            SaleId = saleId;
            ProductId = productId;
            Quantity = quantity;
        }

        #endregion
    }
}
