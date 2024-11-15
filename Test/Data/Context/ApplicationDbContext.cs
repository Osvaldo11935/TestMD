using Microsoft.EntityFrameworkCore;
using System;
using Teste.Data.EntityConfigurations;

namespace Teste.Data.Context
{
    public class ApplicationDbContext: DbContext
    {
        #region Construtor
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        #endregion

        #region Method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseNpgsql("Host=localhost;Database=db_test_dev;Username=root;Password=123");
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemsSaleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SaleEntityConfiguration());
        }
        #endregion
    }
}
