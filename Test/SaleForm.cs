using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Test.Models.Requests.Validate;
using Test.Reports;
using Test.Utils;
using Teste.Models.Entities;
using Teste.Models.Requests;
using Teste.UseCases;

namespace Test
{
    public partial class SaleForm : Form
    {
        private readonly SaleUseCase _saleUseCase;
        private readonly ProductUseCase _productUseCase;
        private readonly CustomerUseCase _customerUseCase;
        private readonly IServiceProvider _serviceProvider;

        public SaleForm(ProductUseCase productUseCase, CustomerUseCase customerUseCase, SaleUseCase saleUseCase, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _productUseCase = productUseCase;
            _customerUseCase = customerUseCase;
            _saleUseCase = saleUseCase;
            txt_customer_phone_number.KeyPress += txt_customer_phone_number_KeyPress;
            txt_customer_phone_number.TextChanged += txt_customer_phone_number_TextChanged;
            txt_search_product_sale.TextChanged += txt_search_product_sale_TextChanged;
            _serviceProvider = serviceProvider;

            dgv_cart.CellValueChanged += dgv_cart_CellValueChanged;
            dgv_cart.RowsAdded += dgv_cart_RowsAdded;
            dgv_cart.RowsRemoved += dgv_cart_RowsRemoved;
            dgv_cart.CellEndEdit += dgv_cart_CellEndEdit;

        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            LoadProductDataGrid();
            DataGridViewUtil.AddActionAddButtons(dgv_list_product_sale);
        }

        private void dgv_list_product_sale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CartUtil.HandleAddProductClick(e, dgv_list_product_sale, dgv_cart, _productUseCase);
        }

        private async void btn_finish_sale_Click(object sender, EventArgs e)
        {
            var resultValidator = CreateCustomerRequestValidator.ValidateCustomerInfo(txt_customer_name.Text, txt_customer_email.Text, txt_customer_phone_number.Text, txt_customer_address.Text);

            if (!string.IsNullOrEmpty(resultValidator))
            {
                MessageBox.Show(resultValidator);
                return;
            }
             
            var requestCreateUser = new CreateCustomerRequest(
                txt_customer_name.Text,
                txt_customer_email.Text,
                txt_customer_phone_number.Text,
                txt_customer_address.Text);

            var resultCreateUser = _customerUseCase.InsertCustomer(requestCreateUser);

            if (resultCreateUser.IsSuccess)
            {
                var ok = resultCreateUser.Ok;

                var itemsRequests = CartUtil.PrepareSaleItems(dgv_cart);
                var resultCreateSale =  await _saleUseCase.InsertSaleAsync(ok.Value, itemsRequests);
               
                if (resultCreateSale.IsSuccess)
                {
                    dgv_cart.DataSource = null; 
                    ClearForm();
                    LoadProductDataGrid();
                    MessageBox.Show("Venda registrada com sucesso");
                }
                else
                {
                    MessageBox.Show("Venda não registrada");
                }
               
            }
            else
            {
                var err = resultCreateUser.Error;

                if (!string.IsNullOrEmpty(err.Extension))
                {
                    var customerId = Guid.Parse(err.Extension); 
                    var itemsRequests = CartUtil.PrepareSaleItems(dgv_cart);
                    var resultCreateSale = await _saleUseCase.InsertSaleAsync(customerId, itemsRequests);

                    if (resultCreateSale.IsSuccess)
                    {
                        dgv_cart.DataSource = null;
                        ClearForm();
                        LoadProductDataGrid();
                        MessageBox.Show("Venda registrada com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Venda não registrada");
                    }

                }
            }
        }

        private void txt_customer_phone_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_customer_phone_number_TextChanged(object sender, EventArgs e)
        {
            string rawText = new string(txt_customer_phone_number.Text.Where(char.IsDigit).ToArray());

            if (rawText.Length > 0)
            {
                if (rawText.Length <= 2)
                    txt_customer_phone_number.Text = $"({rawText}";
                else if (rawText.Length <= 7)
                    txt_customer_phone_number.Text = $"({rawText.Substring(0, 2)}) {rawText.Substring(2)}";
                else if (rawText.Length <= 11)
                    txt_customer_phone_number.Text = $"({rawText.Substring(0, 2)}) {rawText.Substring(2, 5)}-{rawText.Substring(7)}";
                else
                    txt_customer_phone_number.Text = $"({rawText.Substring(0, 2)}) {rawText.Substring(2, 5)}-{rawText.Substring(7, 4)}";

                txt_customer_phone_number.SelectionStart = txt_customer_phone_number.Text.Length;
            }
        }

        private void dgv_cart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgv_cart.Rows[e.RowIndex];
            Guid productId = Guid.Parse(row.Cells["Id"].Value.ToString());

            if (dgv_cart.Columns[e.ColumnIndex].Name == "AddColumn")
            {
              
                int currentQuantity = Convert.ToInt32(row.Cells["Quantidade pretendida"].Value);
                int availableQuantity = Convert.ToInt32(dgv_list_product_sale.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => Guid.Parse(r.Cells["Id"].Value.ToString()) == productId)
                    ?.Cells["Quantidade"].Value);

                
                if (currentQuantity + 1 > availableQuantity)
                {
                    MessageBox.Show("A quantidade total no carrinho não pode exceder a quantidade disponível do produto.",
                        "Quantidade Excedida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                row.Cells["Quantidade pretendida"].Value = currentQuantity + 1;
            }
            else if (dgv_cart.Columns[e.ColumnIndex].Name == "RemoveColumn")
            {
                
                int currentQuantity = Convert.ToInt32(row.Cells["Quantidade pretendida"].Value);

                if (currentQuantity > 1)
                {
                    row.Cells["Quantidade pretendida"].Value = currentQuantity - 1;
                    row.Cells["Quantidade pretendida"].Value = currentQuantity - 1;
                }
                else
                {
                    dgv_cart.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        #region Aux
        private void ClearForm()
        {
            txt_customer_address.Clear();
            txt_customer_email.Clear();
            txt_customer_name.Clear();
            txt_customer_phone_number.Clear();
        }
        private void LoadProductDataGrid(string search = default)
        {
            try
            {
                var resultFindProduct = _productUseCase.FindAllProductsAvailableForSale(search);
                if (resultFindProduct.IsFailure)
                {
                    var err = resultFindProduct.Error;

                    MessageBox.Show(err.Description, err.Message);
                }
                else
                {
                    var products = resultFindProduct.Ok;
                    DataTable table = ProductUtil.CreateProductDataTable(products);
                    dgv_list_product_sale.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }
        #endregion

        private void dgv_cart_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            var row = dgv_cart.Rows[e.RowIndex];
            Guid productId = Guid.Parse(row.Cells["Id"].Value.ToString());

            if (dgv_cart.Columns[e.ColumnIndex].Name == "AddColumn")
            {

                int currentQuantity = Convert.ToInt32(row.Cells["Quantidade pretendida"].Value);
                double currentProductPrice = Convert.ToDouble(row.Cells["Preço do produto"].Value);
                double currentUnitPrice = Convert.ToDouble(row.Cells["Preço Unitario"].Value);
                int availableQuantity = Convert.ToInt32(dgv_list_product_sale.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => Guid.Parse(r.Cells["Id"].Value.ToString()) == productId)
                    ?.Cells["Quantidade"].Value);


                if (currentQuantity + 1 > availableQuantity)
                {
                    MessageBox.Show("A quantidade total no carrinho não pode exceder a quantidade disponível do produto.",
                        "Quantidade Excedida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                row.Cells["Quantidade pretendida"].Value = currentQuantity + 1;
                row.Cells["Preço Unitario"].Value = currentUnitPrice + currentProductPrice;
            }
            else if (dgv_cart.Columns[e.ColumnIndex].Name == "RemoveColumn")
            {

                int currentQuantity = Convert.ToInt32(row.Cells["Quantidade pretendida"].Value);
                double currentProductPrice = Convert.ToDouble(row.Cells["Preço do produto"].Value);
                double currentUnitPrice = Convert.ToDouble(row.Cells["Preço Unitario"].Value);
                if (currentQuantity > 1)
                {
                    row.Cells["Quantidade pretendida"].Value = currentQuantity - 1;
                    row.Cells["Preço Unitario"].Value = currentUnitPrice - currentProductPrice;
                }
                else
                {
                    dgv_cart.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void txt_search_product_sale_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_search_product_sale.Text))
            {
                LoadProductDataGrid(txt_search_product_sale.Text);
            }
        }

        private void registrarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is SoldForm)
                {
                    form.Show();
                    form.Focus();
                    return;
                }
            }
            var nextForm = _serviceProvider.GetRequiredService<SoldForm>();
            nextForm.FormClosed += (s, args) => nextForm.Hide();
            nextForm.Show();
            this.Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Hide();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is ProductForm)
                {
                    form.Show();
                    form.Focus();
                    return;
                }
            }
            var nextForm = _serviceProvider.GetRequiredService<ProductForm>();
            nextForm.FormClosed += (s, args) => nextForm.Hide();
            nextForm.Show();
            this.Hide();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void txt_customer_name_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_customer_name.Text)) {
              var customer =  _customerUseCase.FindCustomerByName(txt_customer_name.Text);
               
                if (customer.IsSuccess) {
                    var ok = customer.Ok;
                    txt_customer_email.Text = ok.Email;
                    txt_customer_phone_number.Text = ok.PhoneNumber;
                    txt_customer_address.Text = ok.Address;
                }
                else
                {
                    txt_customer_email.Clear();
                    txt_customer_phone_number.Clear(); ;
                    txt_customer_address.Clear(); ;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void dgv_cart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotal();
        }

        private void dgv_cart_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotal();
        }

        private void dgv_cart_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateTotal();
        }
        private void dgv_cart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            dgv_cart.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void UpdateTotal()
        {
            decimal total = DataGridViewUtil.SumColumnValues(dgv_cart, "Preço Unitario");
            lb_total_s.Text = $"R$ {total}" ; 
        }
    }
}
