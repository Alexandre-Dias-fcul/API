using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Repositories
{
    public class StaffRepository : Repository<Staff, int>, IStaffRepository
    {
        public StaffRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Staff? GetByIdWithAccount(int id)
        {
            return DbSet.Include(s => s.EntityLink)
                .ThenInclude(el => el.Account)
                .FirstOrDefault(s => s.Id == id);
        }

        public Staff? GetByIdWithAddresses(int id)
        {
            return DbSet.Include(s => s.EntityLink)
                 .ThenInclude(el => el.Addresses)
                 .FirstOrDefault(s => s.Id == id);
        }

        public Staff? GetByIdWithAll(int id)
        {
            return DbSet
                   .Include(s => s.EntityLink)
                   .ThenInclude(el => el.Account)
                   .Include(s => s.EntityLink)
                   .ThenInclude(el => el.Contacts)
                   .Include(s => s.EntityLink)
                   .ThenInclude(el => el.Addresses)
                   .FirstOrDefault(s => s.Id == id);
        }

        public Staff? GetByIdWithContacts(int id)
        {
            return DbSet.Include(s => s.EntityLink)
                 .ThenInclude(el => el.Contacts)
                 .FirstOrDefault(s => s.Id == id);
        }

        public Staff? GetByIdWithPersonalContacts(int id)
        {
            return DbSet
                .Include(a => a.PersonalContacts)
                .ThenInclude(c => c.PersonalContactDetails)
                .FirstOrDefault(a => a.Id == id);
        }

        public Staff? GetByIdWithParticipants(int id)
        {
            return DbSet
                  .Include(a => a.Participants)
                  .ThenInclude(p => p.Appointment)
                  .FirstOrDefault(a => a.Id == id);
        }
    }
}
