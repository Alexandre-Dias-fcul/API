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
    internal class ListingConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.ToTable("Listings");

            builder.HasKey(l => l.Id);

            builder.HasOne(e=> e.Agent)
                   .WithMany()
                   .HasForeignKey(l => l.AgentId);

            builder.Property(e => e.Type).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Status).HasMaxLength(50).IsRequired();
            builder.Property(e => e.NumberOfRooms).IsRequired(false);
            builder.Property(e => e.NumberOfBathrooms).IsRequired(false);
            builder.Property(e => e.NumberOfKitchens).IsRequired(false);
            builder.Property(e => e.Price).IsRequired();
            builder.Property(e => e.Location).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Area).IsRequired();
            builder.Property(e => e.Parking).IsRequired(false);
            builder.Property(e => e.Description).HasMaxLength(5000).IsRequired();
            builder.Property(e => e.MainImageFileName).HasMaxLength(300).IsRequired(false);
            builder.Property(e => e.OtherImagesFileNames).HasMaxLength(1000).IsRequired(false);

        }
    }
}
