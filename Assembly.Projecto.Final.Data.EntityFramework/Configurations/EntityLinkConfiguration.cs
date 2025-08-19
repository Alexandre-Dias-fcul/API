using Assembly.Projecto.Final.Domain.Common;
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

            builder.HasMany(c => c.Contacts)
                   .WithOne(e => e.EntityLink)
                   .HasForeignKey(c => c.EntityLinkId);

            builder.HasMany(e => e.Addresses)
                   .WithMany(e => e.EntityLinks)
                   .UsingEntity(j => j.ToTable("EntityLinkAddresses"));

            builder.HasOne(a => a.Account)
                   .WithOne(e => e.EntityLink)
                   .HasForeignKey<Account>(a => a.EntityLinkId);

            builder.HasOne(e => e.Employee)
                   .WithOne(e => e.EntityLink)
                   .HasForeignKey<Employee>(e => e.EntityLinkId);

            builder.HasOne(u => u.User)
                   .WithOne(e => e.EntityLink)
                   .HasForeignKey<User>(u=> u.EntityLinkId);

            builder.Property(e => e.EntityType).IsRequired();
            builder.Property(e => e.EntityId).IsRequired();
            builder.Property(e => e.Created).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.Updated).IsRequired();
            builder.Property(e => e.UpdatedBy).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired();
        }
    }
}
