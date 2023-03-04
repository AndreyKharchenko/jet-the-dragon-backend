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
    internal class FavouritiesConfiguration : IEntityTypeConfiguration<Favourities>
    {
        public void Configure(EntityTypeBuilder<Favourities> builder)
        {
            builder.ToTable(nameof(Favourities));

            builder.HasKey(favourities => favourities.Id);

            builder
                .HasOne(favourities => favourities.Customer)
                .WithMany()
                .HasForeignKey(favourities => favourities.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(favourities => favourities.Product)
                .WithMany()
                .HasForeignKey(favourities => favourities.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<byte[]>("RowVersion").IsRowVersion();

        }
    }
}
