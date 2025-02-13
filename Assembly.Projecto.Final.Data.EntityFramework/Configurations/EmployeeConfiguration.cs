﻿using Assembly.Projecto.Final.Domain.Common;
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
            
            builder.HasMany(e => e.Agents) 
                   .WithOne(e => e.Supervisor) 
                   .HasForeignKey(e => e.SupervisorId) 
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasDiscriminator<RoleType>("Role")
                 .HasValue<Employee>(RoleType.Employee)
                 .HasValue<Staff>(RoleType.Staff)
                 .HasValue<Agent>(RoleType.Agent);

            builder.HasOne(e => e.EntityLink)
               .WithOne()
               .HasForeignKey<Employee>(e => e.EntityLinkId)
               .OnDelete(DeleteBehavior.Restrict);

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
            builder.Property(e => e.Role).IsRequired();
        }
    }
}
