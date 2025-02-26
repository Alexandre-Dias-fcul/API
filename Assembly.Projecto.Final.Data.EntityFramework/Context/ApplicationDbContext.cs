using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Interfaces;
using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EntityLink> EntityLinks { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<PersonalContact> PersonalContacts { get; set; }
        public DbSet<PersonalContactDetail> PersonalContactDetails { get; set; }
        public DbSet<Reassign> Reassigns { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            // Filter Soft Deleted entities on calling DbSet
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType) && entityType.BaseType == null)
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");

                    var filter = Expression.Lambda(
                        Expression.Equal(
                            Expression.Property(parameter, nameof(ISoftDelete.IsDeleted)),
                            Expression.Constant(false)
                            ),
                        parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }
        }
    }
}
