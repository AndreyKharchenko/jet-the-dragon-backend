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
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable(nameof(Supplier));

            builder.HasKey(supplier => supplier.Id);

            builder.HasOne(supplier => supplier.Customer).WithMany().HasForeignKey(supplier => supplier.CustomerId);

            builder.HasIndex(supplier => supplier.CustomerId).IsUnique();

            builder.Property<byte[]>("RowVersion").IsRowVersion();

        }
    }
}
