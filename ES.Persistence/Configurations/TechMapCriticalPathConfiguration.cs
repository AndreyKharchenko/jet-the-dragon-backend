using ES.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.Configurations
{
    internal class TechMapCriticalPathConfiguration : IEntityTypeConfiguration<TechMapCriticalPath>
    {
        public void Configure(EntityTypeBuilder<TechMapCriticalPath> builder)
        {
            builder.ToTable(nameof(TechMapCriticalPath));

            builder.HasKey(cpath => cpath.Id);
            builder.Property(cpath => cpath.Id).IsRequired().ValueGeneratedNever();

            builder
                .HasOne(cpath => cpath.TechMap)
                .WithOne(techmap => techmap.CriticalPath)
                // .HasForeignKey(cpath => cpath.TechMapId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<byte[]>("RowVersion").IsRowVersion();
        }
    }
}
