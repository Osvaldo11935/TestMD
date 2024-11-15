using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models.Entities;

namespace Test.Models.Responses
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public ProductResponse(Product product) {
            if (product == null) return;

            Id = product.Id.Value; 
            Name = product.Name; 
            Description = product.Description; 
            Price = product.Price; 
            Quantity = product.Quantity;
        }
    }
}
