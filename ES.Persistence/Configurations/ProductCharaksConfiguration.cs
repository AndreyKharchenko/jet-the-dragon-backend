using ES.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.Configurations
{
    internal class ProductCharaksConfiguration : IEntityTypeConfiguration<ProductCharaks>
    {
        public void Configure(EntityTypeBuilder<ProductCharaks> builder)
        {
            builder.ToTable(nameof(ProductCharaks));

            builder.HasKey(charak => charak.Id);
            builder.Property(charak => charak.Id).IsRequired().ValueGeneratedNever();

            builder
                .HasOne(charak => charak.Product)
                .WithMany()
                .HasForeignKey(charak => charak.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<byte[]>("RowVersion").IsRowVersion();

        }
    }
}
