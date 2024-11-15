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
using Test.Models.Responses;
using Test.Reports;
using Teste.Models.Entities;
using Teste.UseCases;

namespace Test
{
    public partial class SoldForm : Form
    {
        private ItemsSaleUseCase _itemsSaleUseCase;
        private IServiceProvider _serviceProvider;
        public SoldForm(ItemsSaleUseCase itemsSaleUseCase, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _itemsSaleUseCase = itemsSaleUseCase;
            txt_sold_search.TextChanged += txt_sold_search_TextChanged;
            _serviceProvider = serviceProvider;
        }

        private void dgv_sold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SoldForm_Load(object sender, EventArgs e)
        {
            LoadCustomerDataGrid();
        }

        #region Aux
        private DataTable CreateCustomerDataTable(List<ItemsSalesResponse> itemsSales)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(Guid));
            table.Columns.Add("Nome do produto", typeof(string));
            table.Columns.Add("Quantidade", typeof(string));
            table.Columns.Add("Preço unitario", typeof(string));
            table.Columns.Add("Nome do cliente", typeof(string));
            table.Columns.Add("Nº de telefone do cliente", typeof(string));
            table.Columns.Add("Vendido em", typeof(string));

            foreach (var itemsSale in itemsSales)
            {
                table.Rows.Add(itemsSale.Id, itemsSale.Product.Name, itemsSale.Quantity, itemsSale.UnitPrice, itemsSale.Sale.Customer.Name, itemsSale.Sale.Customer.PhoneNumber, itemsSale.CreatedAt);
            }

            return table;
        }
        private void LoadCustomerDataGrid(DateTime startDate = default, DateTime endDate = default, string search = default)
        {
            try
            {
                var resultFindItemsSale = _itemsSaleUseCase.FindAllItemsSale(startDate, endDate, search);
                if (resultFindItemsSale.IsSuccess)
                {
                    var itemsSales = resultFindItemsSale.Ok;
                    DataTable table = CreateCustomerDataTable(itemsSales);
                    dgv_sold.DataSource = table;
                }
                else
                {
                    var err = resultFindItemsSale.Error;
                    MessageBox.Show(err.Description, err.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }
        #endregion

        private void txt_sold_search_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_sold_search.Text))
            {
                LoadCustomerDataGrid(search:txt_sold_search.Text);
            }
        }

        private void btn_search_sold_Click(object sender, EventArgs e)
        {
            LoadCustomerDataGrid(dtp_start.Value, dtp_end.Value);
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Hide();
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

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
