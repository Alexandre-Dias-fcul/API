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
    internal class PersonalContactConfiguration : IEntityTypeConfiguration<PersonalContact>
    {
        public void Configure(EntityTypeBuilder<PersonalContact> builder)
        {
            builder.ToTable("PersonalContacts");

            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.PersonalContactDetails)
                   .WithOne(pc=>pc.PersonalContact)
                   .HasForeignKey(pc => pc.PersonalContactId);

            builder.HasOne(e => e.Employee)
                   .WithMany(p => p.PersonalContacts)
                   .HasForeignKey( e => e.EmployeeId);

            builder.Property(e => e.Name).HasMaxLength(500).IsRequired();
            builder.Property(e => e.IsPrimary).IsRequired();
            builder.Property(e => e.Notes).HasMaxLength(2000).IsRequired(false);
        }
    }
}
