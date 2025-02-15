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
    internal class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorites");

            builder.HasKey(f => f.Id);

            builder.HasOne(u => u.User)
                   .WithMany()
                   .HasForeignKey(f => f.UserId);

            builder.HasOne(l => l.Listing)
                   .WithMany()
                   .HasForeignKey(f => f.ListingId);
        }
    }
}
