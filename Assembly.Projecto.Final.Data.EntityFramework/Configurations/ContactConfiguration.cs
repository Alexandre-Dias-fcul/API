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
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(e => e.ContactType).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Value).HasMaxLength(300).IsRequired();
            builder.HasOne(c => c.User)
                       .WithMany(u => u.Contacts)
                       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
