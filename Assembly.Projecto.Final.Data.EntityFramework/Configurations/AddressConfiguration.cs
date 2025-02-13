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
    internal class AddressConfiguration: IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(e => e.Street).HasMaxLength(200).IsRequired();
            builder.Property(e => e.City).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Country).HasMaxLength(200).IsRequired();
            builder.Property(e => e.PostalCode).HasMaxLength(10).IsRequired();
        }
    }
}

