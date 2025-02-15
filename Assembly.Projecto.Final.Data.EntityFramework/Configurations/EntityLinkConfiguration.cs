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
    internal class EntityLinkConfiguration : IEntityTypeConfiguration<EntityLink>
    {
        public void Configure(EntityTypeBuilder<EntityLink> builder)
        {
            builder.ToTable("EntityLinks");

            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Contacts)
                   .WithOne()
                   .HasForeignKey(c => c.EntityLinkId);

            builder.HasMany(e => e.Addresses)
                   .WithMany()
                   .UsingEntity<Dictionary<string, object>>(
                    "EntityLinkAddresses",
                    j => j.HasOne<Address>()
                          .WithMany()
                          .HasForeignKey("AddressId"),
                    j => j.HasOne<EntityLink>()
                          .WithMany()
                          .HasForeignKey("EntityLinkId")
                   );

            builder.HasOne(e => e.Account)
                   .WithOne()
                   .HasForeignKey<Account>(a => a.EntityLinkId);
        }
    }
}
