using ES.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));

            builder.HasKey(order => order.Id);

            builder
                .HasOne(order => order.Product)
                .WithMany()
                .HasForeignKey(order => order.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(order => order.Cart)
                .WithMany()
                .HasForeignKey(order => order.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<byte[]>("RowVersion").IsRowVersion();

        }
    }
}
