using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Teste.Models.Entities;

namespace Teste.Data.EntityConfigurations
{
    public class ItemsSaleEntityConfiguration : IEntityTypeConfiguration<ItemsSale>
    {
        public void Configure(EntityTypeBuilder<ItemsSale> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.ItemsSales)
                .HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.Sale)
                .WithMany(e => e.ItemsSales)
                .HasForeignKey(e => e.SaleId);
        }
    }
}