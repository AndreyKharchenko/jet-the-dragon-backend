using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ES.Domain;

namespace ES.Persistence.Configurations
{
    
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(product => product.Id);

            builder
                .HasOne(product => product.Category)
                .WithMany()
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(product => product.Supplier)
                .WithMany()
                .HasForeignKey(product => product.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            

            builder.Property<byte[]>("RowVersion").IsRowVersion();

        }
    }
}
