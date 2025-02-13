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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.EntityLink)
                   .WithOne()
                   .HasForeignKey<User>(u => u.EntityLinkId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(e => e.Name, name =>
            {
                name.Property(n => n.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(100)
                    .IsRequired();

                name.Property(n => n.MiddleNames)
                    .HasColumnName("MiddleNames")
                    .HasMaxLength(500)
                    .IsRequired(false);

                name.Property(n => n.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(100)
                    .IsRequired();
            });

            builder.Property(e => e.DateOfBirth).HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.Gender).HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.PhotoFileName).HasMaxLength(300).IsRequired(false);
        }
    }
}
