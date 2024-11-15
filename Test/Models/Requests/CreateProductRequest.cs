

using System.Windows.Forms;

namespace Teste.Models.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public CreateProductRequest() { }
        public CreateProductRequest(string name, string description, double price, int quantity) {

            if (string.IsNullOrEmpty(name))
                MessageBox.Show("Nome do produto obrigatório");

            if (string.IsNullOrEmpty(description))
                MessageBox.Show("Descrição do produto obrigatório");

            if (price <= 0)
                MessageBox.Show("Preço do produto deve ser maior que 0.0");

            if (quantity <= 0)
                MessageBox.Show("Quantidade do produto deve ser maior que 0");

            Name = name;
            Price = price;  
            Quantity = quantity;
            Description = description;
        }
    }
}
