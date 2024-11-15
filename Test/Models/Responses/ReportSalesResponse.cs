using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models.Entities;

namespace Test.Models.Responses
{
    public class ReportSalesResponse
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public DateTime SoldIn { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }

        public ReportSalesResponse(ItemsSale itemsSale)
        {
            if (itemsSale == null) return;

            if (itemsSale.Product != null)
            {
                ProductName = itemsSale.Product.Name;
            }
            if (itemsSale.Sale != null)
            {
                if (itemsSale.Sale.Customer != null)
                {
                    CustomerName = itemsSale.Sale.Customer.Name;
                    CustomerPhoneNumber = itemsSale.Sale.Customer.PhoneNumber;
                }
            }
            UnitPrice = itemsSale.UnitPrice;
            Quantity = itemsSale.Quantity;
            SoldIn = itemsSale.CreatedAt.Value;
        }

    }
}
