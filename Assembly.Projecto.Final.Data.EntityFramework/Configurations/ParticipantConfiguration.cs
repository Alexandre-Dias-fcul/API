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
    internal class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participants");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Appointment)
                   .WithMany()
                   .HasForeignKey(a => a.AppointmentId);

            builder.HasOne(p => p.Employee)
                   .WithMany()
                   .HasForeignKey(e => e.EmployeeId);

            builder.Property(e => e.Role).IsRequired();
        }
    }
}
