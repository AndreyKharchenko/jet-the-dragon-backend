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
    internal class TechMapJobsConfiguration : IEntityTypeConfiguration<TechMapJobs>
    {
        public void Configure(EntityTypeBuilder<TechMapJobs> builder)
        {
            builder.ToTable(nameof(TechMapJobs));

            builder.HasKey(job => job.Id);
            builder.Property(job => job.Id).IsRequired().ValueGeneratedNever();

            builder
                .HasOne(job => job.TechMap)
                .WithMany()
                .HasForeignKey(job => job.TechMapId)
                .OnDelete(DeleteBehavior.Restrict);

           builder.Property(e => e.JobDependence)
                  .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));




            builder.Property<byte[]>("RowVersion").IsRowVersion();
        }
    }
}
