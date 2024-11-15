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
    public partial class ReportSales : Form
    {
        private IServiceProvider _serviceProvider;
        private ItemsSaleUseCase _itemsSaleUseCase;
        public ReportSales(ItemsSaleUseCase itemsSaleUseCase, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _itemsSaleUseCase = itemsSaleUseCase;
            _serviceProvider = serviceProvider;
            txt_report_sale_search.TextChanged += txt_report_sale_search_TextChanged;
        }

        private void ReportSales_Load(object sender, EventArgs e)
        {
            FillReport();
        }
        private void FillReport(DateTime startDate = default, DateTime endDate = default, string search = default)
        {
            var resultFindItemSale = _itemsSaleUseCase.FindReportItemsSale(startDate, endDate, search);

            if (resultFindItemSale.IsFailure) {
                var err = resultFindItemSale.Error;
                MessageBox.Show(err.Description, err.Message);
                return; 
            };
            var reportCustomers = resultFindItemSale.Ok;

            DataTable dt = new DataTable();
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("SoldIn", typeof(DateTime));
            dt.Columns.Add("CustomerName", typeof(string));
            dt.Columns.Add("CustomerPhoneNumber", typeof(string));

            foreach (var reportCustomer in reportCustomers)
            {
                dt.Rows.Add(reportCustomer.ProductName, reportCustomer.Quantity, reportCustomer.UnitPrice, reportCustomer.SoldIn , reportCustomer.CustomerName, reportCustomer.CustomerPhoneNumber);
            }

            ReportDataSource reportDataSource = new ReportDataSource("DataSetSale", dt);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
        }

        private void btn_search_date_Click(object sender, EventArgs e)
        {
            FillReport(dtp_start_date.Value, dtp_end_date.Value);
        }

        private void txt_report_sale_search_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_report_sale_search.Text))
            {
                FillReport(search: txt_report_sale_search.Text);
            }
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
