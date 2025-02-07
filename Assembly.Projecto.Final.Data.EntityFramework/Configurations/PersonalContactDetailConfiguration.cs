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
    internal class PersonalContactDetailConfiguration: IEntityTypeConfiguration<PersonalContactDetail>

    {
        public void Configure(EntityTypeBuilder<PersonalContactDetail> builder)
        {
            builder.Property(e => e.ContactType).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Value).HasMaxLength(300).IsRequired();
        }
    }
}
