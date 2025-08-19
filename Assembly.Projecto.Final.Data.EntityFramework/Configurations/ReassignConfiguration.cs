using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Configurations
{
    internal class ReassignConfiguration : IEntityTypeConfiguration<Reassign>
    {
        public void Configure(EntityTypeBuilder<Reassign> builder)
        {
            builder.ToTable("Reassigns");

            builder.HasKey(r => r.Id);

            builder.HasOne(l => l.Listing)
                   .WithMany(e => e.Reassigns)
                   .HasForeignKey(r => r.ListingId);

            builder.Property(e => e.OlderEmployeeId).IsRequired();
            builder.Property(e => e.NewEmployeeId).IsRequired();
            builder.Property(e => e.ReassignBy).IsRequired();
            builder.Property(e => e.ReassignmentDate).IsRequired();
            builder.Property(e => e.Created).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.Updated).IsRequired();
            builder.Property(e => e.UpdatedBy).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
        }
    }
}
