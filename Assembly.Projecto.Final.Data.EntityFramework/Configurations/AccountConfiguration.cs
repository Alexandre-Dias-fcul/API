using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(a => a.Id);

            builder.HasOne(e => e.EntityLink)
                   .WithOne(e => e.Account)
                   .HasForeignKey<Account>(e => e.EntityLinkId);

            builder.Property(e => e.PasswordHash).HasMaxLength(500).IsRequired();
            builder.Property(e => e.PasswordSalt).HasMaxLength(500).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(300).IsRequired();
            builder.Property(e => e.Created).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.Updated).IsRequired();
            builder.Property(e => e.UpdatedBy).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
        }
    }
}