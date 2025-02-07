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
            builder.Property(e => e.Password).HasMaxLength(500).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(300).IsRequired();
            builder.HasOne(ac => ac.User)
                     .WithOne(u => u.Account)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}