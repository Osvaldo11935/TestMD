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
