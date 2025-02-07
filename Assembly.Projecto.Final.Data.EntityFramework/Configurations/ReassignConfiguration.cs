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
    internal class ReassignConfiguration : IEntityTypeConfiguration<Reassign>
    {
        public void Configure(EntityTypeBuilder<Reassign> builder)
        {
            builder.Property(e => e.OlderEmployeeId).IsRequired();
            builder.Property(e => e.NewEmployeeId).IsRequired();
            builder.Property(e => e.ReassignBy).IsRequired();
            builder.Property(e => e.ReassignmentDate).IsRequired();
        }
    }
}
