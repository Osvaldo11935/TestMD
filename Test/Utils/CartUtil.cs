using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste.Models.Requests;
using Teste.UseCases;

namespace Test.Utils
{
    public static class CartUtil
    {
        public static void HandleAddProductClick(DataGridViewCellEventArgs e, DataGridView sourceGrid, DataGridView cartGrid, ProductUseCase productUseCase)
        {
            if (e.RowIndex < 0 || sourceGrid.Columns[e.ColumnIndex].Name != "AddColumn")
                return;

            var selectedRow = sourceGrid.Rows[e.RowIndex];
            Guid productId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());
            int quantityAvailable = int.Parse(selectedRow.Cells["Quantidade"].Value.ToString());
            double productPrice = double.Parse(selectedRow.Cells["Preço"].Value.ToString());
            int quantityToAdd = 1;

            foreach (DataGridViewRow cartRow in cartGrid.Rows)
            {
                if (Guid.Parse(cartRow.Cells["Id"].Value.ToString()) == productId)
                {
                    int currentQuantity = int.Parse(cartRow.Cells["Quantidade pretendida"].Value.ToString());
                    double currentUnitPrice= double.Parse(cartRow.Cells["Preço Unitario"].Value.ToString());
                    if (currentQuantity + quantityToAdd > quantityAvailable)
                    {
                        MessageBox.Show("Quantidade no carrinho excede a disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var newQuantity = currentQuantity + quantityToAdd;
                    cartRow.Cells["Quantidade pretendida"].Value = newQuantity;
                    cartRow.Cells["Preço Unitario"].Value = currentUnitPrice + productPrice;

                    return;
                }
            }

            var cartTable = cartGrid.DataSource as DataTable;
            if (cartTable == null)
            {
                cartTable = CreateCartProductDataTable(selectedRow, quantityToAdd);
                cartGrid.DataSource = cartTable;
                DataGridViewUtil.AddActionButtons(cartGrid);
            }
            else
            {
                cartTable.Rows.Add(
                    productId,
                    selectedRow.Cells["Nome"].Value.ToString(),
                    selectedRow.Cells["Descrição"].Value.ToString(),
                    decimal.Parse(selectedRow.Cells["Preço"].Value.ToString()),
                    0);
            }
        }

        private static DataTable CreateCartProductDataTable(DataGridViewRow row, int quantity)
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(Guid));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Descrição", typeof(string));
            table.Columns.Add("Preço do produto", typeof(decimal));
            table.Columns.Add("Preço Unitario", typeof(decimal));
            table.Columns.Add("Quantidade pretendida", typeof(int));

            table.Rows.Add(
                row.Cells["Id"].Value.ToString(),
                row.Cells["Nome"].Value.ToString(),
                row.Cells["Descrição"].Value.ToString(),
                double.Parse(row.Cells["Preço"].Value.ToString()),
                0,
                0);

            return table;
        }
        public static void AddButtonColumnsToDataGridViewCart(DataGridView gridView)
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

            if (gridView.Columns["RemoveColumn"] == null)
            {
                var removeButton = new DataGridViewButtonColumn
                {
                    Name = "RemoveColumn",
                    HeaderText = "Remover",
                    Text = "Remover",
                    UseColumnTextForButtonValue = true
                };
                gridView.Columns.Add(removeButton);
            }
        }
        public static List<CreateItemsSaleRequest> PrepareSaleItems(DataGridView cartGrid)
        {
            var items = new List<CreateItemsSaleRequest>();

            foreach (DataGridViewRow row in cartGrid.Rows)
            {
                if (row?.Cells["Id"]?.Value != null)
                {
                    items.Add(new CreateItemsSaleRequest(
                        Guid.Parse(row.Cells["Id"].Value.ToString()),
                        int.Parse(row.Cells["Quantidade pretendida"].Value.ToString()),
                        double.Parse(row.Cells["Preço Unitario"].Value.ToString())
                    ));
                }
            }
            return items;
        }
    }
}
