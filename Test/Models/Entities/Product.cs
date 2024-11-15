using System;
using System.Collections.Generic;
using Teste.Models.Entities.Common;
using Teste.Models.Requests;

namespace Teste.Models.Entities
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public virtual IList<ItemsSale> ItemsSales { get; set; }

        #region Construtores
        public Product() { }
        public Product(CreateProductRequest request)
        {
            Name = request.Name;
            Price = request.Price;
            Quantity = request.Quantity;
            Description = request.Description;
        }
        #endregion

        #region Method
        public void Update(UpdateProductRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                Name = request.Name;
            }
            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                Description = request.Description;
            }
            if (request.Price != null)
            {
                Price = request.Price.Value;
            }
            if (request.Quantity != null)
            {
                Quantity = request.Quantity.Value;
            }
        }
        #endregion
    }
}
