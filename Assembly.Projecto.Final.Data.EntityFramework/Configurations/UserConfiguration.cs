using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.HasOne(e => e.EntityLink)
                   .WithOne(u => u.User)
                   .HasForeignKey<User>(u => u.EntityLinkId);

            builder.OwnsOne(e => e.Name, nameBuilder =>
            {
                nameBuilder.Property(n => n.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(100)
                    .IsRequired();

                var stringArrayComparer = new ValueComparer<string[]>(
                     (a, b) => a == null && b == null || a != null && b != null && a.SequenceEqual(b),
                     a => a == null ? 0 : a.Aggregate(0, (hash, s) => HashCode.Combine(hash, s != null ? s.GetHashCode() : 0)),
                     a => a == null ? null : a.ToArray()
                 );


                nameBuilder.Property(n => n.MiddleNames)
                    .HasColumnName("MiddleNames")
                    .HasMaxLength(500)
                    .HasConversion(
                        v => string.Join(' ', v ?? Array.Empty<string>()),
                        v => string.IsNullOrWhiteSpace(v) ? Array.Empty<string>() : v.Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        stringArrayComparer
                    )
                    .IsRequired(false);


                nameBuilder.Property(n => n.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(100)
                    .IsRequired();

            });

            builder.Property(e => e.DateOfBirth).IsRequired(false);
            builder.Property(e => e.Gender).HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.PhotoFileName).HasMaxLength(300).IsRequired(false);
            builder.Property(e => e.Created).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.Updated).IsRequired();
            builder.Property(e => e.UpdatedBy).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();

        }
    }
}
