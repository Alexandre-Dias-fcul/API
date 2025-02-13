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
           
        }
    }
}
