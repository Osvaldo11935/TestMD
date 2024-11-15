using System;


namespace Teste.Models.Requests
{
    public class CreateItemsSaleRequest
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        #region Construtores
        public CreateItemsSaleRequest() { }

        public CreateItemsSaleRequest(Guid productId, int quantity, double unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        #endregion
    }
}
