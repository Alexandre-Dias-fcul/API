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
        private readonly ApplicationDbContext _context;
        public AgentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Agent? GetByIdWithAddresses(int id)
        {
            return _context.Employees.OfType<Agent>()
                .Include(a => a.EntityLink)
                .ThenInclude(el => el.Addresses)
                .FirstOrDefault(a => a.Id == id);
        }

        public Agent? GetByIdWithAccount(int id) 
        {
            return _context.Employees.OfType<Agent>()
                .Include(a => a.EntityLink)
                .ThenInclude(el => el.Account)
                .FirstOrDefault(a => a.Id == id);
        }

        public Agent? GetByIdWithContacts(int id) 
        { 
            return _context.Employees.OfType<Agent>()
                .Include(a => a.EntityLink)
                .ThenInclude(el => el.Contacts)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
