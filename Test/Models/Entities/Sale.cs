using System;
using System.Collections.Generic;
using Teste.Models.Entities.Common;


namespace Teste.Models.Entities
{
    public class Sale : BaseAuditableEntity
    {
        public Guid? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual IList<ItemsSale> ItemsSales { get; set; }

        #region Constructores
        public Sale() { }
        public Sale(Guid customerId)
        {
            CustomerId = customerId;
        }
        #endregion

        #region Method
        public void AddItemsSale(List<ItemsSale> items)
        {
            ItemsSales = items;
        }
        #endregion
    }
}
