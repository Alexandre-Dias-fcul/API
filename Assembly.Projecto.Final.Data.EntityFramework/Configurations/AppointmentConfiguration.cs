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
    internal class AppointmentConfiguration: IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(a => a.Id);

            builder.HasMany(p => p.Participants)
                   .WithOne(a => a.Appointment)
                   .HasForeignKey(a => a.AppointmentId);

            builder.Property(e => e.Title).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(2000).IsRequired();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.HourStart).IsRequired();
            builder.Property(e => e.HourEnd).IsRequired();
            builder.Property(e => e.Status).IsRequired();
        }
    }
}
