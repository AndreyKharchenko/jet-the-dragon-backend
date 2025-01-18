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
    internal class TechMapConfiguration : IEntityTypeConfiguration<TechMap>
    {
        public void Configure(EntityTypeBuilder<TechMap> builder)
        {
            builder.ToTable(nameof(TechMap));
            builder.HasKey(techMap => techMap.Id);

            builder
                .HasOne(techMap => techMap.Supplier)
                .WithMany()
                .HasForeignKey(techMap => techMap.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<byte[]>("RowVersion").IsRowVersion();

        }
    }
}
