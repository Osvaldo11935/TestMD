using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste.Data.Context;
using Teste.Data.Repositories.Common;
using Teste.Data.Repositories;
using Teste.Interfaces.IRepositories.ICommon;
using Teste.Interfaces.IRepositories;
using Teste.UseCases;
using Microsoft.EntityFrameworkCore;
using Test.Reports;

namespace Test
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = serviceProvider.GetRequiredService<Form1>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {

            #region DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql("Host=localhost;Database=db_test_dev;Username=root;Password=123"));
            #endregion

            #region Registrar repositórios e UnitOfWork
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IItemsSaleRepository, ItemsSaleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Registrar casos de uso
            services.AddScoped<SaleUseCase>();
            services.AddScoped<CustomerUseCase>();
            services.AddScoped<ItemsSaleUseCase>();
            services.AddScoped<ProductUseCase>();
            #endregion

            #region Registrar formulários
            services.AddScoped<ProductForm>();
            services.AddScoped<CustomerForm>();
            services.AddScoped<SaleForm>();
            services.AddScoped<ReportProducts>();
            services.AddScoped<ReportCustomers>();
            services.AddScoped<ReportSales>();
            services.AddScoped<Form1>();
            #endregion

            #region Other
            services.AddLogging();
            #endregion

        }
    }
}
