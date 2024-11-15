using System;
using Teste.Models.Entities.Common;
using Teste.Models.Requests;


namespace Teste.Models.Entities
{
    public class ItemsSale : BaseAuditableEntity
    {
        public Guid? SaleId { get; set; }
        public Guid? ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }

        #region Construtores
        public ItemsSale() { }

        public ItemsSale(CreateItemsSaleRequest request)
        {
            SaleId = request.SaleId;
            ProductId = request.ProductId;
            UnitPrice = request.UnitPrice;
            Quantity = request.Quantity;
        }
        #endregion

        #region Method
        public void Update()
        {

        }
        #endregion

    }
}
