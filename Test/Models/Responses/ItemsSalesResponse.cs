using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models.Entities;

namespace Test.Models.Responses
{
    public class ItemsSalesResponse
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public SalesResponse Sale { get; set; }
        public ProductResponse Product { get; set; }

        public ItemsSalesResponse(ItemsSale itemsSale)
        {
            Quantity = itemsSale.Quantity;
            UnitPrice = itemsSale.UnitPrice;
            if (itemsSale.Sale != null) {
                Sale = new SalesResponse(itemsSale.Sale);
            }
            if (itemsSale.Product != null) {
                Product = new ProductResponse(itemsSale.Product);
            }

        }
    }
}
