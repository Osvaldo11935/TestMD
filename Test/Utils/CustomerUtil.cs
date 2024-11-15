using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste.Models.Entities;

namespace Test.Utils
{
    public static class CustomerUtil
    {
        public static void AddButtonColumnsToDataGridView(DataGridView gridView)
        {
            if (gridView.Columns["AddColumn"] == null)
            {
                var addButton = new DataGridViewButtonColumn
                {
                    Name = "AddColumn",
                    HeaderText = "Adicionar",
                    Text = "Adicionar",
                    UseColumnTextForButtonValue = true
                };
                gridView.Columns.Add(addButton);
            }
        }

        public static DataTable CreateProductDataTable(List<Product> products)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(Guid));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Descrição", typeof(string));
            table.Columns.Add("Preço", typeof(decimal));
            table.Columns.Add("Quantidade", typeof(int));

            foreach (var product in products)
            {
                table.Rows.Add(product.Id, product.Name, product.Description, product.Price, product.Quantity);
            }

            return table;
        }
    }
}
