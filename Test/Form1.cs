using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Test.Reports;


namespace Test
{
    public partial class Form1 : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public Form1(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            Application.OpenForms[0].Hide();
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
            Application.OpenForms[0].Hide();
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
            Application.OpenForms[0].Hide();
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
            Application.OpenForms[0].Hide();
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
            Application.OpenForms[0].Hide();
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
            Application.OpenForms[0].Hide();
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
            Application.OpenForms[0].Hide();
        }
    }
}
