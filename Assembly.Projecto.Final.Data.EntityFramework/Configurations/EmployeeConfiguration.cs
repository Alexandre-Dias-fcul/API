using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.ToTable("Employees");

            builder.HasKey(e => e.Id);

            builder.HasDiscriminator<Discriminator>("Discriminator") // Define a coluna discriminadora
                    .HasValue<Employee>(Discriminator.Employee)
                    .HasValue<Agent>(Discriminator.Agent)
                    .HasValue<Staff>(Discriminator.Staff);

            builder.HasOne(e => e.EntityLink)
                   .WithOne( em => em.Employee)
                   .HasForeignKey<Employee>(em=> em.EntityLinkId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.PersonalContacts)
                   .WithOne()
                   .HasForeignKey(p => p.EmployeeId);

            builder.HasMany(p => p.Participants)
                   .WithOne(e => e.Employee)
                   .HasForeignKey(p => p.EmployeeId);

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

            builder.Property(e => e.DateOfBirth).IsRequired(false);
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.Gender).HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.PhotoFileName).HasMaxLength(300).IsRequired(false);
            builder.Property(e => e.HiredDate).IsRequired(false);
            builder.Property(e => e.DateOfTermination).IsRequired(false);
        }
    }
}
