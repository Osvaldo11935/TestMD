using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Models.Requests
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? AvailableQuantity { get; set; }

        public UpdateProductRequest() {}

        public UpdateProductRequest(string name, string description, double? price, int? quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Description = description;

        }

    }
}
