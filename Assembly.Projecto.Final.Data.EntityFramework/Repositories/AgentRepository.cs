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
    public class AgentRepository : Repository<Agent, int>, IAgentRepository
    {
        public AgentRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        public Agent? GetByIdWithAddresses(int id)
        {
            return DbSet.Include(a => a.EntityLink)
                .ThenInclude(el => el.Addresses)
                .FirstOrDefault(a => a.Id == id);
        }

        public Agent? GetByIdWithAccount(int id) 
        {
            return DbSet.Include(a => a.EntityLink)
                .ThenInclude(el => el.Account)
                .FirstOrDefault(a => a.Id == id);
        }

        public Agent? GetByIdWithContacts(int id) 
        { 
            return DbSet.Include(a => a.EntityLink)
                .ThenInclude(el => el.Contacts)
                .FirstOrDefault(a => a.Id == id);
        }

        public Agent? GetByIdWithAll(int id)
        {
            return DbSet
                   .Include(a => a.EntityLink)
                   .ThenInclude(el => el.Account)
                   .Include(a => a.EntityLink)
                   .ThenInclude(el => el.Contacts)
                   .Include(a => a.EntityLink)
                   .ThenInclude(el => el.Addresses)
                   .FirstOrDefault(a => a.Id == id);
        }

        public Agent? GetByIdWithPersonalContacts(int id)
        {
            return DbSet
                .Include(a => a.PersonalContacts)
                .ThenInclude(c => c.PersonalContactDetails)
                .FirstOrDefault(a => a.Id == id);
        }

        public Agent? GetByIdWithParticipants(int id)
        {
            return DbSet
                  .Include(a => a.Participants)
                  .ThenInclude(p => p.Appointment)
                  .FirstOrDefault(a => a.Id == id);
        }

        public Agent? GetByIdWithAgents(int id)
        {
            return DbSet.Include(a => a.Agents).FirstOrDefault(a => a.Id == id);
        }

        public Agent? GetByIdWithListings(int id)
        {
            return DbSet.Include(a => a.Listings).FirstOrDefault(a => a.Id == id);
        }
    }
}
