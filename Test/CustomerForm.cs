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
using Test.Models.Requests.Validate;
using Test.Models.Requests.Validates;
using Test.Reports;
using Test.Utils;
using Teste.Models.Entities;
using Teste.Models.Requests;
using Teste.UseCases;

namespace Test
{
    public partial class CustomerForm : Form
    {
        private Guid _customerId;
        private CustomerUseCase _customerUseCase;
        private readonly IServiceProvider _serviceProvider;
        public CustomerForm(CustomerUseCase customerUseCase, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            txt_customer_phone_number.KeyPress += txt_customer_phone_number_KeyPress;
            txt_customer_phone_number.TextChanged += txt_customer_phone_number_TextChanged;
            _customerUseCase = customerUseCase;
            txt_customer_search.TextChanged += txt_customer_search_TextChanged;
            _serviceProvider = serviceProvider;
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
        private void ClearForm()
        {
            txt_customer_address.Clear();
            txt_customer_email.Clear();
            txt_customer_name.Clear();
            txt_customer_phone_number.Clear();
        }

        private void btn_customer_update_Click(object sender, EventArgs e)
        {
            var resultValidator = UpdateCustomerRequestValidator.ValidateCustomerInfo(txt_customer_name.Text, txt_customer_email.Text, txt_customer_phone_number.Text, txt_customer_address.Text);

            if (!string.IsNullOrEmpty(resultValidator))
            {
                MessageBox.Show(resultValidator);
                return;
            }

            var requestUpdateUser = new UpdateCustomerRequest(
                txt_customer_name.Text,
                txt_customer_email.Text,
            txt_customer_phone_number.Text,
                txt_customer_address.Text);

            var resultUpdateUser = _customerUseCase.UpdateCustomer(_customerId, requestUpdateUser);

            if (resultUpdateUser.IsSuccess)
            {
                MessageBox.Show("Dados do cliente atualizado com sucesso.");
            }
            else
            {
                var err = resultUpdateUser.Error;
                MessageBox.Show(err.Description, err.Message);
            }
        }
        #region Aux
        private DataTable CreateCustomerDataTable(List<Customer> customers)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(Guid));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Nº de telefone", typeof(string));
            table.Columns.Add("Endereço", typeof(string));

            foreach (var customer in customers)
            {
                table.Rows.Add(customer.Id, customer.Name, customer.Email, customer.PhoneNumber, customer.Address);
            }

            return table;
        }
        private void LoadCustomerDataGrid(string search = default)
        {
            try
            {
                var resultFindCustomer = _customerUseCase.FindAllCustomer(search);
                if (resultFindCustomer.IsSuccess)
                {
                    var customers = resultFindCustomer.Ok;
                    DataTable table = CreateCustomerDataTable(customers);
                    dgv_list_customer.DataSource = table;
                }
                else
                {
                    var err = resultFindCustomer.Error;
                    MessageBox.Show(err.Description, err.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }
        #endregion

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            btn_customer_update.Visible = false;
            LoadCustomerDataGrid();
            DataGridViewUtil.AddEditAndDeleteButtons(dgv_list_customer);

        }
        private async void dgv_list_customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dgv_list_customer.Columns[e.ColumnIndex].Name == "EditColumn")
            {

                DataGridViewRow row = dgv_list_customer.Rows[e.RowIndex];
                _customerId = Guid.Parse(row.Cells["Id"].Value.ToString());
                txt_customer_name.Text = row.Cells["Nome"].Value.ToString();
                txt_customer_email.Text = row.Cells["Email"].Value.ToString();
                txt_customer_phone_number.Text = row.Cells["Nº de telefone"].Value.ToString();
                txt_customer_address.Text = row.Cells["Endereço"].Value.ToString();
                btn_customer_save.Visible = false;
                btn_customer_update.Visible = true;
            }
            else if (dgv_list_customer.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                Guid customerId = Guid.Parse(dgv_list_customer.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                var confirmResult = MessageBox.Show("Tem certeza que deseja deletar este cliente?", "Confirmar Deleção",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {

                    var resultDelete = await _customerUseCase.DeleteCustomerAsync(customerId);
                    if (resultDelete.IsSuccess)
                    {
                        MessageBox.Show("Cliente deletado com sucesso.");
                        LoadCustomerDataGrid();
                    }
                    else
                    {
                        var err = resultDelete.Error;
                        MessageBox.Show(err.Description, err.Message);
                    }
                }
            }
        }

        private void txt_customer_search_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_customer_search.Text))
            {
                LoadCustomerDataGrid(txt_customer_search.Text);
            }
        }

        private void btn_customer_save_Click(object sender, EventArgs e)
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
                MessageBox.Show("Cliente registrado com sucesso.");
            }
            else
            {
                var err = resultCreateUser.Error;
                MessageBox.Show(err.Description, err.Message);
            }
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            
            this.Hide();
        }

        private void produtosToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void registrarVendaToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void verVendasToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
