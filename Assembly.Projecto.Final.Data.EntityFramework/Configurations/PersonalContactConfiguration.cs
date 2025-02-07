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
            builder.Property(e => e.Name).HasMaxLength(500).IsRequired();
            builder.Property(e => e.IsPrimary).IsRequired();
            builder.Property(e => e.Notes).IsRequired(false);
        }
    }
}
