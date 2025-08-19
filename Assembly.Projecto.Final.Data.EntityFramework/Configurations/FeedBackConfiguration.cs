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
    internal class FeedBackConfiguration : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.ToTable("FeedBacks");

            builder.HasKey(f => f.Id);

            builder.HasOne(u => u.User)
                   .WithMany(f => f.FeedBacks)
                   .HasForeignKey(f => f.UserId);

            builder.HasOne(l => l.Listing)
                   .WithMany(f => f.FeedBacks)
                   .HasForeignKey(f => f.ListingId);

            builder.Property(e => e.Rate).IsRequired(false);
            builder.Property(e => e.Comment).HasMaxLength(2000).IsRequired(false);
            builder.Property(e => e.CommentDate).IsRequired(false);
            builder.Property(e => e.Created).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.Updated).IsRequired();
            builder.Property(e => e.UpdatedBy).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
        }
    }
}
