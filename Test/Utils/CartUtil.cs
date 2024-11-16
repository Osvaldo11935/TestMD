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
            if (e.RowIndex < 0 || sourceGrid.Columns[e.ColumnIndex]?.Name != "AddColumn")
                return;

            var selectedRow = sourceGrid.Rows[e.RowIndex];

            if (!Guid.TryParse(selectedRow.Cells["Id"].Value?.ToString(), out Guid productId) ||
                !int.TryParse(selectedRow.Cells["Quantidade"].Value?.ToString(), out int quantityAvailable) ||
                !double.TryParse(selectedRow.Cells["Preço"].Value?.ToString(), out double productPrice))
            {
                MessageBox.Show("Erro ao processar os dados do produto selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int quantityToAdd = 1;

            foreach (DataGridViewRow cartRow in cartGrid.Rows)
            {
                if (cartRow.Cells["Id"]?.Value?.ToString() == null)
                    continue;

                if (Guid.TryParse(cartRow.Cells["Id"].Value.ToString(), out Guid cartProductId) && cartProductId == productId)
                {
                    if (!int.TryParse(cartRow.Cells["Quantidade pretendida"].Value?.ToString(), out int currentQuantity))
                        currentQuantity = 0;

                    if (currentQuantity + quantityToAdd > quantityAvailable)
                    {
                        MessageBox.Show("Quantidade no carrinho excede a disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cartRow.Cells["Quantidade pretendida"].Value = currentQuantity + quantityToAdd;
                    cartRow.Cells["Preço Unitario"].Value = (currentQuantity + quantityToAdd) * productPrice;

                    return;
                }
            }

            var cartTable = cartGrid.DataSource as DataTable;

            if (cartTable == null)
            {

                cartTable = CreateCartProductDataTable(selectedRow, quantityToAdd, productPrice);
                cartGrid.DataSource = cartTable;
                DataGridViewUtil.AddActionButtons(cartGrid);
            }
            else
            {
                cartTable.Rows.Add(
                    productId,
                    selectedRow.Cells["Nome"].Value?.ToString(),
                    selectedRow.Cells["Descrição"].Value?.ToString(),
                    productPrice,
                    productPrice * quantityToAdd,
                    quantityToAdd
                );
            }
        }

        private static DataTable CreateCartProductDataTable(DataGridViewRow row, int quantity, double productPrice)
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(Guid));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Descrição", typeof(string));
            table.Columns.Add("Preço do produto", typeof(decimal));
            table.Columns.Add("Preço Unitario", typeof(decimal));
            table.Columns.Add("Quantidade pretendida", typeof(int));

            if (Guid.TryParse(row.Cells["Id"].Value?.ToString(), out Guid productId))
            {
                table.Rows.Add(
                    productId,
                    row.Cells["Nome"].Value?.ToString(),
                    row.Cells["Descrição"].Value?.ToString(),
                    Convert.ToDecimal(productPrice),
                    Convert.ToDecimal(productPrice * quantity),
                    quantity
                );
            }
            else
            {
                MessageBox.Show("Erro ao criar tabela de produtos. Verifique os dados da linha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
