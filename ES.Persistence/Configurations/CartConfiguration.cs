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
    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable(nameof(Cart));

            builder.HasKey(cart => cart.Id);

            builder
                .HasOne(cart => cart.Customer)
                .WithMany()
                .HasForeignKey(cart => cart.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<byte[]>("RowVersion").IsRowVersion();

        }
    }
}
