using Microsoft.Extensions.DependencyInjection;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste.UseCases;

namespace Test.Reports
{
    public partial class ReportProducts : Form
    {

        private ProductUseCase _productUseCase;
        private IServiceProvider _serviceProvider;
        public ReportProducts(ProductUseCase productUseCase, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _productUseCase = productUseCase;
            _serviceProvider = serviceProvider;
        }

        private void ReportProducts_Load(object sender, EventArgs e)
        {

            FillReport();
        }
        private void FillReport(DateTime startEnd = default, DateTime endDate = default, string search = default)
        {
            var resultFindProduct = _productUseCase.FindProductInStock(startEnd, endDate, search);

            if (resultFindProduct.IsFailure)
            {
                var err = resultFindProduct.Error;
                MessageBox.Show(err.Description, err.Message);
                return;
            };
            var reportCustomers = resultFindProduct.Ok;

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(int));
            dt.Columns.Add("Quantity", typeof(decimal));
            dt.Columns.Add("CreatedAt", typeof(DateTime));
            dt.Columns.Add("UpdatedAt", typeof(string));

            foreach (var reportCustomer in reportCustomers)
            {
                dt.Rows.Add(reportCustomer.Name, reportCustomer.Price, reportCustomer.Quantity, reportCustomer.CreatedAt, reportCustomer.UpdatedAt);
            }

            ReportDataSource reportDataSource = new ReportDataSource("DataSetProduct", dt);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
        }

        private void txt_report_product_search_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_report_product_search.Text))
            {
                FillReport(search: txt_report_product_search.Text);
            }
        }

        private void btn_search_date_Click(object sender, EventArgs e)
        {
            FillReport(dtp_start_date.Value, dtp_end_date.Value);
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

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
