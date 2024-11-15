using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Reports;
using Test.Utils;
using Teste.Models.Entities;
using Teste.Models.Requests;
using Teste.UseCases;

namespace Test
{
    public partial class ProductForm : Form
    {
        private Guid _productId;
        private readonly IServiceProvider _serviceProvider;
        private readonly ProductUseCase _productUseCase;
        public ProductForm(ProductUseCase productUseCase, IServiceProvider serviceProvider)
        {
            _productUseCase = productUseCase;
            InitializeComponent();
            txt_product_search.TextChanged += textBox1_TextChanged;
            _serviceProvider = serviceProvider;
        }

        private async void btn_product_save_Click(object sender, EventArgs e)
        {
            if (!TryGetCreateProductRequest(out CreateProductRequest request))
            {
                MessageBox.Show("Por favor, insira todos os campos corretamente.");
                return;
            }

            var resultCreateProduct = await _productUseCase.InsertProductAsync(request);

            if (resultCreateProduct.IsSuccess)
            {
                MessageBox.Show("Dados do produto salvos com sucesso.");
                LoadProductDataGrid();
                ClearForm();
            }
            else
            {
                var err = resultCreateProduct.Error;
                MessageBox.Show(err.Description, err.Message);
            }
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            btn_product_update.Visible = false;
            dgv_list_product.CellClick += dgv_list_product_CellContentClick;
            LoadProductDataGrid();
            DataGridViewUtil.AddEditAndDeleteButtons(dgv_list_product);
        }
        private async void dgv_list_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgv_list_product.Columns[e.ColumnIndex].Name == "EditColumn")
            {

                DataGridViewRow row = dgv_list_product.Rows[e.RowIndex];
                _productId = Guid.Parse(row.Cells["Id"].Value.ToString());
                txt_product_name.Text = row.Cells["Nome"].Value.ToString();
                txt_product_description.Text = row.Cells["Descrição"].Value.ToString();
                txt_product_price.Text = row.Cells["Preço"].Value.ToString();
                txt_product_quantity.Text = row.Cells["Quantidade"].Value.ToString();
                btn_product_save.Visible = false;
                btn_product_update.Visible = true;
            }
            else if (dgv_list_product.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                Guid productId = Guid.Parse(dgv_list_product.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                var confirmResult = MessageBox.Show("Tem certeza que deseja deletar este produto?", "Confirmar Deleção",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {

                    var resultDelete = await _productUseCase.DeleteProductAsync(productId);
                    if (resultDelete.IsSuccess)
                    {
                        MessageBox.Show("Produto deletado com sucesso.");
                        LoadProductDataGrid();
                    }
                    else
                    {
                        var err = resultDelete.Error;
                        MessageBox.Show(err.Description, err.Message);
                    }
                }
            }
        }

        private async void btn_product_update_Click(object sender, EventArgs e)
        {
            if (!TryGetUpdateProductRequest(out UpdateProductRequest request))
            {
                MessageBox.Show("Por favor, insira todos os campos corretamente.");
                return;
            }

            var resultUpdateProduct = await _productUseCase.UpdateProductAsync(_productId, request);

            if (resultUpdateProduct.IsSuccess)
            {
                MessageBox.Show("Dados do produto alterado com sucesso.");
                LoadProductDataGrid();
                ClearForm();
                btn_product_save.Visible = true;
            }
            else
            {
                var err =  resultUpdateProduct.Error;

                MessageBox.Show(err.Description, err.Message);
            }
        }

        #region Aux
        private bool TryGetCreateProductRequest(out CreateProductRequest request)
        {
            request = null;

            if (double.TryParse(txt_product_price.Text, out double price) &&
                int.TryParse(txt_product_quantity.Text, out int quantity))
            {
                request = new CreateProductRequest(
                    txt_product_name.Text,
                    txt_product_description.Text,
                    price,
                    quantity
                );
                return true;
            }
            return false;
        }
        private bool TryGetUpdateProductRequest(out UpdateProductRequest request)
        {
            request = null;

            if (double.TryParse(txt_product_price.Text, out double price) &&
                int.TryParse(txt_product_quantity.Text, out int quantity))
            {
                request = new UpdateProductRequest(
                    txt_product_name.Text,
                    txt_product_description.Text,
                    price,
                    quantity
                );
                return true;
            }
            return false;
        }
        private DataTable CreateProductDataTable(List<Product> products)
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
        private void LoadProductDataGrid(string search = default)
        {
            try
            {
                var resultFindProduct = _productUseCase.FindAllProduct(search);
                if (resultFindProduct.IsSuccess)
                {
                    var products = resultFindProduct.Ok;
                    DataTable table = CreateProductDataTable(products);
                    dgv_list_product.DataSource = table;
                }
                else
                {
                    var err = resultFindProduct.Error;
                    MessageBox.Show(err.Description, err.Message);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }
        private void ClearForm()
        {
            txt_product_name.Clear();
            txt_product_description.Clear();
            txt_product_price.Clear();
            txt_product_quantity.Clear();
            _productId = Guid.Empty;
        }

        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_product_search.Text))
            {
                LoadProductDataGrid(txt_product_search.Text);
            }
        }

        private void registrarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is SaleForm)
                {
                    form.Show();
                    form.Focus();
                    return;
                }
            }
            var nextForm = _serviceProvider.GetRequiredService<SaleForm>();
            nextForm.FormClosed += (s, args) => nextForm.Hide();
            nextForm.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is CustomerForm)
                {
                    form.Show();
                    form.Focus();
                    return;
                }
            }
            var nextForm = _serviceProvider.GetRequiredService<CustomerForm>();
            nextForm.FormClosed += (s, args) => nextForm.Hide();
            nextForm.Show();
            this.Hide();
        }

        private void produtosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is ReportProducts)
                {
                    form.Show();
                    form.Focus();
                    return;
                }
            }
            var nextForm = _serviceProvider.GetRequiredService<ReportProducts>();
            nextForm.FormClosed += (s, args) => nextForm.Hide();
            nextForm.Show();
            this.Hide();
        }

        private void vendasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is ReportSales)
                {
                    form.Show();
                    form.Focus();
                    return;
                }
            }
            var nextForm = _serviceProvider.GetRequiredService<ReportSales>();
            nextForm.FormClosed += (s, args) => nextForm.Hide();
            nextForm.Show();
            this.Hide();
        }

        private void clientesToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is ReportCustomers)
                {
                    form.Show();
                    form.Focus();
                    return;
                }
            }
            var nextForm = _serviceProvider.GetRequiredService<ReportCustomers>();
            nextForm.FormClosed += (s, args) => nextForm.Hide();
            nextForm.Show();
            this.Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Application.OpenForms[0].Show();
           this.Hide();
            
        }
    }
}