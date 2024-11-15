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
    public partial class ReportCustomers : Form
    {
        private CustomerUseCase _customerUseCase;
        private IServiceProvider _serviceProvider;
        public ReportCustomers(CustomerUseCase customerUseCase, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _customerUseCase = customerUseCase;
            _serviceProvider = serviceProvider;
        }

        private void ReportCustomers_Load(object sender, EventArgs e)
        {
            FillReport();
        }
        private void FillReport(DateTime startDate = default, DateTime endDate = default, string search = default)
        {
            var resultFindCustomer = _customerUseCase.FindReportCustomer(startDate, endDate, search :search);

            if(resultFindCustomer.IsFailure){
                var err = resultFindCustomer.Error;
                MessageBox.Show(err.Description, err.Message);
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("PhoneNumber", typeof(string));
            dt.Columns.Add("TotalAmountSpent", typeof(decimal));

            var reportCustomers = resultFindCustomer.Ok;
            foreach (var reportCustomer in reportCustomers)
            {
                dt.Rows.Add(reportCustomer.Name, reportCustomer.Email, reportCustomer.PhoneNumber, reportCustomer.TotalAmountSpent);
            }

            ReportDataSource reportDataSource = new ReportDataSource("DataSetCustomer", dt);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
        }

        private void txt_report_customer_search_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_report_customer_search.Text))
            {
                FillReport(search: txt_report_customer_search.Text);
            }
        }

        private void btn_search_date_Click(object sender, EventArgs e)
        {
            FillReport(dtp_start_date.Value, dtp_end_date.Value, txt_report_customer_search.Text);
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
    }
}
